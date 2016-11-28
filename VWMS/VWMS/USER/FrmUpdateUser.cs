using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Model;
using App.Dal;
using App.BL;
using BL.BL.HELPER;

namespace VWMS.USER
{
    public partial class FrmUpdateUser : Form
    {
        public FrmUpdateUser()
        {
            InitializeComponent();
            LoadInfo();
        }
        public bool IsValidate()
        {
            bool isOk = true;
            StringBuilder msg = new StringBuilder();

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                msg.Append("Username(Email) requred. \n");
                isOk = false;
            }
            if (!Validation.IsValidEmail(txtUserName.Text))
            {
                msg.Append("Invalied Username(Email).\n");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                msg.Append("Name requred \n");
                isOk = false;
            }
            if (!Validation.IsNIC(txtNIC.Text))
            {
                msg.Append("Invalied Nic\n");
                isOk = false;
            }
            if (isOk == false)
            {
                Helper.ErrorMessage(msg.ToString(), "Information");
            }
            return isOk;

        }
        private void btnSave_Click(object sender, EventArgs e)
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
                new UserDbService().Register(new User
                {
                    Email = txtUserName.Text,
                    Name = txtName.Text,
                    Nic = txtNIC.Text,
                    Password = txtUserName.Text,
                    State = cmbUserType.SelectedIndex + 1
                });
                LoadInfo();
                Helper.SuccessMessage();
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        void LoadInfo()
        {
            gvusers.DataSource = (List<UserViewModel>)new UserDbService().Selectuser().Content;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            {
                return;
            }
            try
            {
                var x = new UserDbService().UpdateUser(new User()
                {
                    Email = txtUserName.Text,
                    Name = txtName.Text,
                    Nic = txtNIC.Text,
                    State = cmbUserType.SelectedIndex + 1
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
            MessageBox.Show("user canot be deleted");
        }

        private void gvusers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (gvusers.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() == "4")
                {
                    MessageBox.Show("this user act as deleted.you cant update."); return;
                }

                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnSave.Enabled = false;
                txtUserName.Enabled = false;
                DataGridViewRow dr = gvusers.Rows[e.RowIndex];
                txtUserName.Text = dr.Cells["EMAIL"].Value.ToString();
                txtName.Text = dr.Cells["NAME"].Value.ToString();
                txtNIC.Text = dr.Cells["NIC"].Value.ToString();
                cmbUserType.SelectedIndex = int.Parse(dr.Cells["STATE"].Value.ToString()) - 1;
            }
            catch { }
        }

        private void FrmUpdateUser_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNIC.Clear();
            txtName.Clear();
            txtUserName.Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtUserName.Enabled = true;

        }
 
    }
}
