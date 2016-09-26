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
            try
            {
                var dt = (List<Customer>)(new CustomerDbService().Read().Content);
                DSReports ds = new DSReports();
                foreach (var items in dt)
                {
                    ds.Tables["Customer"].Rows.Add(items.ID.ToString(),
                        items.Name.ToString(), items.Phone.ToString(), items.Address.ToString(),
                        items.Email.ToString(), items.Nic.ToString()
                        );
                }

                RPTCustomer objcus = new RPTCustomer();
                objcus.SetDataSource(ds.Tables["Customer"]);
                crystalReportViewer1.ReportSource = objcus;
            }
            catch { throw; }
        }

        public void VehicleReport()
        {
            try
            {
                var dt = (List<VehicleCustomerViewModel>)new VehicleDbService().ReadVehicleWithCustomer().Content;
                DSReports ds = new DSReports();
                foreach (var items in dt)
                {
                    ds.Tables["Vehicle"].Rows.Add(items.VehicleID.ToString(),
                        items.EngineNumber.ToString(), items.ChassiNumber.ToString(), items.CustomerName.ToString(),
                        items.CustomerNic.ToString()
                        );
                }

                RPTVehicle objcus = new RPTVehicle();
                objcus.SetDataSource(ds.Tables["Vehicle"]);
                crystalReportViewer1.ReportSource = objcus;
            }
            catch { throw; }
        }

        public void LabourReport()
        {
            try
            {
                var dt = (List<LabourViewModel>)new LaboursDbService().Read().Content;
                DSReports ds = new DSReports();
                foreach (var items in dt)
                {
                    ds.Tables["Labours"].Rows.Add(items.ID.ToString(),
                        items.Name.ToString(), items.Discription.ToString(), items.Nic.ToString());
                }

                RPTLabour objcus = new RPTLabour();
                objcus.SetDataSource(ds.Tables["Labours"]);
                crystalReportViewer1.ReportSource = objcus;
            }
            catch { throw; }

        }

        public void ItemReport()
        {
            try
            {
                var dt = (List<ItemViewModel>)(new ItemDbService().Read().Content);
                DSReports ds = new DSReports();
                foreach (var items in dt)
                {
                    ds.Tables["Items"].Rows.Add(items.ID.ToString(),
                        items.Name.ToString(), items.Discription.ToString(),
                        $"Rs {items.PriceIn.ToString()}", $"Rs { items.PriceOut.ToString()}", $"{items.Quantity.ToString()} Units"
                        );
                }
                RPTItems objcus = new RPTItems();
                objcus.SetDataSource(ds.Tables["Items"]);
                crystalReportViewer1.ReportSource = objcus;
            }
            catch { throw; }
        }
    }
}
