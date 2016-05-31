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
        public void LoadVehicleNumber(string vehicleNumber,string pimageURL) {

            lblJobVehicleID.Text = vehicleNumber;
            pictureBox2.Image = Image.FromFile(Pathss.FilePath+ pimageURL);
            LoadVehicleJobs(vehicleNumber);
        }
 
        private void btnJobSelectVehicle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (cmbJobType.SelectedItem.ToString() == "BOOKING")
                {
                    Reservation objres = new Reservation(this);
                    objres.ShowDialog();
                }
                else if (cmbJobType.SelectedItem.ToString() == "DIRECT")
                {
                    FrmVehicle obj = new FrmVehicle(this);
                    obj.ShowDialog();
                }
            }
            catch {
                MessageBox.Show("please select the job type");
            }
        }

        bool IsCurrentJobFinished = true;
        void LoadVehicleJobs(string vehicleNumber) {

            dataGridView1.DataSource = WSBL.SelectVehicle(vehicleNumber).Content;
            try
            {
                if (int.Parse(dataGridView1.Rows[0].Cells["is_finished"].Value.ToString()) == (int)EIsFinished.Yes)
                {
                    lblCurrentJobStatus.Text = "Finised All jobs.can process";
                    IsCurrentJobFinished = true;
                }
                else
                {
                    lblCurrentJobStatus.Text = "not Finised All jobs.can not process";
                    IsCurrentJobFinished = false;
                }
            }
            catch {
                IsCurrentJobFinished = true;
                lblCurrentJobStatus.Text = "Finised All jobs.can process";

            }
            //EnableFunctionsByCurrentJobState();
            rowColor();
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

        public void rowColor()
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
            catch {

                MessageBox.Show("invalied job");
            }
        }

        private void btnJobInsert_Click(object sender, EventArgs e)
        {

            if (!IsCurrentJobFinished)
            {
                MessageBox.Show("please close current runing job");return;
            }
              
            if (int.Parse(cmbJobType.SelectedIndex.ToString()) == -1)
            {
                MessageBox.Show("please select job type");
                return;
            }
            else if (lblJobVehicleID.Text == "0")
            {
                MessageBox.Show("please select vehicle"); return;
            }
            if (!Helper.Confirmation(message:"are you sure ? you cant roll back the job inseterd"))
            {
                return;
            }
            ReturnObject objre = UpdateModel(DBQ.Insert);

            if (ValidateObject(objre))
            {
                LoadVehicleJobs(lblJobVehicleID.Text);
                MessageBox.Show(objre.Message);
            }
        }

        bool ValidateObject(ReturnObject ReturnObject)
        {
            if (ReturnObject.MessageCode != MessageCode.Success)
            {
                MessageBox.Show(ReturnObject.Message);
                return false;
            }
            return true;
        }

        ReturnObject UpdateModel(DBQ db)
        {
            try
            {
                return WSBL.UpdateVehicle(new JobModel
                {
                    CloseDate = DateTime.Now,
                    CloseTime = DateTime.Now,
                    OpenTime = DateTime.Now,
                    OpenDate = DateTime.Now,
                    IsFinished = (db == DBQ.Insert) ? EIsFinished.No : EIsFinished.Yes,
                    JobID = int.Parse(lblJobID.Text),
                    JobType = (EJobType)(cmbJobType.SelectedIndex + 1),
                    VehicleNumber = lblJobVehicleID.Text,
                    UserEmail = Properties.Settings.Default.EMAIL,
                    FinalAmount = (db == DBQ.Insert) ? 0 : finalAmount

                }, db);
            }
            catch {
                MessageBox.Show("invalied job selected");return new ReturnObject {
                    MessageCode = MessageCode.InputError
                };
            }
        }

        private void btnJobUpdate_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblJobID.Text)== 0)
            {
                MessageBox.Show("please select job");
                return;
            }
            LoadJobTasks();
            tabControl1.SelectedIndex = 1;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                lblJobID.Text = lblTaskJobID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmbJobType.SelectedIndex = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) - 1;
                IsCurrentJobFinished = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["IS_FINISHED"].Value.ToString()) == 1 ? false : true;
                EnableFunctionsByCurrentJobState();
            }
            catch {

                MessageBox.Show("please select valied job");
            }
        }
        #endregion

        #region task
        private void btnLoadTask_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmTasks obj = new FrmTasks(this);
            obj.ShowDialog();
        }

        public void LoadTaskInfo(int tid, string description,string name) {

            lblTaskId.Text = tid.ToString();
            lblTaskName.Text = name;
            txtTaskDiscription.Text = description;
        }


        ReturnObject TaskUpdateModel(DBQ db)
        {
            try
            {
                return WSBL.UpdateVehicleTask(new VehicleTaskModel
                {
                    JobID = int.Parse(lblJobID.Text),
                    ID = int.Parse(lblJobTaskID.Text),
                    Task = new List<TaskModel>{
                    new TaskModel{ID = int.Parse(lblTaskId.Text)}
                 },
                    Discription = txtTaskDiscription.Text,
                    IsFinishied = (db == DBQ.Insert) ? EIsFinished.No : (EIsFinished)cmbTaskState.SelectedIndex + 1,
                    UserEmail = Properties.Settings.Default.EMAIL
                }, db);
            }
            catch(Exception ex) {
                MessageBox.Show("invalied user input");
                return BL.BL.HELPER.Validation.SystemError(ex); }
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (int.Parse(cmbTaskState.SelectedIndex.ToString()) == -1)
            {
                MessageBox.Show("please select Status");
                return;
            }
            try
            {
                DataTable dt = (DataTable)WSBL.SelectVehicleJobExists(Convert.ToInt32(lblTaskId.Text), Convert.ToInt32(lblTaskJobID.Text)).Content;
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("This tasks already assigned to this job");
                    return;
                }
            }
            catch { MessageBox.Show("invalied row selected");return; }
            ReturnObject objre = TaskUpdateModel(DBQ.Insert);
            if (ValidateObject(objre))
            {
                LoadJobTasks();
                ResetTaskAllocation();
                MessageBox.Show(objre.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ReturnObject objre = TaskUpdateModel(DBQ.Delete);
            if (ValidateObject(objre))
            {
                LoadJobTasks();
                ResetTaskAllocation();
                MessageBox.Show(objre.Message);
            }
        }
        public void ResetTaskAllocation()
        {
            lblJobTaskID.Text = "0";
            lblTaskJobID.Text = "0";
            lblTaskId.Text = "0";
            lblTaskName.Text = "TASK NAME";
            cmbTaskState.SelectedIndex = 0;
            txtLabourCharge.Text = "0";
            txtTaskDiscription.Text = "";
        }


        void LoadJobTasks() {

            gvTask.DataSource =  WSBL.SelectVahicleTasks(int.Parse(lblJobID.Text)).Content;
            rowColorTask();
        }
        private void gvTask_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int taskID = 0;
                if (!int.TryParse(gvTask.Rows[e.RowIndex].Cells[0].Value.ToString(),out taskID))
                {
                    MessageBox.Show("please select valied task");return;
                }

                lbltasksID.Text = lblJobTaskID.Text = gvTask.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblTaskJobID.Text = gvTask.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblTaskId.Text = gvTask.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTaskDiscription.Text = gvTask.Rows[e.RowIndex].Cells[3].Value.ToString();
                cmbTaskState.SelectedIndex = int.Parse(gvTask.Rows[e.RowIndex].Cells[6].Value.ToString()) - 1;
                lblTaskName.Text = ((List<TaskModel>)TaskBL.SelectTask().Content).Where(p => p.ID == int.Parse(lblTaskId.Text)).FirstOrDefault().Name;

                if (lblTaskId.Text == "TASK")
                {
                    MessageBox.Show("please select TaskId");
                    return;
                }
                if (lblTaskJobID.Text == "")
                {
                    MessageBox.Show("invalied row selected"); return;
                }
                //LoadTaskLabours(lblJobTaskID.Text);
                LoadTaskLabours(lblJobTaskID.Text);
                LoadMaterials(lblJobTaskID.Text);
            }
            catch { MessageBox.Show("please select valied task"); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblJobTaskID.Text=="0")
            {
                MessageBox.Show("Please select job task before navigation");return;
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
            DataTable dt = (DataTable)WSBL.SelectLabourExists(Convert.ToInt32(lblJobTaskID.Text), Convert.ToInt32(lblTaskLabourEmpID.Text)).Content;
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("This labour already assigned to this task");
                return;
            }

            ReturnObject objre = LabourUpdateModel(DBQ.Insert);
            if (ValidateObject(objre))
            {
                ResetLabourTaskAllocation();
                LoadTaskLabours(lblJobTaskID.Text);
                MessageBox.Show(objre.Message);

            }

        }

        private void ResetLabourTaskAllocation() {

            lblTaskLabourName.Text = "name";
            lblTaskLabourEmpID.Text = "0";
            txtTaskLabourDiscription.Text = "";
            lblTaskLabourID.Text = "0";
            cmbTaskLabourState.SelectedIndex = 0;
        }

        private void btnTaskLaboburUpdate_Click(object sender, EventArgs e)
        {

            ReturnObject objre = LabourUpdateModel(DBQ.Update);
            if (ValidateObject(objre))
            {
                ResetLabourTaskAllocation();
                LoadTaskLabours(lblJobTaskID.Text);
                MessageBox.Show(objre.Message);
            }
        }

        private void btnTaskLaboburDelete_Click(object sender, EventArgs e)
        {

            ReturnObject objre = LabourUpdateModel(DBQ.Delete);
            if (ValidateObject(objre))
            {
                ResetLabourTaskAllocation();
                LoadTaskLabours(lblJobTaskID.Text);
                MessageBox.Show(objre.Message);
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                lblTaskLabourID.Text = gvLabours.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblTaskLabourEmpID.Text = gvLabours.Rows[e.RowIndex].Cells[2].Value.ToString();
                DataTable dt = (DataTable)BL.BL.LaboursBL.SelectLabours().Content;
                txtTaskLabourDiscription.Text = gvLabours.Rows[e.RowIndex].Cells[3].Value.ToString();
                cmbTaskLabourState.SelectedIndex = int.Parse(gvLabours.Rows[e.RowIndex].Cells[5].Value.ToString()) - 1;
                lblTaskLabourName.Text = dt.Select("ID = " + lblTaskLabourEmpID.Text + "").CopyToDataTable().Rows[0]["NAME"].ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void LoadLabour(string empID,string name) {

            lblTaskLabourEmpID.Text = empID;
            lblTaskLabourName.Text = name;
            //LoadLabourJobs(empID);
        }

        //void LoadLabourJobs(string empId)
        //{

        //    gvLabours.DataSource = WSBL.SelectJobsByEmpId(empId).Content;
        //}

        void LoadTaskLabours(string taskID)
        {

            gvLabours.DataSource = WSBL.SelectTaskLabour(int.Parse(taskID)).Content;
            rowColorLabur();
        }

        void LoadMaterials(string taskID)
        {

            gvMaterials.DataSource = WSBL.SelectMaterials(taskID).Content;
        }
        ReturnObject LabourUpdateModel(DBQ db)
        {
            try
            {
                return WSBL.UpdateTaskLabour(new TaskLabour
                {
                    Discription = txtTaskLabourDiscription.Text,
                    ID = int.Parse(lblTaskLabourID.Text),
                    IsFinied = (EIsFinished)cmbTaskLabourState.SelectedIndex+1,
                    LabourID = int.Parse(lblTaskLabourEmpID.Text),
                    TaskID = int.Parse(lbltasksID.Text),
                    UserEmail = Properties.Settings.Default.EMAIL
                }, db);
            }
            catch (Exception ex)
            {
                MessageBox.Show("invalied user input");
                return BL.BL.HELPER.Validation.SystemError(ex);
            }
        }
        #endregion

        private void btnLoadItems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ENTITY.FrmItems obj = new ENTITY.FrmItems(this);
            obj.ShowDialog();
        }

       public void LoadItemInfo(string id,string name,string qantity,string outprice) {

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
            else if (tabControl1.SelectedIndex ==2)
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
            updateQuantityFinal = updateQuantityOld - Convert.ToInt16(txtQuantity.Value);
            ReturnObject objre = MaterialUpdateModel(DBQ.Update);
            if (ValidateObject(objre))
            {
                // LoadTaskLabours(lblTaskJobID.Text);
                MessageBox.Show(objre.Message);
                LoadMaterials(lblJobTaskID.Text);

                // refresh current quantity
                lblAvaiableQuantity.Text = (int.Parse(lblAvaiableQuantity.Text) + (Convert.ToInt16(txtQuantity.Value) - updateQuantityOld)) + "";
                ClearMatirialIssue();
            }
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

           ReturnObject objre = MaterialUpdateModel(DBQ.Delete);
           if (ValidateObject(objre))
           {
              // LoadJobTasks();
               MessageBox.Show(objre.Message);
               LoadMaterials(lblJobTaskID.Text);
           }
       }

       private void cmbTaskState_SelectedIndexChanged(object sender, EventArgs e)
       {

           if (cmbTaskState.SelectedItem.ToString() == "CLOSE")
           {
               lblLabourCharge.Visible = true;
               txtLabourCharge.Visible = true;
            }
            else
            {
                lblLabourCharge.Visible = false;
                txtLabourCharge.Visible = false;
            }
       }
         
       private void button4_Click(object sender, EventArgs e)
       {
           try
           {
               int availableqty =Convert.ToInt32(lblAvaiableQuantity.Text);
               int qty = Convert.ToInt32(txtQuantity.Text);

                try
                {
                    DataTable dt = (DataTable)WSBL.SelectItemsExists(Convert.ToInt32(lblJobTaskID.Text), Convert.ToInt32(lblItemsID.Text)).Content;
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("This item already assigned to this task");
                        return;
                    }
                    if (qty > availableqty)
                    {
                        MessageBox.Show("invalid quantity");
                        return;
                    }
                }
                catch {
                    MessageBox.Show("invalied row selected");
                }
               ReturnObject objre = MaterialUpdateModel(DBQ.Insert);
                if (ValidateObject(objre))
                {
                    MessageBox.Show(objre.Message);
                    UpdateQuantityLabal();
                    LoadMaterials(lblJobTaskID.Text);
                }

           }
           catch (Exception ex)
           {
               
               throw ex;
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

        void UpdateQuantityLabal() {

            lblAvaiableQuantity.Text = (int.Parse(lblAvaiableQuantity.Text) - txtQuantity.Value)+"";
        }

       ReturnObject MaterialUpdateModel(DBQ db)
       {
           try
           {
               return WSBL.UpdateMaterial(new Material
               {
                   Description = txtTaskDiscription.Text,
                   ID = int.Parse(lblID.Text),
                   Item_ID = int.Parse(lblItemsID.Text),
                   Task_ID = int.Parse(lbltasksID.Text),
                   Quantity = Convert.ToInt32(txtQuantity.Text),
                   Price = float.Parse(lblItemPrice.Text),
                   UserEmail = Properties.Settings.Default.EMAIL,
                   QuantityDeference = updateQuantityFinal
               }, db);
           }
           catch (Exception ex)
           {
               MessageBox.Show("invalied user input");
               return BL.BL.HELPER.Validation.SystemError(ex);
           }
       }

        private void gvMaterials_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                lblItemsID.Text = gvMaterials.Rows[e.RowIndex].Cells[2].Value.ToString();
                //select item base info
                DataTable dt = BL.DAL.ItemDAL.SelectItems().Select("ID = " + lblItemsID.Text + " ").CopyToDataTable();

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
            double outItemTotalCost = 0.0;
            DataTable dt = (DataTable)BL.BL.CostBL.GetItemCost(int.Parse(lblTaskJobID.Text),out outItemTotalCost).Content;
            gvItemCost.DataSource = dt;

            lblItemCostTotal.Text = string.Format("TOTAL ITEM COST Rs : {0} /=", outItemTotalCost);

            ////////////
            double outLabourTotalCost = 0.0;
            gvLabourCost . DataSource = (DataTable)BL.BL.CostBL.GetLabourCost(int.Parse(lblTaskJobID.Text), out outLabourTotalCost).Content;
            lblLabourCoustTotal.Text = string.Format("TOTAL LABOUR COST Rs : {0} /=", outLabourTotalCost);
            finalAmount = outItemTotalCost + outLabourTotalCost;
            lblTotalCost.Text = string.Format("Total cost of the job Rs : {0} /=", finalAmount);
        }

        #endregion

        private void btnSaveCostToDB_Click(object sender, EventArgs e)
        {
            ReturnObject objre = UpdateModel(DBQ.Update);
            if (ValidateObject(objre))
            {
                LoadVehicleJobs(lblJobVehicleID.Text);
                MessageBox.Show(objre.Message);
            }
        }

        private void btnJobTaskUpdate_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            {
                return;
            }
            double cost = 0.0;

            if (!IsLabourAllFinished())
            {
                MessageBox.Show("please close all labour tasks");return;
            }  

            if (!double.TryParse(txtLabourCharge.Text,out cost))
            {
                MessageBox.Show("invalied amount");return;
            }

            if (BL.BL.WSBL.CloseJobTask(int.Parse(lblJobTaskID.Text), cost).MessageCode == MessageCode.Success) {

                MessageBox.Show("job close is success");
                LoadJobTasks();
                LoadJobTasks(); ;
            }
            else
            {
                MessageBox.Show("job close is not success");
            }
        }

        public void rowColorTask()
        {

            for (int i = 0; i < gvTask.Rows.Count - 1; i++)
            {

                int val = Convert.ToInt32(gvTask.Rows[i].Cells["IS_CLOSERD"].Value.ToString());

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

        public void rowColorLabur()
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowColorTask();
            rowColorLabur();
            rowColor();
            //ResetValues();
        }

        void ResetValues()
        {

            //labour task allocation
            lblTaskJobID.Text = "0";
            lblJobTaskID.Text = "0";
            lblTaskId.Text = "0";
            txtLabourCharge.Text = "TASK NAME";
            txtTaskDiscription.Text = "";
            cmbTaskState.SelectedIndex = 0;


            //WORDFOUCE allocation

            lblTaskLabourName.Text = "name";
            lblTaskLabourID.Text = "0";
            lblTaskLabourEmpID.Text = "0";
            txtTaskLabourDiscription.Text = "";
            cmbTaskLabourState.SelectedIndex = 0;

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


        private void btnCloseJob_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation(message:"are you sure. \n this action cant be rallback."))
            {
                return;
            }
            // check all jobs close
            if (!IsJobAllFinished()) {

                MessageBox.Show("All job-task must be close for close full job");return;
            }

            ReturnObject a = UpdateModel(DBQ.Update);
            if (ValidateObject(a))
            {
                LoadVehicleJobs(lblJobVehicleID.Text);
                gvItemCost.DataSource = null;
                gvLabourCost.DataSource = null;
                MessageBox.Show("job finied is success");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        bool IsLabourAllFinished() {

            bool IsFinied = true;
            for (int i = 0; i < gvLabours.Rows.Count; i++)
            {
                try
                {
                    string taskState = gvLabours.Rows[i].Cells["IS_CLOSED"].Value.ToString();
                    if (int.Parse(taskState) == (int)EIsFinished.No)
                    {
                        IsFinied = false;
                        break;
                    }
                }
                catch { continue; }
            }

            return IsFinied;
        }

        bool IsJobAllFinished()
        {

            bool IsFinied = true;
            for (int i = 0; i < gvTask.Rows.Count; i++)
            {
                try
                {
                    string taskState = gvTask.Rows[i].Cells["IS_CLOSERD"].Value.ToString();
                    if (int.Parse(taskState) == (int)EIsFinished.No)
                    {
                        IsFinied = false;
                        break;
                    }
                }
                catch { continue; }
            }

            return IsFinied;
        }
    }
}
