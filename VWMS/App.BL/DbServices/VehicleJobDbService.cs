﻿using App.BL.DbServices;
using App.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App.Model.Enums;

namespace App.BL
{
    public class VehicleJobDbService : Repo
    {
        public DetailModel CreateVehicleJob(VehicleJobViewModel obj)
        {
            try
            {
                dba.VehicleJobs.Add(Mapper.Map<VehicleJob>(obj));
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel CloseVehicleJob(VehicleJobViewModel obj)
        {
            try
            {
                var x = dba.VehicleJobs.Where(p => p.ID == obj.ID).FirstOrDefault();
                if (x == null)
                {
                    throw new Exception("Entity is not found");
                }
                x.CloseDate = DateTime.Now;
                x.CloseTime = DateTime.Now;
                x.IsFinished = (int)EIsClosed.Closed;
                x.FinalAmount = obj.FinalAmount;
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel SelectvehicleJobs(string vehicleId)
        {
            try
            {
                return new DetailModel
                {
                    Content = dba.VehicleJobs.Where(p => p.VehicleNumber == vehicleId).ToList()
                    .Select(x => AutoMapper.Mapper.Map<VehicleJobViewModel>(x)).ToList().OrderByDescending(p => p.ID).ToList()
                };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel CurrentJobIsFinished(string vehicleId)
        {
            try
            {
                var result = SelectvehicleJobs(vehicleId); ;
                if (!result.State)
                {
                    return result;
                }
                else
                {
                    return new DetailModel
                    {
                        Content
                         = ((List<VehicleJob>)result.Content).Exists(p => p.IsFinished == (int)EIsClosed.NotClosed) ? false : true
                    };
                }
            }
            catch { throw; }
        }

        public bool CheckJobTasksAreClosed(int jobid)
        {

            try
            {
                return (dba.VehicleJobTasks.Count(p => p.IsClosed == (int)EIsClosed.NotClosed && p.JobId == jobid) == 0) ? true : false;
            }
            catch
            {

                throw;
            }
        }
    }
}
