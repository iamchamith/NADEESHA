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
using App.BL;
using App.Model;

namespace VWMS.USER
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            { return; }
            //validate here
            if (new UserDbService().ChangePassword(new User
            {
                Email = Properties.Settings.Default.EMAIL,
                Password = txtCurrentPassword.Text
            }, txtNewPassword.Text).State) {

                MessageBox.Show("change password success");
            }
            else
            {
                MessageBox.Show("change password not success");
            }
 

            Reset();
        }

        void Reset() {

            txtNewPassword.Clear();
            txtCOnfirmNewPassword.Clear();
            txtCurrentPassword.Clear();
        }
    }
}
