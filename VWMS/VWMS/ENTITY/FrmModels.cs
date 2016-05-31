using App.BL;
using App.BL.DbServices;
using App.Model;
using BL.BL;
using BL.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using b = App.BL;
using d = App.Dal;
using m = App.Model;
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

        EOrderBy orderBy = EOrderBy.Desc;
        List<Model> objreG = new List<App.Model.Model>();
        void LoadInfo(EOrderBy eorderBy = EOrderBy.Desc)
        {
            objreG = (List<m.Model>)new ModelDbService().Read().Content;
            gvData.DataSource = (eorderBy == EOrderBy.Asc) ?
                objreG.OrderBy(p => p.ID).ToList() : objreG.OrderByDescending(p => p.ID).ToList();
            orderBy = eorderBy;
        }

        public bool IsValidate()
        {
            bool isOk = true;
            StringBuilder msg = new StringBuilder();
            if (cmbBrands.SelectedIndex==-1)
            {
                msg.Append("Brand Name is required \n");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                msg.Append("Model Code required \n");
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
            if (!Helper.Confirmation()){
                return;
            }
            if (!IsValidate()){
                return;
            }

            var x = new ModelDbService().Create(new Model
            {
                BrandId = int.Parse(cmbBrands.SelectedValue.ToString()),
                Discription = txtDiscription.Text,
                Name = txtName.Text
            });

            if (x.State)
            {
                LoadInfo();
                MessageBox.Show("create is success");
            }
            else
            {
                MessageBox.Show(x.Exception.Message);
            }
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation()){
                return;
            }
            if (!IsValidate()) {
                return;
            }
            var x = new ModelDbService().Update(new Model
            {
                BrandId = int.Parse(cmbBrands.SelectedValue.ToString()),
                Discription = txtDiscription.Text,
                Name = txtName.Text,
                ID = int.Parse(lblID.Text)
            });

            if (x.State){
                LoadInfo();
                MessageBox.Show("create is success");
            }
            else{
                MessageBox.Show(x.Exception.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            {
                return;
            }
            var x = new ModelDbService().Delete(int.Parse(lblID.Text));

            if (x.State)
            {
                MessageBox.Show("delete is success");
            }
            else
            {
                MessageBox.Show(x.Exception.Message);
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
                cmbBrands.SelectedValue = dr.Cells["BrandId"].Value.ToString();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }

        }

        object X = null;
        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var searchBrands = new List<Model>();
                X = txtSearchBy.Text.Trim().ToLower();
                if (lblSearchKey.Text.ToLower().StartsWith("i"))
                {
                    searchBrands = objreG.Where(p => p.ID.ToString().ToLower().StartsWith(X.ToString())).ToList();
                }
                else if (lblSearchKey.Text.ToLower().StartsWith("n"))
                {
                    searchBrands = objreG.Where(p => p.Name.ToString().ToLower().StartsWith(X.ToString())).ToList();
                }
                else
                {
                    searchBrands = objreG.Where(p => p.Discription.ToString().ToLower().StartsWith(X.ToString())).ToList();
                }

                gvData.DataSource = searchBrands;
            }
            catch (Exception EX)
            {
                LoadInfo();
            }
        }

        string SearchKey = string.Empty;
        private void gvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex==0)
            {
                LoadInfo((orderBy== EOrderBy.Asc)?EOrderBy.Desc:EOrderBy.Asc);
            }

            SearchKey = gvData.Columns[e.ColumnIndex].Name;
            lblSearchKey.Text = string.Format("{0}", SearchKey);
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
