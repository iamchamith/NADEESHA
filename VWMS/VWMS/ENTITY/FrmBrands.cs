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
        List<Brand> Glst = new List<Brand>();
        EOrderBy orderBy = EOrderBy.Desc;

        void LoadInfo(EOrderBy eOrderBy = EOrderBy.Desc)
        {
            List<Brand> x = (List<Brand>)new App.BL.BrandsDbService().Read().Content;
            gvData.DataSource = (eOrderBy == EOrderBy.Asc) ? x.OrderBy(p => p.ID).ToList() : x.OrderByDescending(p => p.ID).ToList();
            Glst = (List<Brand>)x;
            orderBy = eOrderBy;
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
                Helper.SuccessMessage();
            }
            catch (Exception ex) {
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
            catch { }

        }

        object X = null;
        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var searchBrands = new List<Brand>();
                X = txtSearchBy.Text.Trim().ToLower();
                if (lblSearchKey.Text.ToLower().StartsWith("i"))
                {
                    searchBrands = Glst.Where(p => p.ID.ToString().ToLower().StartsWith(X.ToString())).ToList();
                }
                else if (lblSearchKey.Text.ToLower().StartsWith("n"))
                {
                    searchBrands = Glst.Where(p => p.Name.ToString().ToLower().StartsWith(X.ToString())).ToList();
                }
                else
                {
                    searchBrands = Glst.Where(p => p.Discription.ToString().ToLower().StartsWith(X.ToString())).ToList();
                }

                gvData.DataSource = searchBrands;
            }
            catch (Exception EX)
            {
                LoadInfo();
            }

        }

        Func<BrandsModel, bool> searchPre = null;
        string SearchKey = string.Empty;
        private void gvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                LoadInfo((orderBy == EOrderBy.Asc) ? EOrderBy.Desc : EOrderBy.Asc);
            }

            SearchKey = gvData.Columns[e.ColumnIndex].Name;
            lblSearchKey.Text = string.Format("{0}", SearchKey);

        }

        private void FrmBrands_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDiscription.Clear();
            txtName.Clear();
            lblID.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnInsert.Enabled = true;
        }

    }
}
