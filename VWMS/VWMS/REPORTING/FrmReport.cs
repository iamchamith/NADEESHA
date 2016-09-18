using App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.BL;
using App.BL.DbServices;

namespace VWMS.REPORTING
{
    public partial class FrmReport : Form
    {
        public FrmReport()
        {
            InitializeComponent();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {

            // this.crystalReportViewer1.RefreshReport();
            // this.reportViewer1.RefreshReport();
        }

        public FrmReport(Enums.EReports eReports, int id)
        {
            InitializeComponent();
            if (eReports == Enums.EReports.Customers)
            {
                CustomerReport();
            }
            else if (eReports == Enums.EReports.Vehicle)
            {
                VehicleReport();
            }
            else if (eReports == Enums.EReports.Labours)
            {

                LabourReport();

            }
            else if (eReports == Enums.EReports.Items)
            {
                ItemReport();

            }
        }

        public void CustomerReport()
        {
            DataTable dt = Helper.CreateDataTable<Customer>((List<Customer>)(new CustomerDbService().Read().Content));
            DSReports ds = new DSReports();
            foreach (DataRow items in dt.Rows)
            {
                ds.Tables["TB_CUSTOMER"].Rows.Add(items["ID"].ToString(),
                    items["NAME"].ToString(), items["PHONE"].ToString(), items["ADDRESS"].ToString(),
                    items["EMAIL"].ToString(), items["NIC"].ToString()
                    );
            }

            RPTCustomer objcus = new RPTCustomer();
            objcus.SetDataSource(ds.Tables["TB_CUSTOMER"]);
            crystalReportViewer1.ReportSource = objcus;
        }

        public void VehicleReport()
        {
            DataTable dt = Helper.CreateDataTable<VehicleViewModel>((List<VehicleViewModel>)new VehicleDbService().Read().Content);
            DSReports ds = new DSReports();
            foreach (DataRow items in dt.Rows)
            {
                ds.Tables["TB_VEHICLE"].Rows.Add(items["VEHICLE_ID"].ToString(),
                    items["ENGINE_NUMBER"].ToString(), items["CHASSI_NUMBER"].ToString(), items["NAME"].ToString(),
                    items["CUSTOMER NAME"].ToString()
                    );
            }

            RPTVehicle objcus = new RPTVehicle();
            objcus.SetDataSource(ds.Tables["TB_VEHICLE"]);
            crystalReportViewer1.ReportSource = objcus;
        }

        public void LabourReport()
        {

            DataTable dt = Helper.CreateDataTable<LabourViewModel>((List<LabourViewModel>)(new LaboursDbService().Read().Content));
            DSReports ds = new DSReports();
            foreach (DataRow items in dt.Rows)
            {
                ds.Tables["TB_LABOUR"].Rows.Add(items["ID"].ToString(),
                    items["NAME"].ToString(), items["DISCRIPTION"].ToString(), items["NIC"].ToString()

                    );
            }

            RPTLabour objcus = new RPTLabour();
            objcus.SetDataSource(ds.Tables["TB_LABOUR"]);
            crystalReportViewer1.ReportSource = objcus;


        }

        public void ItemReport()
        {

            DataTable dt = Helper.CreateDataTable<ItemViewModel>((List<ItemViewModel>)(new ItemDbService().Read().Content));
            DSReports ds = new DSReports();
            foreach (DataRow items in dt.Rows)
            {
                ds.Tables["TB_ITEMS"].Rows.Add(items["ID"].ToString(),
                    items["NAME"].ToString(), items["DISCRIPTION"].ToString(), items["PRICE_IN"].ToString(), items["PRICE_OUT"].ToString(), items["QUANTITY"].ToString()

                    );
            }
            RPTItems objcus = new RPTItems();
            objcus.SetDataSource(ds.Tables["TB_ITEMS"]);
            crystalReportViewer1.ReportSource = objcus;
        }
    }
}
