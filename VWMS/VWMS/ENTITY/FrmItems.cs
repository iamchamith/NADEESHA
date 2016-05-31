using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.BL;
using BL.MODEL;
using VWMS.REPORTING;
using App.BL;
using App.Dal;
using App.Model;

namespace VWMS.ENTITY
{
    public partial class FrmItems : Form
    {
        public FrmItems()
        {
            InitializeComponent();
            LoadInfo();
        }

        INVENTORY.FrmInventoryProcess objFrmG = new INVENTORY.FrmInventoryProcess();
        WS.FRMWS objFrmG2 = new WS.FRMWS();
        public FrmItems(INVENTORY.FrmInventoryProcess objFrm)
        {
            InitializeComponent();
            LoadInfo();
            btnGO.Visible = true;
            this.objFrmG = objFrm;
        }
        bool isWS = false;
        public FrmItems(WS.FRMWS objFrm)
        {
            InitializeComponent();
            LoadInfo();
            isWS = true;
            btnGO.Visible = true;
            this.objFrmG2 = objFrm;
        }

        private List<Item> dtG = new List<Item>();

        EOrderBy orderBy = EOrderBy.Asc;
        private void LoadInfo(EOrderBy eorderBy = EOrderBy.Asc)
        {
            dtG = (List<Item>)new ItemDbService().Read().Content;
            dataGridView1.DataSource = (eorderBy == EOrderBy.Asc) ? dtG.OrderBy(p => p.ID).ToList() :
             dtG.OrderByDescending(p => p.ID).ToList();
            orderBy = eorderBy;
        }
        public bool IsValidate()
        {
            bool isOk = true;
            StringBuilder msg = new StringBuilder();

            if (string.IsNullOrEmpty(txtName.Text))
            {
                msg.Append("Item name required \n");
                isOk = false;
            }
            if (cmbCategory.SelectedIndex==-1)
            {
                msg.Append("Category Name  required \n");
                isOk = false;
            }
            if (!BL.BL.HELPER.Validation.IsNumber(txtPriceIn.Text))
            {
                msg.Append("Invalid Price In \n");
                isOk = false;
            }
            if (!BL.BL.HELPER.Validation.IsNumber(txtPriceOut.Text))
            {
                msg.Append("Invalid Price Out \n");
                isOk = false;
            }
            if (!BL.BL.HELPER.Validation.IsNumber(txtReOrderLevel.Text))
            {
                msg.Append("Invalid Reoder leval \n");
                isOk = false;
            }
          
            if (isOk == false)
            {
                MessageBox.Show(msg.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return isOk;

        }
        
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            {
                return;
            }
            if (!IsValidate())
            {
                return;
            }

            double CostPrice = Convert.ToDouble(txtPriceIn.Text);
            double sellingPrice = Convert.ToDouble(txtPriceOut.Text);
            if (CostPrice > sellingPrice)
            {
                MessageBox.Show("Cost Price cannot be higher than selling price");
                return;
            }

            try
            {
                var x = new ItemDbService().Create(new Item
                {

                    CategoryId = cmbCategory.SelectedIndex + 1,
                    Discription = txtDiscription.Text.Trim(),
                    Name = txtName.Text,
                    PriceIn = double.Parse(txtPriceIn.Text),
                    PriceOut = double.Parse(txtPriceOut.Text),
                    Quantity = 0,
                    ReorderLevel = Convert.ToInt32(txtReOrderLevel.Text),
                    
                });
                if (x.State)
                {
                    LoadInfo();
                    MessageBox.Show("Sucessfully Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(x.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch {
                MessageBox.Show("invalied inputs");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            {
                return;
            }
            if (!IsValidate())
            {
                return;
            }
            var x = new ItemDbService().Update(new Item
            {
                CategoryId = cmbCategory.SelectedIndex + 1,
                Discription = txtDiscription.Text,
                Name = txtName.Text,
                PriceIn = double.Parse(txtPriceIn.Text),
                PriceOut = double.Parse(txtPriceOut.Text),
                ID = int.Parse(lblID.Text),
                ReorderLevel = Convert.ToInt32(txtReOrderLevel.Text)
            });
            if (x.State)
            {
                LoadInfo();
                //MessageBox.Show("Sucessfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(x.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            {
                return;
            }
            if (!IsValidate())
            {
                return;
            }
            var x = new ItemDbService().Delete(int.Parse(lblID.Text));
            if (x.State)
            {
                LoadInfo();
                MessageBox.Show("Sucessfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(x.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                lblID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmbCategory.SelectedIndex = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) - 1;
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDiscription.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPriceIn.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPriceOut.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtReOrderLevel.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                lblQuntity.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            if (isWS)
            {
                objFrmG2.LoadItemInfo(lblID.Text, txtName.Text, lblQuntity.Text, txtPriceOut.Text);
                this.Close();
            }
            else
            {
                objFrmG.LoadItemInfo(lblID.Text, txtName.Text, lblQuntity.Text, txtPriceOut.Text);
                this.Close();   
            }
          
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            REPORTING.FrmReport objReport = new FrmReport(EReports.Items, 0);
            objReport.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDiscription.Clear();
            txtName.Clear();
            txtPriceIn.Clear();
            txtPriceOut.Clear();
            txtReOrderLevel.Clear();
            cmbCategory.SelectedIndex = -1;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            lblID.Text = "";
            
        }

        private void FrmItems_Load(object sender, EventArgs e)
        {
            btnInsert.Enabled = true;
            btnUpdate.Enabled=false;
            btnDelete.Enabled = false;
        }

        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadInfo((orderBy == EOrderBy.Asc) ? EOrderBy.Desc : EOrderBy.Asc);
        }
    }
}
