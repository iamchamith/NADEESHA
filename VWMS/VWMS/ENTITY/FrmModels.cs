using App.BL;
using App.BL.DbServices;
using App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace VWMS.ENTITY
{
    public partial class FrmModels : Form
    {
        public FrmModels()
        {
            InitializeComponent();
            LoadInfo();
            LoadBrands();

        }

        private void LoadBrands()
        {
            var lst = (List<Brand>)new BrandsDbService().Read().Content;
            cmbBrands.ValueMember = "ID";
            cmbBrands.DisplayMember = "Name";
            cmbBrands.DataSource = lst;
        }
        DataTable GTble = new DataTable();
        void LoadInfo()
        {
            gvData.DataSource = GTble = Helper.CreateDataTable<Model>((List<Model>)new ModelDbService().Read().Content);
        }

        public bool IsValidate()
        {
            bool isOk = true;
            StringBuilder msg = new StringBuilder();
            if (cmbBrands.SelectedIndex == -1)
            {
                msg.Append("Brand Name is required \n");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                msg.Append("Model Name required \n");
                isOk = false;
            }
            if (!isOk)
            {
                Helper.ErrorMessage(msg.ToString());
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
            try
            {
                var x = new ModelDbService().Create(new Model
                {
                    BrandId = int.Parse(cmbBrands.SelectedValue.ToString()),
                    Discription = txtDiscription.Text,
                    Name = txtName.Text
                });
                LoadInfo();
                Helper.SuccessMessage();
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
                var x = new ModelDbService().Update(new Model
                {
                    BrandId = int.Parse(cmbBrands.SelectedValue.ToString()),
                    Discription = txtDiscription.Text,
                    Name = txtName.Text,
                    ID = int.Parse(lblID.Text)
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
            try
            {
                var x = new ModelDbService().Delete(int.Parse(lblID.Text));
                LoadInfo();
                Helper.SuccessMessage();
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        private void gvData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnInsert.Enabled = false;
                DataGridViewRow dr = gvData.Rows[e.RowIndex];
                lblID.Text = dr.Cells["ID"].Value.ToString();
                txtName.Text = dr.Cells["NAME"].Value.ToString();
                txtDiscription.Text = dr.Cells["Discription"].Value.ToString();
                cmbBrands.SelectedValue = int.Parse(dr.Cells["BrandId"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                gvData.DataSource = GTble.Select($"{lblSearchKey.Text} like '{txtSearchBy.Text}%'").CopyToDataTable();
            }
            catch (Exception ex)
            {
                LoadInfo();
            }
        }
        private void gvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lblSearchKey.Text = string.Format("{0}", gvData.Columns[e.ColumnIndex].Name);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBrands obj = new FrmBrands();
            obj.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBrands();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnInsert.Enabled = true;
            txtDiscription.Clear();
            txtName.Clear();
            lblID.Text = "0";
            cmbBrands.SelectedIndex = 0;
        }

        private void FrmModels_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
