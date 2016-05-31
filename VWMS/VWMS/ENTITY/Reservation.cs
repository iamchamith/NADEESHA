using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.BL;
using BL.MODEL;
using VWMS.WS;

namespace VWMS.ENTITY
{
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
            btnGo.Visible = false;
        }
        FRMWS objG = new FRMWS();
        public Reservation(FRMWS obj)
        {
            InitializeComponent();
           
            objG = obj;
        }
        private void btnVehiNo_Click(object sender, EventArgs e)
        {
            FrmVehicle obj = new FrmVehicle(this);
            obj.Show();
        }

        public void LoadVehicleNumber(string vehicleNumber)
        {
            txtVehicleNo.Text = vehicleNumber;
        }


        private void btnOwner_Click(object sender, EventArgs e)
        {
            FrmCustomers obj = new FrmCustomers(this);
            obj.Show();
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
            ReturnObject objre = UpdateBookings(DBQ.Insert);
            if (ValidateObject(objre))
            {
                LoadInfoVehicleBookings();
                MessageBox.Show(objre.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Insert is not Success", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        DataTable LstGBooking = new DataTable();
        void LoadInfoVehicleBookings()
        {
            dgvReservation.DataSource = LstGBooking = (DataTable)BookingBL.SelectBooking().Content;
        }
        ReturnObject UpdateBookings(DBQ db)
        {
            try
            {
                return BookingBL.UpdateBookings(new BookingModel
                {
                    ID = Convert.ToInt32(lblName.Text),
                    VEHICLE_ID = txtVehicleNo.Text,
                    CUS_CONCERN = txtcusDescription.Text,
                    BOOKING_DATE = dtpDate.Value.Date,
                    USER_EMAIL = Properties.Settings.Default.EMAIL,
                    FROM_TIME = dtpFromTime.Value.TimeOfDay,
                }, db);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid use inputs", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return BL.BL.HELPER.Validation.SystemError(ex);
            }
        }

        public bool IsValidate()
        {
            bool isOk = true;
            StringBuilder msg = new StringBuilder();

            if (string.IsNullOrEmpty(txtVehicleNo.Text))
            {
                msg.Append("Vehicle No required \n");
                isOk = false;
            }


            if (isOk == false)
            {
                MessageBox.Show(msg.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return isOk;

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            {
                return;
            }
            ReturnObject objre = UpdateBookings(DBQ.Update);
            if (ValidateObject(objre))
            {
                LoadInfoVehicleBookings();
                MessageBox.Show(objre.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Update is not success", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            {
                return;
            }
            ReturnObject objre = UpdateBookings(DBQ.Delete);
            if (ValidateObject(objre))
            {
                LoadInfoVehicleBookings();
                MessageBox.Show(objre.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Delete is not Success", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            lblToday.Text = DateTime.Now.ToShortDateString();
            LoadInfoVehicleBookings();
        }

        string selectedDate = string.Empty;
        private void dgvReservation_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvReservation.Rows[e.RowIndex];
                if (
                   dr.Cells["BOOKING_DATE"].Value.ToString().Split(' ')[0] != lblToday.Text &&
                   !BL.BL.HELPER.Validation.IsValiedDate(Convert.ToDateTime(dr.Cells["BOOKING_DATE"].Value.ToString()).AddDays(1).ToShortDateString()))
                {
                    MessageBox.Show("past resavation cant be update"); return;
                }

               
                lblName.Text = dr.Cells["ID"].Value.ToString();
                txtVehicleNo.Text = dr.Cells["VEHICLE_ID"].Value.ToString();
                txtcusDescription.Text = dr.Cells["CUS_CONCERN"].Value.ToString();
                dtpDate.Value = Convert.ToDateTime(dr.Cells["BOOKING_DATE"].Value.ToString());
                dtpFromTime.Value = Convert.ToDateTime(dr.Cells["FROM_TIME"].Value.ToString());

                selectedDate = dr.Cells["BOOKING_DATE"].Value.ToString();
            }
            catch { }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtVehicleNo.Clear();
            txtcusDescription.Clear();
            dtpDate.Value = DateTime.Now;
            lblName.Text = "0";
            LoadInfoVehicleBookings();
        }

        private void dtpSearch_ValueChanged(object sender, EventArgs e)
        {
            dgvReservation.DataSource = LstGBooking = (DataTable)BookingBL.SelectBookingsByReservedDate(dtpSearch.Value.ToShortDateString()).Content;
        }
        //    FRMWS objfrm = new FRMWS();
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (selectedDate.Split(' ')[0] != lblToday.Text)
            {
                MessageBox.Show("resavation msut be today " + DateTime.Now.ToShortDateString());
                return;
            }

            objG.LoadVehicleNumber(txtVehicleNo.Text, "car.jpg");
            this.Close();
        }
        
    }
}
