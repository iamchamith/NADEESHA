using App.BL;
using App.Model;
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
        public void LoadVehicleNumber(string vehicleNumber, string pimageURL)
        {

            lblJobVehicleID.Text = vehicleNumber;
            pictureBox2.Image = Image.FromFile(Pathss.FilePath + pimageURL);
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
            catch
            {

                MessageBox.Show("invalied job");
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

            using (var x = new VehicleJobDbService())
            {
                var o = x.CreateVehicleJob(new App.Model.VehicleJobViewModel
                {
                    IsFinished = (int)Enums.EIsClosed.NotClosed,
                    FinalAmount = 0.00,
                    OpenDate = DateTime.Now,
                    CloseTime = DateTime.Now,
                    VehicleNumber = lblJobVehicleID.Text,
                    UserEmail = Properties.Settings.Default.EMAIL
                });
                if (!o.State)
                {
                    Helper.ErrorMessage(o.Message);
                }
                else
                {
                    LoadVehicleJobs(lblJobVehicleID.Text);
                    Helper.SuccessMessage(message: "job creation is success");
                }
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

        private void btnJobUpdate_Click(object sender, EventArgs e)
        {

        }
        private void btnGo_Click(object sender, EventArgs e)
        {
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
            }
            catch
            {

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

        public void LoadTaskInfo(int tid, string description, string name)
        {

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
                    
                    UserEmail = Properties.Settings.Default.EMAIL
                }, db);
            }
            catch (Exception ex)
            {
                MessageBox.Show("invalied user input");
                return BL.BL.HELPER.Validation.SystemError(ex);
            }
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
          
            try
            {
                var x = new VehicleJobTaskDbService().CreateVehicleJobTask(new VehicleJobTaskViewModel
                {
                    Date = DateTime.Today,
                    Discription = txtTaskDiscription.Text,
                    TaskId = int.Parse(lbltasksID.Text),
                    JobId = int.Parse(lblTaskJobID.Text),
                    IsClosed = (int)Enums.EIsClosed.NotClosed,
                    UserEmail = Properties.Settings.Default.EMAIL
                });
                if (x.State)
                {
                    Helper.SuccessMessage();
                    LoadJobTasks();
                }
                else { LoadJobTasks(); }
            }
            catch { MessageBox.Show("invalied row selected"); return; }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Helper.Confirmation())
            {
                var x = new VehicleJobTaskLabourDbService().DeleteVehicleTasks(123);
                if (x.State)
                {
                    LoadTaskLabours("123");
                }
                else {
                    Helper.ErrorMessage();
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
            gvTask.DataSource = Helper.CreateDataTable<VehicleJobTaskViewModel>((List<VehicleJobTaskViewModel>)
                new VehicleJobTaskDbService().SelectVehicleTask(int.Parse(lblJobID.Text)).Content);
            rowColorTask();
        }
        private void gvTask_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int taskID = 0;
                if (!int.TryParse(gvTask.Rows[e.RowIndex].Cells[0].Value.ToString(), out taskID))
                {
                    MessageBox.Show("please select valied task"); return;
                }

                lbltasksID.Text = lbJobTaskId.Text = lblJobTaskID.Text = gvTask.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblTaskJobID.Text = gvTask.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblTaskId.Text = gvTask.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTaskDiscription.Text = gvTask.Rows[e.RowIndex].Cells[3].Value.ToString();
               
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
            catch { MessageBox.Show("please select valied task"); }

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
            var x = new VehicleJobTaskLabourDbService().CreateVehicleJobTask(new VehicleJobTaskLabourViewModel
            {
                LabourId = int.Parse(lblTaskLabourEmpID.Text),
                TaskId = int.Parse(lbJobTaskId.Text),
                Discription = txtTaskLabourDiscription.Text,
                UserEmail = Properties.Settings.Default.EMAIL,
                OpenDateTime = DateTime.Now,
                IsClosed = (int)Enums.EIsClosed.NotClosed
            });
            if (x.State)
            {
                LoadTaskLabours(lbJobTaskId.Text);
                Helper.SuccessMessage();
            }
            else
            {
                Helper.ErrorMessage(message: x.Message);
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

            if (Helper.Confirmation())
            {
                var x = new VehicleJobTaskLabourDbService().UpdatevehicleTask(new VehicleJobTaskLabourViewModel {
                    CloseDateTime = DateTime.Today,
                    Discription = txtTaskLabourDiscription.Text,
                    IsClosed = (int)Enums.EIsClosed.Closed
                });
                if (x.State)
                {
                    Helper.SuccessMessage();
                    LoadTaskLabours("123");
                }
                else
                {
                    Helper.ErrorMessage();
                }
            }
        }

        private void btnTaskLaboburDelete_Click(object sender, EventArgs e)
        {

            if (Helper.Confirmation())
            {
                var x = new VehicleJobTaskLabourDbService().DeleteVehicleTasks(123);
                if (x.State)
                {
                    LoadTaskLabours("123");
                }
                else
                {
                    Helper.ErrorMessage();
                }
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
                lblTaskLabourName.Text = dt.Select("ID = " + lblTaskLabourEmpID.Text + "").CopyToDataTable().Rows[0]["NAME"].ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void LoadLabour(string empID, string name)
        {

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
            gvLabours.DataSource = Helper.CreateDataTable<VehicleJobTaskLabourViewModel>((List<VehicleJobTaskLabourViewModel>)new VehicleJobTaskLabourDbService().SelectVehicleTask(int.Parse(taskID)).Content);
            //rowColorLabur();
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


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int availableqty = Convert.ToInt32(lblAvaiableQuantity.Text);
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
                catch
                {
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

        void UpdateQuantityLabal()
        {

            lblAvaiableQuantity.Text = (int.Parse(lblAvaiableQuantity.Text) - txtQuantity.Value) + "";
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
            DataTable dt = (DataTable)BL.BL.CostBL.GetItemCost(int.Parse(lblTaskJobID.Text), out outItemTotalCost).Content;
            gvItemCost.DataSource = dt;

            lblItemCostTotal.Text = string.Format("TOTAL ITEM COST Rs : {0} /=", outItemTotalCost);

            ////////////
            double outLabourTotalCost = 0.0;
            gvLabourCost.DataSource = (DataTable)BL.BL.CostBL.GetLabourCost(int.Parse(lblTaskJobID.Text), out outLabourTotalCost).Content;
            lblLabourCoustTotal.Text = string.Format("TOTAL LABOUR COST Rs : {0} /=", outLabourTotalCost);
            finalAmount = outItemTotalCost + outLabourTotalCost;
            lblTotalCost.Text = string.Format("Total cost of the job Rs : {0} /=", finalAmount);
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

            if (!IsLabourAllFinished())
            {
                MessageBox.Show("please close all labour tasks"); return;
            }

            if (!double.TryParse(txtLabourCharge.Text, out cost))
            {
                MessageBox.Show("invalied amount"); return;
            }

            var x = new VehicleJobTaskDbService().UpdatevehicleTask(new VehicleJobTaskViewModel {
                Discription = txtTaskDiscription.Text,
                IsClosed =  (int)Enums.EIsClosed.Closed,
                TaskCost = int.Parse(txtLabourCharge.Text)
            });
            if (x.State)
            {
                Helper.SuccessMessage("job close is success");
                LoadJobTasks();
                LoadJobTasks();  
            }
            else
            {
                Helper.ErrorMessage("job close is not success");
            }
        }

        public void rowColorTask()
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
            //rowColorTask();
            //rowColorLabur();
            //rowColor();
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


        private void btnCloseJob_Click(object sender, EventArgs e)
        {


        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        bool IsLabourAllFinished()
        {

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
