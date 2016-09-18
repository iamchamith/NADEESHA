using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VWMS.REPORTING;
using App.BL;
using App.Dal;
using App.Model;
using static App.Model.Enums;

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

        private void LoadInfo()
        {
            dataGridView1.DataSource = Helper.CreateDataTable<ItemViewModel>((List<ItemViewModel>)new ItemDbService().Read().Content);
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
            if (cmbCategory.SelectedIndex == -1)
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
                Helper.SuccessMessage(message: msg.ToString());
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

            double CostPrice = Convert.ToDouble(txtPriceIn.Value.ToString());
            double sellingPrice = Convert.ToDouble(txtPriceOut.Value.ToString());
            if (CostPrice > sellingPrice)
            {
                Helper.ErrorMessage(message: "Cost Price cannot be higher than selling price");
                return;
            }
            try
            {
                new ItemDbService().Create(new ItemViewModel
                {

                    CategoryId = cmbCategory.SelectedIndex + 1,
                    Discription = txtDiscription.Text.Trim(),
                    Name = txtName.Text,
                    PriceIn = double.Parse(txtPriceIn.Value.ToString()),
                    PriceOut = double.Parse(txtPriceOut.Value.ToString()),
                    Quantity = 0,
                    ReorderLevel = Convert.ToInt32(txtReOrderLevel.Value.ToString()),

                });
                LoadInfo();
                Helper.SuccessMessage(message: "Sucessfully Inserted");
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
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
            try
            {
                new ItemDbService().Update(new ItemViewModel
                {
                    CategoryId = cmbCategory.SelectedIndex + 1,
                    Discription = txtDiscription.Text,
                    Name = txtName.Text,
                    PriceIn = double.Parse(txtPriceIn.Value.ToString()),
                    PriceOut = double.Parse(txtPriceOut.Value.ToString()),
                    ID = int.Parse(lblID.Text),
                    ReorderLevel = Convert.ToInt32(txtReOrderLevel.Text)
                });
                LoadInfo();
                Helper.SuccessMessage();

            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
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
            try
            {
                var x = new ItemDbService().Delete(int.Parse(lblID.Text));
                LoadInfo();
                Helper.SuccessMessage();
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex);
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
                txtPriceIn.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                txtPriceOut.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                txtReOrderLevel.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                lblQuntity.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
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

        private void button1_Click(object sender, EventArgs e)
        {
            REPORTING.FrmReport objReport = new FrmReport(EReports.Items, 0);
            objReport.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDiscription.Clear();
            txtName.Clear();
            txtPriceIn.Value = 0.0M;
            txtPriceOut.Value = 0.0M;
            txtReOrderLevel.Value = 0.0M;
            cmbCategory.SelectedIndex = -1;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            lblID.Text = "";
        }

        private void FrmItems_Load(object sender, EventArgs e)
        {
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
