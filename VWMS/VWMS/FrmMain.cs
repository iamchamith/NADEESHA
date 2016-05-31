using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VWMS.ENTITY;
using BL.MODEL;
using VWMS.USER;
using VWMS.INVENTORY;

namespace VWMS
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            UserInfo();
            SetPrevilage();
        }

        void UserInfo() {
            //error
            /*toolStripMenuItem1.Text = string.Format("hi {0} ({1}) login as {2}",
               Properties.Settings.Default.NAME,
               Properties.Settings.Default.EMAIL,
               ((EUser)int.Parse(Properties.Settings.Default.STATE)).ToString());*/

            toolStripMenuItem1.Text = string.Format("hi {0} ({1}) login as {2}",
               Properties.Settings.Default.NAME,
               Properties.Settings.Default.EMAIL,
               ((EUser)int.Parse(Properties.Settings.Default.STATE)).ToString());
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin obj = new FrmLogin();
            obj.Show();
            this.Hide();
        }

        private void bRANDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBrands obj = new FrmBrands();
            obj.MdiParent = this;
            obj.Show();
        }

        private void mODELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModels obj = new FrmModels();
            obj.MdiParent = this;
            obj.Show();
        }

        private void lABARARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLabour obj = new FrmLabour();
            obj.MdiParent = this;
            obj.Show();
        }

        private void tASKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTasks obj = new FrmTasks();
            obj.MdiParent = this;
            obj.Show();
        }

        private void cUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomers obj = new FrmCustomers();
            obj.MdiParent = this;
            obj.Show();
        }

        private void iTEMSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmItems obj = new FrmItems();
            obj.MdiParent = this;
            obj.Show();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Helper.Confirmation())
            {
                Application.Exit();
            }
        }

        private void wORKSTATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VWMS.WS.FRMWS obj = new VWMS.WS.FRMWS();
            obj.MdiParent = this;
            obj.Show();
        }

        private void cHANGESETTINGSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword obj = new FrmChangePassword();
            obj.MdiParent = this;
            obj.Show();
        }

        private void rEGISTRATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateUser obj = new FrmUpdateUser();
            obj.MdiParent = this;
            obj.Show();
        }

        private void iTEMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmItems obj = new FrmItems();
            obj.MdiParent = this;
            obj.Show();
        }

         
        private void vEHICLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VWMS.ENTITY.FrmVehicle obj = new VWMS.ENTITY.FrmVehicle();
            obj.MdiParent = this;
            obj.Show();
        }

        private void iNVENTORYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VWMS.INVENTORY.FrmInventoryProcess obj = new VWMS.INVENTORY.FrmInventoryProcess();
            obj.MdiParent = this;
            obj.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void rESERVATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var obj = new Reservation();
            obj.MdiParent = this;
            obj.Show();
        }


        void SetPrevilage() {

            EUser UserType = (EUser)int.Parse(Properties.Settings.Default.STATE);

            if (UserType == EUser.Maneger)
            {
                iNVENTORYToolStripMenuItem.Enabled = false;
                rEGISTRATIONToolStripMenuItem.Enabled = false;
                iTEMSToolStripMenuItem1.Enabled = false;
            }
            else if(UserType == EUser.StockKeeper)
            {
                rEGISTRATIONToolStripMenuItem.Enabled = false;
                eNTITYToolStripMenuItem.Enabled = false;
                wORKSTATIONToolStripMenuItem.Enabled = false;
            }
        }
        
    }
}
