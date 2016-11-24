using App.BL.DbServices;
using App.Model;
using App.Model.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL
{
    public class VehicleJobTaskItemDbService : Repo
    {
        public DetailModel CreateJobTaskItem(VehicleJobTaskItemViewModel obj)
        {
            try
            {
                dba.VehicleJobTaskItems.Add(Mapper.Map<VehicleJobTaskItem>(obj));
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel UpdateJobTaskItem(VehicleJobTaskItemViewModel obj)
        {
            try
            {
                var x = dba.VehicleJobTaskItems.Where(p => p.ID == obj.ID).FirstOrDefault();
                if (x == null)
                {
                    throw new Exception("item not found");
                }
                x.Quantity = obj.Quantity;
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel DeleteJobTaskItem(int id)
        {
            try
            {
                var x = dba.VehicleJobTaskItems.Where(p => p.ID == id).FirstOrDefault();
                dba.VehicleJobTaskItems.Remove(x);
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
            }
        }
        public DetailModel SelectJobTaskItem(int taskid)
        {
            try
            {
                return new DetailModel
                {
                    Content = dba.VehicleJobTaskItems.Where(p => p.TaskId == taskid).ToList()
                    .Select(x => AutoMapper.Mapper.Map<VehicleJobTaskItemViewModel>(x)).ToList()
                };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel SelectJobItemCost(int jobId)
        {

            try
            {
                var res = from jobItems in dba.VehicleJobTaskItems
                          join tasks in dba.VehicleJobTasks
                               on jobItems.TaskId equals tasks.ID
                          where tasks.JobId == jobId
                          select new
                          {
                              Price = jobItems.Price,
                              Qty = jobItems.Quantity
                          };

                double sum = 0.0;
                foreach (var item in res)
                {
                    sum += (item.Qty * item.Price.Value ?? 0);
                }
                return new DetailModel
                {
                    Content = sum
                };
            }
            catch (Exception)
            {

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
                return new DetailModel
                {
                    Content = dba.Database.SqlQuery<JobItemReportViewModel>(sql).ToList()
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

