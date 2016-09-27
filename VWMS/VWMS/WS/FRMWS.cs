using App.BL;
using App.BL.DbServices;
using App.Model;
//using BL.BL;
//using BL.MODEL;
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

namespace VWMS.WS
{
    public partial class FRMWS : Form
    {
        public FRMWS()
        {
            InitializeComponent();
            lblLabourCharge.Visible = false;
            txtLabourCharge.Visible = false;
        }

        #region jojb
        public void LoadVehicleNumber(string vehicleNumber, string pimageURL)
        {

            lblJobVehicleID.Text = vehicleNumber;
            pictureBox2.Image = Image.FromFile(Helper.FilePath + pimageURL);
            LoadVehicleJobs(vehicleNumber);
        }

        private void btnJobSelectVehicle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                FrmVehicle obj = new FrmVehicle(this);
                obj.ShowDialog();
            }
            catch
            {
                MessageBox.Show("please select the job type");
            }
        }


        public void EnableFunctionsByCurrentJobState()
        {

            if (IsCurrentJobFinished)
            {
                panel1.Enabled = false;
                panel2.Enabled = false;
                panel3.Enabled = false;
            }
            else
            {
                panel1.Enabled = true;
                panel2.Enabled = true;
                panel3.Enabled = true;
            }
        }


        bool IsCurrentJobFinished = true;
        void LoadVehicleJobs(string vehicleNumber)
        {
            var details = (List<VehicleJobViewModel>)new VehicleJobDbService().SelectvehicleJobs(vehicleNumber).Content;
            var table = Helper.CreateDataTable<VehicleJobViewModel>(details);
            dataGridView1.DataSource = table;
            IsCurrentJobFinished = !details.Exists(p => p.IsFinished == (int)Enums.EIsClosed.NotClosed);
        }
        private void btnJobInsert_Click(object sender, EventArgs e)
        {
            //validation
            if (!IsCurrentJobFinished)
            {
                MessageBox.Show("please close current runing job"); return;
            }
            else if (lblJobVehicleID.Text == "0")
            {
                MessageBox.Show("please select vehicle"); return;
            }
            if (!Helper.Confirmation(message: "are you sure ? you cant roll back the job inseterd"))
            {
                return;
            }

            try
            {
                new VehicleJobDbService().CreateVehicleJob(new App.Model.VehicleJobViewModel
                {
                    IsFinished = (int)Enums.EIsClosed.NotClosed,
                    FinalAmount = 0.00,
                    OpenDate = DateTime.Now,
                    CloseTime = DateTime.Now,
                    VehicleNumber = lblJobVehicleID.Text,
                    UserEmail = Properties.Settings.Default.EMAIL
                });
                LoadVehicleJobs(lblJobVehicleID.Text);
                Helper.SuccessMessage(message: "job creation is success");
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }


        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (lblJobID.Text == "0" || string.IsNullOrEmpty(lblJobID.Text))
            {
                Helper.ErrorMessage("please select valied vehicle job"); return;
            }

            LoadJobTasks();
            tabControl1.SelectedIndex = 1;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                lblJobID.Text = lblTaskJobID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                IsCurrentJobFinished = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["IsFinished"].Value.ToString()) == 1 ? false : true;
                EnableFunctionsByCurrentJobState();
                btnJobUpdate.Enabled = !IsCurrentJobFinished;
            }
            catch
            {

            }
        }
        #endregion

        #region task
        private void btnLoadTask_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmTasks obj = new FrmTasks(this);
            obj.ShowDialog();
        }

        public void LoadTaskInfo(int tid, string description, string name)
        {

            lblTaskId.Text = tid.ToString();
            lblTaskName.Text = name;
            txtTaskDiscription.Text = description;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            {
                return;
            }
            try
            {
                new VehicleJobTaskDbService().CreateVehicleJobTask(new VehicleJobTaskViewModel
                {
                    Date = DateTime.Today,
                    Discription = txtTaskDiscription.Text,
                    TaskId = int.Parse(lblTaskId.Text),
                    JobId = int.Parse(lblTaskJobID.Text),
                    IsClosed = (int)Enums.EIsClosed.NotClosed,
                    UserEmail = Properties.Settings.Default.EMAIL,
                    TaskCost = 0
                });
                LoadJobTasks();
                Helper.SuccessMessage();
            }
            catch (Exception ex) { Helper.ErrorMessage(ex.Message); }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Helper.Confirmation())
            {
                try
                {
                    new VehicleJobTaskDbService().DeleteVehicleTasks(int.Parse(lblJobTaskID.Text));
                    LoadJobTasks();
                    Helper.SuccessMessage();
                }
                catch (Exception ex)
                {
                    Helper.ErrorMessage(ex);
                }
            }

        }
        public void ResetTaskAllocation()
        {
            lblJobTaskID.Text = "0";
            lblTaskJobID.Text = "0";
            lblTaskId.Text = "0";
            lblTaskName.Text = "TASK NAME";
            txtLabourCharge.Text = "0";
            txtTaskDiscription.Text = "";
        }


        void LoadJobTasks()
        {
            try
            {
                gvTask.DataSource = Helper.CreateDataTable<VehicleJobTaskViewModel>((List<VehicleJobTaskViewModel>)
                    new VehicleJobTaskDbService().SelectVehicleTask(int.Parse(lblJobID.Text)).Content);
            }
            catch (Exception ex) { Helper.ErrorMessage(ex); }
        }
        private void gvTask_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                lbltasksID.Text = lbJobTaskId.Text = lblJobTaskID.Text = gvTask.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblTaskJobID.Text = gvTask.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblTaskId.Text = gvTask.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTaskDiscription.Text = gvTask.Rows[e.RowIndex].Cells[3].Value.ToString();
                lblTaskName.Text = ((TaskViewModel)(new TaskDbService().Read(int.Parse(lblTaskId.Text)).Content)).TaskName;
                if (lblTaskId.Text == "TASK")
                {
                    MessageBox.Show("please select TaskId");
                    return;
                }
                if (lblTaskJobID.Text == "")
                {
                    MessageBox.Show("invalied row selected"); return;
                }
                LoadTaskLabours(lblJobTaskID.Text);
                LoadMaterials(lblJobTaskID.Text);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblJobTaskID.Text == "0")
            {
                MessageBox.Show("Please select job task before navigation");
                return;
            }
            tabControl1.SelectedIndex = 2;
        }


        #endregion


        #region labour


        private void btnLoadLabour_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLabour obj = new FrmLabour(this);
            obj.ShowDialog();
        }

        private void btnTaskLaboburInsert_Click(object sender, EventArgs e)
        {
            if (lblTaskLabourEmpID.Text == "0")
            {
                MessageBox.Show("please select Labour Id");
                return;
            }
            try
            {

                var x = new VehicleJobTaskLabourDbService().CreateVehicleJobTaskLaborur(new VehicleJobTaskLabourViewModel
                {
                    LabourId = int.Parse(lblTaskLabourEmpID.Text),
                    TaskId = int.Parse(lbJobTaskId.Text),
                    Discription = txtTaskLabourDiscription.Text,
                    UserEmail = Properties.Settings.Default.EMAIL,
                    OpenDateTime = DateTime.Now,
                    IsClosed = (int)Enums.EIsClosed.NotClosed
                });
                LoadTaskLabours(lbJobTaskId.Text);
                Helper.SuccessMessage();
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(message: ex.Message);
            }
        }

        private void ResetLabourTaskAllocation()
        {

            lblTaskLabourName.Text = "name";
            lblTaskLabourEmpID.Text = "0";
            txtTaskLabourDiscription.Text = "";
            lblTaskLabourID.Text = "0";
        }

        private void btnTaskLaboburUpdate_Click(object sender, EventArgs e)
        {

            if (!Helper.Confirmation())
            {
                return;
            }
            try
            {
                var x = new VehicleJobTaskLabourDbService().UpdatevehicleTaskLaborur(new VehicleJobTaskLabourViewModel
                {
                    CloseDateTime = DateTime.Today,
                    Discription = txtTaskLabourDiscription.Text,
                    IsClosed = (int)Enums.EIsClosed.Closed,
                    LabourId = Convert.ToInt32(lblTaskLabourEmpID.Text),
                    ID = Convert.ToInt32(lblTaskLabourID.Text)
                });
                Helper.SuccessMessage();
                LoadTaskLabours(lbJobTaskId.Text);
            }
            catch (Exception ex) { Helper.ErrorMessage(ex); }

        }

        private void btnTaskLaboburDelete_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            { return; }
            try
            {
                var x = new VehicleJobTaskLabourDbService().DeleteVehicleTasksLabourur(Convert.ToInt32(lblTaskLabourID.Text));
                Helper.SuccessMessage();
                LoadTaskLabours(lbJobTaskId.Text);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex);
            }

        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                lblTaskLabourID.Text = gvLabours.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblTaskLabourEmpID.Text = gvLabours.Rows[e.RowIndex].Cells[2].Value.ToString();
                lblTaskLabourName.Text = ((LabourViewModel)(new LaboursDbService().Read(int.Parse(gvLabours.Rows[e.RowIndex].Cells[2].Value.ToString())).Content)).Name;
                txtTaskLabourDiscription.Text = gvLabours.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void LoadLabour(string empID, string name)
        {

            lblTaskLabourEmpID.Text = empID;
            lblTaskLabourName.Text = name;
        }

        void LoadTaskLabours(string taskID)
        {
            try
            {
                gvLabours.DataSource = Helper.CreateDataTable<VehicleJobTaskLabourViewModel>((List<VehicleJobTaskLabourViewModel>)new VehicleJobTaskLabourDbService().SelectVehicleTasklaburur(int.Parse(taskID)).Content);
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }

        }

        void LoadMaterials(string taskID)
        {
            gvMaterials.DataSource = Helper.CreateDataTable<VehicleJobTaskItemViewModel>((List<VehicleJobTaskItemViewModel>)(new VehicleJobTaskItemDbService().SelectJobTaskItem(int.Parse(taskID)).Content));

        }
        #endregion

        private void btnLoadItems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ENTITY.FrmItems obj = new ENTITY.FrmItems(this);
            obj.ShowDialog();
        }

        public void LoadItemInfo(string id, string name, string qantity, string outprice)
        {

            lblItemsID.Text = id;
            lblItemName.Text = name;
            lblAvaiableQuantity.Text = qantity;
            lblItemPrice.Text = outprice;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            bool isInvaliedNavigation = false;
            if (tabControl1.SelectedIndex == 1)
            {
                isInvaliedNavigation = true;
                tabControl1.SelectedIndex = 0;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                isInvaliedNavigation = true;
                tabControl1.SelectedIndex = 0;
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                isInvaliedNavigation = true;
                tabControl1.SelectedIndex = 0;
            }

            if (isInvaliedNavigation)
            {
                MessageBox.Show("Use Wizard buttions for navigation");
            }
        }
        int taskId = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (lblJobTaskID.Text == "0")
            {
                MessageBox.Show("Please select job task before navigation"); return;
            }
            tabControl1.SelectedIndex = 3;
        }

        int updateQuantityFinal = 0;
        int updateQuantityOld = 0;
        private void button5_Click(object sender, EventArgs e)
        {
        }

        void ClearMatirialIssue()
        {

            lblItemsID.Text = "0";
            lblItemName.Text = "item name";
            lblItemPrice.Text = "0";
            lblAvaiableQuantity.Text = "0";
            txtQuantity.Value = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int availableqty = Convert.ToInt32(lblAvaiableQuantity.Text);
                int qty = Convert.ToInt32(txtQuantity.Text);

                try
                {
                    new VehicleJobTaskItemDbService().CreateJobTaskItem(new VehicleJobTaskItemViewModel
                    {
                        ItemId = int.Parse(lblItemsID.Text),
                        Price = double.Parse(lblItemPrice.Text),
                        Quantity = Convert.ToInt32(txtQuantity.Value),
                        UserEmail = Properties.Settings.Default.EMAIL,
                        RegDate = DateTime.Now,
                        TaskId = int.Parse(lbltasksID.Text)
                    });
                    LoadMaterials(lbltasksID.Text);
                    Helper.SuccessMessage();
                }
                catch (Exception ex)
                {
                    Helper.ErrorMessage(ex.Message);
                }

            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        void ResetSellingItems()
        {
            lblItemsID.Text = "0";
            lblItemName.Text = "item name";
            lblItemPrice.Text = "0";
            lblAvaiableQuantity.Text = "0";
            txtQuantity.Value = 1;
            lblID.Text = "0";
        }

        void UpdateQuantityLabal()
        {

            lblAvaiableQuantity.Text = (int.Parse(lblAvaiableQuantity.Text) - txtQuantity.Value) + "";
        }


        private void gvMaterials_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                lblItemsID.Text = gvMaterials.Rows[e.RowIndex].Cells[2].Value.ToString();
                //select item base info
                DataTable dt = new DataTable();

                lblItemName.Text = dt.Rows[0]["NAME"].ToString();
                lblAvaiableQuantity.Text = dt.Rows[0]["QUANTITY"].ToString();

                lblID.Text = lblTaskId.Text = gvMaterials.Rows[e.RowIndex].Cells[0].Value.ToString();

                lblItemPrice.Text = gvMaterials.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtQuantity.Text = gvMaterials.Rows[e.RowIndex].Cells[3].Value.ToString();
                lbltasksID.Text = gvMaterials.Rows[e.RowIndex].Cells[1].Value.ToString();
                updateQuantityOld = int.Parse(txtQuantity.Text);
            }
            catch
            {
                MessageBox.Show("some problem with selected item");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        #region cost
        double finalAmount = 0.0;
        private void btnRefreshCost_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnSaveCostToDB_Click(object sender, EventArgs e)
        {

        }

        private void btnJobTaskUpdate_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            {
                return;
            }
            double cost = 0.0;


            if (!new VehicleJobTaskDbService().IsLaburursFinishedTheTask(Convert.ToInt32(lblTaskId.Text)))
            {
                Helper.ErrorMessage("please closed all laburur"); return;
            }

            if (!double.TryParse(txtLabourCharge.Text, out cost))
            {
                Helper.ErrorMessage("invalied amount"); return;
            }
            try
            {
                new VehicleJobTaskDbService().UpdatevehicleTask(new VehicleJobTaskViewModel
                {
                    Discription = txtTaskDiscription.Text,
                    IsClosed = (int)Enums.EIsClosed.Closed,
                    TaskCost = int.Parse(txtLabourCharge.Text),
                    ID = Convert.ToInt32(lblJobTaskID.Text)
                });

                Helper.SuccessMessage("job close is success");
                LoadJobTasks();
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }

        }

        #region <Color Grid>
        public void rowColorTask1()
        {

            for (int i = 0; i < gvTask.Rows.Count - 1; i++)
            {

                int val = Convert.ToInt32(gvTask.Rows[i].Cells["IsClosed"].Value.ToString());

                if (val == 2)
                {
                    gvTask.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    gvTask.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }

            }
        }

        public void rowColorLabur1()
        {

            for (int i = 0; i < gvLabours.Rows.Count - 1; i++)
            {

                int val = Convert.ToInt32(gvLabours.Rows[i].Cells["IS_CLOSED"].Value.ToString());

                if (val == 2)
                {
                    gvLabours.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    gvLabours.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }

            }
        }

        public void rowColor1()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    int val = Convert.ToInt32(dataGridView1.Rows[i].Cells["is_finished"].Value.ToString());

                    if (val == 1)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
            catch
            {

                MessageBox.Show("invalied job");
            }
        }

        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        void ResetValues()
        {

            //labour task allocation
            lblTaskJobID.Text = "0";
            lblJobTaskID.Text = "0";
            lblTaskId.Text = "0";
            txtLabourCharge.Text = "TASK NAME";
            txtTaskDiscription.Text = "";

            //WORDFOUCE allocation

            lblTaskLabourName.Text = "name";
            lblTaskLabourID.Text = "0";
            lblTaskLabourEmpID.Text = "0";
            txtTaskLabourDiscription.Text = "";

            //matirial issue
            lblItemsID.Text = "0";
            lbltasksID.Text = "0";
            lblItemName.Text = "item name";
            lblItemPrice.Text = "0";
            txtQuantity.Text = "0";

            //repare order
            lblJobID.Text = "0";
            lblJobVehicleID.Text = "0";
            lblCurrentJobStatus.Text = "0";

        }


        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        decimal labararCost = 0.0M;
        public void SetLabururCost(decimal lcost = 0.0m) {
            this.labararCost = lcost;
            lbllabururAmount.Text = $"Rs {labararCost}";
        }
        private void btnJobUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // get labarur amount
                var x = new FrmInputDialog("Laburur Cost", "Insert laburur Cost", this);
                x.ShowDialog();

                if (!Helper.Confirmation(message: "Sure finied job? (it cannot be roll back)")) { return; }
                 
                if (!new VehicleJobDbService().CheckJobTasksAreClosed(Convert.ToInt32(lblJobID.Text)))
                {
                    Helper.ErrorMessage("please closed job tasks"); return;
                }

                new VehicleJobDbService().CloseVehicleJob(new VehicleJobViewModel
                {
                    FinalAmount = Convert.ToDouble(labararCost),
                    ID = int.Parse(lblJobID.Text)
                });
                Helper.SuccessMessage("job is closed");
                LoadVehicleJobs(lblJobVehicleID.Text);

            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex);
            }
        }
    }
}
