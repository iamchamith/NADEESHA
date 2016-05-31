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
using VWMS.REPORTING;
using VWMS.WS;
using System.IO;
using App.Model;
using App.Dal;
using App.BL;
using App.BL.DbServices;

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
        public FrmCustomers(FrmVehicle objV)
        {
            objVG = objV;
            InitializeComponent();
            btnGo.Visible = true;
            btnNavCus.Visible = false;
            LoadInfo();
        }

        private Reservation objRes = new Reservation();

        public FrmCustomers(Reservation objReservation)
        {
            InitializeComponent();
            objRes = objReservation;
            btnGo.Visible = false;
            btnNavCus.Visible = true;
            LoadInfo();
        }

        List<Customer> objreG = new List<Customer> ();
        EOrderBy orderBy = EOrderBy.Desc;
        void LoadInfo(EOrderBy eOrderBy = EOrderBy.Desc)
        {
            objreG = (List<Customer>)new CustomerDbService().Read().Content;
            gvData.DataSource = (eOrderBy == EOrderBy.Asc) ? objreG.OrderBy(p => p.ID).ToList() : objreG.OrderByDescending(p => p.ID).ToList();
            orderBy = eOrderBy;
        }
 
        public bool IsValidate()
        {
            bool isOk = true;
            StringBuilder msg = new StringBuilder();

            if (string.IsNullOrEmpty(txtName.Text))
            {
                msg.Append("Customer name requred \n");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                msg.Append("Address is requred \n");
                isOk = false;

            }
            if (string.IsNullOrEmpty(txtNIC.Text))
            {
                msg.Append("NIC requred \n");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                msg.Append("Email requred \n");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                msg.Append("Phone no requred \n");
                isOk = false;
            }
            if (!BL.BL.HELPER.Validation.IsTelephone(txtPhone.Text))
            {
                msg.Append("invalied Phone no r \n");
                isOk = false;
            }
           
            if (!BL.BL.HELPER.Validation.IsValidEmail(txtEmail.Text))
            {
                msg.Append("Invalid Email \n");
                isOk = false;
            }
            if (!BL.BL.HELPER.Validation.IsTelephone(txtPhone.Text) || !BL.BL.HELPER.Validation.IsNumber(txtPhone.Text))
            {
                msg.Append("Invalid Phone no \n");
                isOk = false;
            }

            if (isOk == false)
            {
                Helper.ErrorMessage(message:msg.ToString());
            }

            return isOk;

        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation()){
                return;}

            if (!IsValidate()){
                return;
            }

            var x = new CustomerDbService().Create(new Customer
            {
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                Name = txtName.Text,
                Nic = txtName.Text,
                Phone = txtPhone.Text,
                RegDate = DateTime.Today,
                UserEmale = Properties.Settings.Default.EMAIL,
                Url = (IsImageChange) ? SaveImage(): "no.jpg"
            });

            if (x.State)
            {
                btnClear.PerformClick();
                LoadInfo();
                MessageBox.Show("customer registration is success");
            }
            else
            {
                MessageBox.Show(x.Exception.Message);
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

            var x = new CustomerDbService().Update(new Customer
            {
                ID = int.Parse(lblID.Text),
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                Name = txtName.Text,
                Nic = txtName.Text,
                Phone = txtPhone.Text,
                RegDate = DateTime.Today,
                UserEmale = Properties.Settings.Default.EMAIL,
                Url = (IsImageChange) ? SaveImage() : imageURL
            });

            if (x.State)
            {
                LoadInfo();
                MessageBox.Show("customer update is success");
            }
            else
            {
                MessageBox.Show(x.Exception.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            {
                return;
            }
            var x = new CustomerDbService().Delete(int.Parse(lblID.Text));

            if (x.State)
            {
                LoadInfo();
                MessageBox.Show("customer update is success");
            }
            else
            {
                MessageBox.Show(x.Exception.Message);
            }
        }

        
        string SaveImage()
        {
            imageURL = Guid.NewGuid().ToString() + Path.GetExtension(openFileDialog1.FileName);
            pictureBox1.Image.Save(Pathss.FilePath + imageURL);
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
                    pictureBox1.Image = Image.FromFile(BL.MODEL.Pathss.FilePath + dr.Cells["URL"].Value.ToString());
                    imageURL = dr.Cells["URL"].Value.ToString();
                }
                catch
                {
                    pictureBox1.Image = Image.FromFile(BL.MODEL.Pathss.FilePath + "no.jpg");
                    imageURL = "no.jpg";
                }
            }
            catch {
                Helper.ErrorMessage("invalied row selected");
            }

        }

        object X = null;
        string imageURL = "no.jpg";
        bool IsImageChange = false;
        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            gvData.DataSource = Utiliry.CreateDataTable<Customer>(objreG).Select(string.Format("{0} like '{1}%'", lblSearchKey.Text, txtSearchBy.Text)).CopyToDataTable();
        }

        Func<BrandsModel, bool> searchPre = null;
        string SearchKey = string.Empty;
        int col = 0;
        private void gvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex==0)
            {
                LoadInfo((orderBy == EOrderBy.Asc) ? EOrderBy.Desc : EOrderBy.Asc);
            }
            SearchKey = gvData.Columns[e.ColumnIndex].Name;
            lblSearchKey.Text = string.Format("{0} ", SearchKey);
            col = e.ColumnIndex;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            objVG.LoadCustomer(Utiliry.CreateDataTable<Customer>(objreG).Select(string.Format("ID = " + lblID.Text + "")).CopyToDataTable());
            this.Close();
        }

        private void lblSearchKey_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            REPORTING.FrmReport objReport = new FrmReport(EReports.Customers,0);
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
            pictureBox1.Image = Image.FromFile(Pathss.FilePath + "no.jpg");
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
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
