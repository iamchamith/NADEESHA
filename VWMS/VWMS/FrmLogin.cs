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

namespace VWMS
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userobj = new User
            {
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text
            };
            string message = string.Empty;
            if (!IsValied(userobj,out message))
            {
                Helper.ErrorMessage(message:message); return;
            }

            var x = new UserDbService().Login(userobj);

            if (x.State)
            {
                var xx = (User)x.Content;
                Properties.Settings.Default.EMAIL = txtEmail.Text.Trim();
                Properties.Settings.Default.NAME = xx.Name;
                Properties.Settings.Default.STATE = ((int)xx.State).ToString();
                FrmMain obj = new FrmMain();
                obj.Show();
                this.Hide();
            }
            else {

                Helper.ErrorMessage(message: x.Exception.Message);
            }
        }

        //validation 
        bool IsValied(User obj,out string messageOut) {

            bool isValied = true;
            StringBuilder message = new StringBuilder();
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                isValied = false;
                message.Append("email requred \n");
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                isValied = false;
                message.Append("password requred \n");
            }

            messageOut = message.ToString();
            return isValied;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
 
    }
}
