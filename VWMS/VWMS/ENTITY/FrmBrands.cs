using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.MODEL;
using BL.BL;
using App.Model;

namespace VWMS.ENTITY
{
    public partial class FrmBrands : Form
    {
        public FrmBrands()
        {
            InitializeComponent();
            LoadInfo();
        }
        DataTable GTable = new DataTable();
        void LoadInfo()
        {
            gvData.DataSource = GTable = Helper.CreateDataTable<Brand>((List<Brand>)new App.BL.BrandsDbService().Read().Content);
        }

        public bool IsValidate()
        {
            bool isOk = true;
            StringBuilder msg = new StringBuilder();

            if (string.IsNullOrEmpty(txtName.Text))
            {
                msg.Append("Make name requred \n");
                isOk = false;
            }
            if (isOk == false)
            {
                Helper.ErrorMessage(message: "Information");
            }
            return isOk;

        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation()) { return; }
            if (!IsValidate()) { return; }
            try
            {
                var x = new App.BL.BrandsDbService().Create(new Brand
                {
                    Discription = txtDiscription.Text,
                    Name = txtName.Text
                });
                LoadInfo();
                Clear();
                Helper.SuccessMessage("Brand create is success");
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation()) { return; }
            if (!IsValidate()) { return; }
            try
            {
                var x = new App.BL.BrandsDbService().Update(new Brand
                {
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
            if (!Helper.Confirmation()) { return; }
            try
            {
                var x = new App.BL.BrandsDbService().Delete(int.Parse(lblID.Text));
                LoadInfo();
                Clear(); ;
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
            }
            catch (Exception ex) { Helper.ErrorMessage(ex.Message); }
        }
        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
               gvData.DataSource = GTable.Select($"{ lblSearchKey.Text} Like '{txtSearchBy.Text}%'").CopyToDataTable();
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

        private void FrmBrands_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        void Clear()
        {
            txtDiscription.Clear();
            txtName.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            lblID.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnInsert.Enabled = true;
        }

    }
}
