﻿using App.BL.DbServices;
using App.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL
{
    public class VehicleJobTaskDbService:Repo
    {
        public DetailModel CreateVehicleJobTask(VehicleJobTaskViewModel obj) {
            try
            {
                dba.VehicleJobTasks.Add(Mapper.Map<VehicleJobTask>(obj));
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch  
            {
                throw;
            }
        }

        public DetailModel UpdatevehicleTask(VehicleJobTaskViewModel obj) {
            try
            {
                var x = dba.VehicleJobTasks.Where(p => p.ID == obj.ID).FirstOrDefault();
                if (x ==null)
                {
                    throw new Exception("task not found");
                }
                x.TaskCost = obj.TaskCost;
                x.Discription = obj.Discription;
                x.IsClosed = obj.IsClosed;
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch 
            {
                throw;
            }
        }

        public DetailModel DeleteVehicleTasks(int id) {
            try
            {
                var x = dba.VehicleJobTasks.Where(p => p.ID == id).FirstOrDefault();
                dba.VehicleJobTasks.Remove(x);
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
            }
        }
        public DetailModel SelectVehicleTask(int jobId) {

            try
            {
                return new DetailModel
                {
                    Content = dba.VehicleJobTasks.Where(p => p.JobId == jobId).ToList()
                    .Select(x => AutoMapper.Mapper.Map<VehicleJobTaskViewModel>(x)).ToList()
                };
            }
            catch
            {
                throw;
            }
        }
        public DetailModel SelectSingleVehicleTask(int taskId) {

            try
            {
                var x = (from c in dba.VehicleJobTasks
                         join o in dba.Tasks
                         on c.TaskId equals o.ID
                         select new
                         {
                             c.ID,
                             c.IsClosed,
                             c.JobId,
                             c.TaskCost,
                             c.UserEmail,
                             c.TaskId,
                             o.TaskName
                         }).FirstOrDefault();
                return new DetailModel
                {
                    Content  = new VehicleJobTaskViewModel {
                        ID = x.ID,
                        IsClosed = x.IsClosed,
                        JobId = x.JobId,
                        TaskCost = x.TaskCost,
                        UserEmail = x.UserEmail,
                        TaskId = x.TaskId,
                        TaskName = x.TaskName,
                    }
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
