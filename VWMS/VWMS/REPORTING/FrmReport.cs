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
using App.Model.ViewModel;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

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

        public FrmReport(Enums.EReports eReports, int id = 0)
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
            else if (eReports == Enums.EReports.SearchItemReport)
            {
                ItemInfomationReport();
            }
            else if (eReports == Enums.EReports.JobItemRerport)
            {
                JobItemreport(id);
            }
            else if (eReports == Enums.EReports.JobLaborurReport)
            {
                JobLaborurReport(id);
            }
            else if (eReports == Enums.EReports.CustomerInvoice)
            {
                CustomerReport(id);
            }
            else if (eReports == Enums.EReports.UserReport)
            {
                UserReportInfo();
            }
        }

        public void UserReportInfo() {

            try
            {
                var data = (List<UserReportViewModel>)new UserDbService().GetUserInfo().Content;
                DSReports da = new DSReports();
                foreach (var item in data)
                {
                    da.Tables["Userreport"].Rows.Add(item.Email, UserKind(item.State.Value), item.Name, item.Nic);
                }

                UserReport test = new UserReport();
                test.SetDataSource(da.Tables["Userreport"]);

                crystalReportViewer1.ReportSource = test;
            }
            catch { throw; }

        }
        string UserKind(int i)
        {
            if (i == 1)
            {
                return "Admin";
            }
            else if (i == 2)
            {
                return "Maneger";
            }
            else
            {
                return "Stock keeper";
            }
        }
        public void CustomerReport(int id)
        {
            try
            {
                var data = (CustomerInvoiceViewModel)(new WizardReporting().SelectItemsByJobId(id).Content);
                var dt = data.JobItemReportViewModel;

                DSReports ds = new DSReports();
                foreach (var items in dt)
                {
                    ds.Tables["JobItemsForCustomer"].Rows.Add(items.TaskName.ToString(),
                        items.Name.ToString(), items.ItemId.ToString(), items.Quantity.ToString(),
                        items.Id.ToString(), $"Rs {items.Price.ToString()}");
                }

                RptReciptForCustomer objcus = new RptReciptForCustomer();
                objcus.SetDataSource(ds.Tables["JobItemsForCustomer"]);
                crystalReportViewer1.ReportSource = objcus;

                TextObject txtItemCost, txtLabourCost, txtGrandTotal;
                txtItemCost = (TextObject)objcus.ReportDefinition.ReportObjects["txtItemCost"];
                txtLabourCost = (TextObject)objcus.ReportDefinition.ReportObjects["txtLabourCost"];
                txtGrandTotal = (TextObject)objcus.ReportDefinition.ReportObjects["txtGrandTotal"];
                txtItemCost.Text = $"Rs {data.ItemSum}";
                txtLabourCost.Text = $"Rs {data.labourCost}";
                txtGrandTotal.Text = $"Rs {data.ItemSum + data.labourCost}";



            }
            catch (Exception)
            {

                throw;
            }

        }

        public void JobLaborurReport(int id)
        {

            try
            {
                var dt = (List<JobLaborReportInfo>)(new WizardReporting().GetLaborurJobsInfo(id).Content);
                DSReports ds = new DSReports();
                foreach (var items in dt)
                {
                    ds.Tables["JobLaborur"].Rows.Add(items.JobId.ToString(),
                        items.TaskId.ToString(), items.TaskName.ToString(), items.LaboursId.ToString(),
                        items.Name.ToString());
                }

                RptJobLaborurReport objcus = new RptJobLaborurReport();
                objcus.SetDataSource(ds.Tables["JobLaborur"]);
                crystalReportViewer1.ReportSource = objcus;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void JobItemreport(int id)
        {
            try
            {
                var dt = (List<JobItemReportViewModel>)(new WizardReporting().GetJobItemReport(id).Content);
                DSReports ds = new DSReports();
                foreach (var items in dt)
                {
                    ds.Tables["JobItems"].Rows.Add(items.TaskName.ToString(),
                        items.Name.ToString(), items.ItemId.ToString(), items.Quantity.ToString(),
                        items.Id.ToString());
                }

                RptJobItems objcus = new RptJobItems();
                objcus.SetDataSource(ds.Tables["JobItems"]);
                crystalReportViewer1.ReportSource = objcus;
            }
            catch (Exception)
            {

                throw;
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

        public void ItemInfomationReport()
        {
            try
            {
                var dt = (List<SearchInventoryReport>)(new InventoryInfomationDbService().ReadReportInfomation().Content);
                DSReports ds = new DSReports();
                foreach (var items in dt)
                {
                    ds.Tables["ItemSearch"].Rows.Add(items.Name, items.Qty, items.RegDate, items.PriceIn);
                }
                SearchItemReport objcus = new SearchItemReport();
                objcus.SetDataSource(ds.Tables["ItemSearch"]);
                crystalReportViewer1.ReportSource = objcus;
            }
            catch { throw; }

        }
    }


}
