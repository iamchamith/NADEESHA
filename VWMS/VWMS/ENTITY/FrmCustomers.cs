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
using VWMS.WS;
using System.IO;
using App.Model;
using App.Dal;
using App.BL;
using App.BL.DbServices;
using static App.Model.Enums;

namespace VWMS.ENTITY
{
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            InitializeComponent();
            LoadInfo();
        }

        private FrmVehicle objVG = new FrmVehicle();
        DataTable objreG = new DataTable();
        public FrmCustomers(FrmVehicle objV)
        {
            objVG = objV;
            InitializeComponent();
            btnGo.Visible = true;
            btnNavCus.Visible = false;
            LoadInfo();
        }
     
        void LoadInfo()
        {
            gvData.DataSource = objreG = Helper.CreateDataTable<Customer>((List<Customer>)new CustomerDbService().Read().Content);
        }

        public bool IsValidate()
        {
            bool isOk = true;
            StringBuilder msg = new StringBuilder();

            if (string.IsNullOrEmpty(txtName.Text))
            {
                msg.Append("Customer name required \n");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                msg.Append("Address is required \n");
                isOk = false;

            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                msg.Append("Email required \n");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                msg.Append("Phone no required \n");
                isOk = false;
            }
            if (!BL.BL.HELPER.Validation.IsTelephone(txtPhone.Text))
            {
                msg.Append("invalied Phone no  \n");
                isOk = false;
            }

            if (!BL.BL.HELPER.Validation.IsValidEmail(txtEmail.Text))
            {
                msg.Append("Invalid Email \n");
                isOk = false;
            }
            if (!BL.BL.HELPER.Validation.IsNIC(txtNIC.Text))
            {
                msg.Append("Invalid Nic \n");
                isOk = false;
            }

            if (isOk == false)
            {
                Helper.ErrorMessage(message: msg.ToString());
            }

            return isOk;

        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation()) { return; }

            if (!IsValidate())
            {
                return;
            }
            try
            {
                var x = new CustomerDbService().Create(new Customer
                {
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    Name = txtName.Text,
                    Nic = txtName.Text,
                    Phone = txtPhone.Text,
                    RegDate = DateTime.Today,
                    UserEmale = Properties.Settings.Default.EMAIL,
                    Url = (IsImageChange) ? SaveImage() : "no.jpg"
                });
                btnClear.PerformClick();
                LoadInfo();
                MessageBox.Show("customer registration is success");
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
                var x = new CustomerDbService().Update(new Customer
                {
                    ID = int.Parse(lblID.Text),
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    Name = txtName.Text,
                    Nic = txtNIC.Text,
                    Phone = txtPhone.Text,
                    RegDate = DateTime.Today,
                    UserEmale = Properties.Settings.Default.EMAIL,
                    Url = (IsImageChange) ? SaveImage() : imageURL
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
                var x = new CustomerDbService().Delete(int.Parse(lblID.Text));
                LoadInfo();
                Helper.SuccessMessage();
                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex);
            }
        }


        string SaveImage()
        {
            imageURL = Guid.NewGuid().ToString() + Path.GetExtension(openFileDialog1.FileName);
            pictureBox1.Image.Save(Helper.FilePath + imageURL);
            return imageURL;
        }

        private void gvData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = gvData.Rows[e.RowIndex];

                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnInsert.Enabled = false;
                lblID.Text = dr.Cells["ID"].Value.ToString();
                txtName.Text = dr.Cells["NAME"].Value.ToString();
                txtNIC.Text = dr.Cells["NIC"].Value.ToString();
                txtEmail.Text = dr.Cells["EMAIL"].Value.ToString().Replace("#", "@");
                txtAddress.Text = dr.Cells["ADDRESS"].Value.ToString();
                txtPhone.Text = dr.Cells["PHONE"].Value.ToString();
                try
                {
                    pictureBox1.Image = Image.FromFile(Helper.FilePath + dr.Cells["URL"].Value.ToString());
                    imageURL = dr.Cells["URL"].Value.ToString();
                }
                catch
                {
                    pictureBox1.Image = Image.FromFile(Helper.FilePath + "no.jpg");
                    imageURL = "no.jpg";
                }
            }
            catch
            {
                Helper.ErrorMessage("invalied row selected");
            }

        }

        object X = null;
        string imageURL = "no.jpg";
        bool IsImageChange = false;
        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                gvData.DataSource = objreG.Select(string.Format("{0} like '{1}%'", lblSearchKey.Text, txtSearchBy.Text)).CopyToDataTable();
            }
            catch {
                if (string.IsNullOrEmpty(txtSearchBy.Text))
                {
                    LoadInfo();
                }
                else
                {
                    gvData.DataSource = null;
                }
               
            }
        }
        private void gvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lblSearchKey.Text = string.Format("{0} ", gvData.Columns[e.ColumnIndex].Name);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            objVG.LoadCustomer(objreG.Select(string.Format("ID = " + lblID.Text + "")).CopyToDataTable());
            this.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            REPORTING.FrmReport objReport = new FrmReport(EReports.Customers, 0);
            objReport.ShowDialog();
        }

        private void FrmCustomers_Load(object sender, EventArgs e)
        {

            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnInsert.Enabled = true;
            txtAddress.Clear();
            txtName.Clear();
            lblID.Text = "0";
            txtNIC.Clear();
            txtEmail.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            imageURL = "no.jpg";
            IsImageChange = false;
            pictureBox1.Image = Image.FromFile(Helper.FilePath + "no.jpg");
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                IsImageChange = true;
            }
        }
    }
}
