using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL.BL;
using BL.MODEL;
using VWMS.Properties;
using System.Data;
using VWMS.REPORTING;
using VWMS.WS;
using App.BL;
using App.Model;
using App.BL.DbServices;
using System.Collections.Generic;
namespace VWMS.ENTITY
{
    public partial class FrmLabour : Form
    {
        private readonly object X = null;
        private string SearchKey = string.Empty;
        private ReturnObject objreG;
        private Func<BrandsModel, bool> searchPre;

        public FrmLabour()
        {
            InitializeComponent();
            LoadInfo();
            LoadTypes();
        }

        FRMWS objG = new FRMWS();
        public FrmLabour(FRMWS obj)
        {
            InitializeComponent();
            LoadInfo();
            LoadTypes();
            objG = obj;
            btnGO.Visible = true;
        }

        private void LoadTypes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NAME");

            dt.Rows.Add("1", "TECHNICIAN");
            dt.Rows.Add("2", "SERVICE_ADVISOR");
            dt.Rows.Add("3", "TEAM_LEAD");

            cmbTypes.ValueMember = "ID";
            cmbTypes.DisplayMember = "NAME";
            cmbTypes.DataSource = dt;
        }

        List<LabourViewModel> dtG = new List<LabourViewModel>();
        EOrderBy orderBy = EOrderBy.Desc;
        void LoadInfo(EOrderBy eOrderBy = EOrderBy.Desc)
        {
            gvData.DataSource = dtG = (List<LabourViewModel>)new LaboursDbService().Read().Content;

        }

        public bool IsValidate()
        {
            bool isOk = true;
            StringBuilder msg = new StringBuilder();

            if (string.IsNullOrEmpty(txtName.Text))
            {
                msg.Append("Name required \n");
                isOk = false;
            }
            if (cmbTypes.SelectedIndex == -1)
            {
                msg.Append("Enrollment Type is required \n");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtNIC.Text))
            {
                msg.Append("NIC required \n");
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
                var x = new LaboursDbService().Create(new LabourViewModel
                {
                    Discription = txtDiscription.Text,
                    Name = txtName.Text,
                    Nic = txtNIC.Text,
                    Type = int.Parse(cmbTypes.SelectedValue.ToString()),
                    UserEmail = Properties.Settings.Default.EMAIL

                });

                LoadInfo();
                Helper.SuccessMessage();
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
            try
            {
                var x = new LaboursDbService().Update(new LabourViewModel
                {
                    ID = int.Parse(lblID.Text),
                    Discription = txtDiscription.Text,
                    Name = txtName.Text,
                    Nic = txtNIC.Text,
                    Type = int.Parse(cmbTypes.SelectedValue.ToString()),
                    UserEmail = Properties.Settings.Default.EMAIL

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
                var x = new LaboursDbService().Delete(int.Parse(lblID.Text));
                btnClear.PerformClick();
                LoadInfo();
                Helper.SuccessMessage();

            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
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
                txtName.Text = dr.Cells["NAME"].Value.ToString();
                txtDiscription.Text = dr.Cells["Discription"].Value.ToString();
                cmbTypes.SelectedValue = dr.Cells["TYPE"].Value.ToString();
                txtNIC.Text = dr.Cells["NIC"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                gvData.DataSource = Utiliry.CreateDataTable<LabourViewModel>(dtG).Select(string.Format("{0} like '{1}%'", lblSearchKey.Text, txtSearchBy.Text)).CopyToDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SearchKey = gvData.Columns[e.ColumnIndex].Name;
            lblSearchKey.Text = string.Format("{0}", SearchKey);
            if (e.ColumnIndex == 0)
            {
                LoadInfo((orderBy == EOrderBy.Asc) ? EOrderBy.Desc : EOrderBy.Asc);
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            objG.LoadLabour(lblID.Text, txtName.Text);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            REPORTING.FrmReport objReport = new FrmReport(EReports.Labours, 0);
            objReport.ShowDialog();
        }

        private void FrmLabour_Load(object sender, EventArgs e)
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
            txtNIC.Clear();
            txtName.Clear();
            txtDiscription.Clear();
            cmbTypes.SelectedIndex = 0;
            lblID.Text = "0";
        }
    }
}
