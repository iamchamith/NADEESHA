﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VWMS.REPORTING;
using VWMS.WS;
using System.IO;
using App.BL;
using App.Dal;
using App.Model;
using App.BL.DbServices;
using static App.Model.Enums;

namespace VWMS.ENTITY
{
    public partial class FrmVehicle : Form
    {
        public FrmVehicle()
        {
            InitializeComponent();
            LoadModels();
            LoadBrands();
            LoadInfoVehicle();
        }
        FRMWS objG = new FRMWS();
        public FrmVehicle(FRMWS obj)
        {
            InitializeComponent();
            LoadBrands();
            LoadModels();
            LoadInfoVehicle();
            btnGO.Visible = true;
            btnNavReser.Visible = false;
            objG = obj;
        }
        #region register tab
        private void LoadBrands()
        {
            // ID, NAME
            List<Brand> data = (List<Brand>)new BrandsDbService().Read().Content;
            cmbBrands.ValueMember = "ID";
            cmbBrands.DisplayMember = "NAME";
            cmbBrands.DataSource = data;
        }

        private List<Model> lst = new List<Model>();
        private void LoadModels()
        {
            lst = (List<Model>)new ModelDbService().Read().Content;
        }

        private void cmbBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbModels.ValueMember = "ID";
                cmbModels.DisplayMember = "NAME";
                cmbModels.DataSource = lst.Where(p => p.BrandId == int.Parse(cmbBrands.SelectedValue.ToString())).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                var x = new VehicleDbService().Update(new Vehicle
                {
                    BrandID = int.Parse(cmbBrands.SelectedValue.ToString()),
                    ChassiNumber = txtChassiNumber.Text,
                    Discription = txtDiscription.Text,
                    EngineNumber = txtEngineNo.Text,
                    ModelId = int.Parse(cmbModels.SelectedValue.ToString()),
                    OwnerID = int.Parse(lblOwnerID.Text),
                    RegDate = DateTime.Today,
                    UserEmail = Properties.Settings.Default.EMAIL,
                    VehicleID = txtVehicleNumber.Text,
                    Url = IsImageChange ? SaveImage() : imageName

                });
                LoadInfoVehicle();
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
                var x = new VehicleDbService().Delete(txtVehicleNumber.Text);
                btnClear.PerformClick();
                LoadInfoVehicle();
                Helper.SuccessMessage();
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex);
            }
        }


        private void lnkOwner_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomers obj = new FrmCustomers(this);
            obj.ShowDialog();
        }

        public void LoadCustomer(DataTable cus)
        {
            // ID, NAME, PHONE, ADDRESS, EMAIL, NIC, USER_EMAIL, REG_DATE, ENABLE
            if (cus == null || cus.Rows.Count == 0)
            {
                MessageBox.Show("invalied customer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Key");
                dt.Columns.Add("Value");

                dt.Rows.Add("ID", cus.Rows[0]["ID"].ToString());
                dt.Rows.Add("NIC", cus.Rows[0]["NIC"].ToString());
                dt.Rows.Add("Name", cus.Rows[0]["NAME"].ToString());
                dt.Rows.Add("Phone", cus.Rows[0]["PHONE"].ToString());
                dt.Rows.Add("URL", cus.Rows[0]["URL"].ToString());
                try
                {
                    string img = cus.Rows[0]["URL"].ToString();
                    pictureBox2.Image = Image.FromFile(Helper.FilePath + img);
                }
                catch
                {

                    pictureBox2.Image = Image.FromFile(Helper.FilePath + "no.jpg");
                }
                dataGridView2.DataSource = dt;
                lblOwnerID.Text = cus.Rows[0]["ID"].ToString();
            }
        }
        List<VehicleViewModel> LstGVehicle = new List<VehicleViewModel>();
        private int taskID = 0;

        void LoadInfoVehicle()
        {
            dataGridView1.DataSource = LstGVehicle = (List<VehicleViewModel>)new VehicleDbService().Read().Content;
        }

        void LoadCustomer(int customerID)
        {
            LoadCustomer(Utiliry.CreateDataTable<Customer>(new List<Customer>() { (Customer)new CustomerDbService().Read(customerID).Content }));
        }

        public bool IsValidate()
        {
            bool isOk = true;
            StringBuilder msg = new StringBuilder();

            if (string.IsNullOrEmpty(txtVehicleNumber.Text))
            {
                msg.Append("Vehicle no required \n");
                isOk = false;
            }
            if (cmbBrands.SelectedIndex == -1)
            {
                msg.Append("Brand Name is required \n");
                isOk = false;
            }
            if (lblOwnerID.Text == "0")
            {
                msg.Append("Owner is required \n");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtChassiNumber.Text))
            {
                msg.Append("Chassi No is required \n");
                isOk = false;

            }
             
            if (isOk == false)
            {
                Helper.ErrorMessage(msg.ToString(), "Validation Errors");
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
                var x = new VehicleDbService().Create(new VehicleViewModel
                {
                    BrandID = int.Parse(cmbBrands.SelectedValue.ToString()),
                    ChassiNumber = txtChassiNumber.Text,
                    Discription = txtDiscription.Text,
                    EngineNumber = txtEngineNo.Text,
                    ModelId = int.Parse(cmbModels.SelectedValue.ToString()),
                    OwnerID = int.Parse(lblOwnerID.Text),
                    RegDate = DateTime.Today,
                    UserEmail = Properties.Settings.Default.EMAIL,
                    VehicleID = txtVehicleNumber.Text,
                    Url = IsImageChange ? SaveImage() : "no.jpg"
                });

                btnClear.PerformClick();
                LoadInfoVehicle();
                Helper.SuccessMessage();

            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }


        #endregion

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnInsert.Enabled = false;
                txtVehicleNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtEngineNo.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtChassiNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDiscription.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                LoadCustomer(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()));
                cmbBrands.SelectedValue = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                cmbModels.SelectedValue = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                try
                {
                    pictureBox1.Image = Image.FromFile(Helper.FilePath + dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
                    imageName = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                }
                catch
                {
                    pictureBox1.Image = Image.FromFile(Helper.FilePath + dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
                    imageName = "no.jpg";
                }
            }
            catch (Exception ex)
            {
            }
        }

        string imageName = string.Empty;
        private void btnGO_Click(object sender, EventArgs e)
        {
            objG.LoadVehicleNumber(txtVehicleNumber.Text, ImageURL);
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            REPORTING.FrmReport objReport = new FrmReport(EReports.Vehicle, 0);
            objReport.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnInsert.Enabled = true;
                txtVehicleNumber.Clear();
                txtEngineNo.Clear();
                txtChassiNumber.Clear();
                txtDiscription.Clear();
                cmbBrands.SelectedIndex = 0;
                cmbModels.SelectedIndex = 0;
                lblOwnerID.Text = "0";
                dataGridView2.DataSource = null;
                IsImageChange = false;
                ImageURL = "car.jpg";
                pictureBox1.Image = Image.FromFile(Helper.FilePath + "car.png");
                pictureBox2.Image = Image.FromFile(Helper.FilePath + "no.jpg");
            }
            catch (Exception ex) {
                Helper.ErrorMessage(ex.Message);
            }
        }

        private void FrmVehicle_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
        string SearchKey = string.Empty;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SearchKey = dataGridView1.Columns[e.ColumnIndex].Name;
            lblSearchKey.Text = string.Format("{0}", SearchKey);

        }
        object X = null;
        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                X = txtSearchBy.Text.Trim();
                dataGridView1.DataSource = Utiliry.CreateDataTable<VehicleViewModel>(LstGVehicle).Select(string.Format("{0} like '{1}%'", lblSearchKey.Text, X)).CopyToDataTable();
            }
            catch
            {
                LoadInfoVehicle();
            }
        }

        // browse image
        string ImageURL = "car.jpg";
        bool IsImageChange = false;
        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                IsImageChange = true;
            }
        }

        string SaveImage()
        {
            ImageURL = Guid.NewGuid() + Path.GetExtension(openFileDialog1.FileName);
            pictureBox1.Image.Save(Helper.FilePath + ImageURL);
            return ImageURL;
        }

        private void btnNavReser_Click(object sender, EventArgs e)
        {

        }
    }
}
