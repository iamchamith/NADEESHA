using App.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.DbServices
{
    public class WizardReporting : Repo
    {
        public DetailModel GetJobItemReport(int jobId)
        {
            try
            {
                string sql = $@"SELECT Items.Name, VehicleJobTaskItem.Quantity, Tasks.TaskName, VehicleJobs.ID, Items.ID AS ItemId
                        FROM  Items INNER JOIN
                         VehicleJobTaskItem ON Items.ID = VehicleJobTaskItem.ItemId INNER JOIN
                         VehicleJobTasks ON VehicleJobTaskItem.TaskId = VehicleJobTasks.ID INNER JOIN
                         VehicleJobs ON VehicleJobTasks.JobId = VehicleJobs.ID INNER JOIN
                         Tasks ON VehicleJobTasks.TaskId = Tasks.ID
                        WHERE   (VehicleJobs.ID = {jobId})";

                return new DetailModel
                {
                    Content = dba.Database.SqlQuery<JobItemReportViewModel>(sql).ToList()
                };
            }
            catch (Exception ex)
            {
                var e = ex;
                throw;
            }
        }

        public DetailModel GetLaborurJobsInfo(int jobId)
        {

            try
            {
                string sql = $@" SELECT Tasks.TaskName, VehicleJobs.ID AS JobId, VehicleJobTaskLabour.TaskId, Labours.ID AS LaboursId, Labours.Name, VehicleJobTaskLabour.ID AS TaskLaburId
                  FROM   VehicleJobs INNER JOIN  VehicleJobTasks ON VehicleJobs.ID = VehicleJobTasks.JobId INNER JOIN
                      Tasks ON VehicleJobTasks.TaskId = Tasks.ID INNER JOIN VehicleJobTaskLabour ON VehicleJobTasks.ID = VehicleJobTaskLabour.TaskId INNER JOIN
                     Labours ON VehicleJobTaskLabour.LabourId = Labours.ID
                  WHERE (VehicleJobs.ID = {jobId});";

                return new DetailModel
                {
                    Content = dba.Database.SqlQuery<JobLaborReportInfo>(sql).ToList()
                };
            }
            catch (Exception ex)
            {
                var e = ex;
                throw;
            }
        }
        public DetailModel SelectItemsByJobId(int jobId)
        {
            try
            {
                string sql = $@" SELECT Items.Name, VehicleJobTaskItem.Quantity, Tasks.TaskName, VehicleJobs.ID, Items.ID AS ItemId, VehicleJobTaskItem.Price
                FROM Items INNER JOIN
                 VehicleJobTaskItem ON Items.ID = VehicleJobTaskItem.ItemId INNER JOIN
                 VehicleJobTasks ON VehicleJobTaskItem.TaskId = VehicleJobTasks.ID INNER JOIN
                  VehicleJobs ON VehicleJobTasks.JobId = VehicleJobs.ID INNER JOIN
                 Tasks ON VehicleJobTasks.TaskId = Tasks.ID
                    WHERE(VehicleJobs.ID = {jobId});";

                var itemList = dba.Database.SqlQuery<JobItemReportViewModel>(sql).ToList();
                double sum = 0.00;
                foreach (var item in itemList)
                {
                    sum += item.Quantity * item.Price ?? 0.00;
                }

                var labourCost = dba.VehicleJobs.FirstOrDefault(p => p.ID == jobId).FinalAmount;

                return new DetailModel
                {
                    Content = new CustomerInvoiceViewModel
                    {
                        ItemSum = sum,
                        JobItemReportViewModel = itemList,
                        labourCost = labourCost ?? 0
                    }
                };
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
