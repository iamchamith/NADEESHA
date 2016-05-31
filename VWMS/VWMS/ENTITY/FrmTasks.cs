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
using VWMS.WS;
using App.Model;
using App.Dal;
using App.BL;

namespace VWMS.ENTITY
{
    public partial class FrmTasks : Form
    {
        public FrmTasks()
        {
            InitializeComponent();
            LoadInfo();
        }

        private FRMWS objVG = new FRMWS();
        public FrmTasks(FRMWS objv)
        {
            objVG = objv;
            InitializeComponent();
            LoadInfo();
            btnGo.Visible = true;
        }
        List<App.Model.Task> g = new List<App.Model.Task>();
        void LoadInfo()
        {
            gvData.DataSource = g = (List<App.Model.Task>)new TaskDbService().Read().Content;
        }
        public bool IsValidate()
        {
            bool isOk = true;
            StringBuilder msg = new StringBuilder();
            if (string.IsNullOrEmpty(txtName.Text))
            {
                msg.Append("Task Name required \n");
                isOk = false;
            }
            if (isOk == false)
            {
                MessageBox.Show(msg.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return isOk;

        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation()){
                return;
            }
            if (!IsValidate()) {
                return;
            }
            var x = new TaskDbService().Create(new App.Model.Task
            {
                Discription = txtDiscription.Text,
                TaskName = txtName.Text
            });
            if (x.State)
            {
                LoadInfo();
                MessageBox.Show("update is success");
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
            var x = new TaskDbService().Update(new App.Model.Task
            {
                Discription = txtDiscription.Text,
                ID = int.Parse(lblID.Text),
                TaskName = txtName.Text
            });
            if (x.State)
            {
                LoadInfo();
                MessageBox.Show("update is success");
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
            var x = new TaskDbService().Delete(int.Parse(lblID.Text));
            if (x.State)
            {
                btnClear.PerformClick();
                LoadInfo();
                MessageBox.Show("update is success");
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
                DataGridViewRow dr = gvData.Rows[e.RowIndex];
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnInsert.Enabled = false;
       
                lblID.Text = dr.Cells["ID"].Value.ToString();
                txtName.Text = dr.Cells["taskName"].Value.ToString();
                txtDiscription.Text = dr.Cells["Discription"].Value.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        object X = null;
        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
        }

        Func<TaskModel, bool> searchPre = null;
        string SearchKey = string.Empty;
        private void gvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            objVG.LoadTaskInfo(int.Parse(lblID.Text), txtDiscription.Text,txtName.Text);
            this.Close();
        }

        private void lblSearchKey_Click(object sender, EventArgs e)
        {
        }

        private void FrmTasks_Load(object sender, EventArgs e)
        {

            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnInsert.Enabled = true;
            txtDiscription.Clear();
            txtName.Clear();

            lblID.Text = "0";
        }
        
        
    }
}
