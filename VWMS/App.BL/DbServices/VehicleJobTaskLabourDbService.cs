using App.BL.DbServices;
using App.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL
{
    public class VehicleJobTaskLabourDbService : Repo
    {
        public DetailModel CreateVehicleJobTask(VehicleJobTaskLabourViewModel obj)
        {
            try
            {
                dba.VehicleJobTaskLabours.Add(Mapper.Map<VehicleJobTaskLabour>(obj));
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch  
            {
                throw;
            }
        }

        public DetailModel UpdatevehicleTask(VehicleJobTaskLabourViewModel obj)
        {
            try
            {
                var x = dba.VehicleJobTaskLabours.Where(p => p.ID == obj.ID).FirstOrDefault();
                if (x == null)
                {
                    throw new Exception("item not found");
                }
                x.IsClosed = obj.IsClosed;
                x.Discription = obj.Discription;
                x.CloseDateTime = obj.CloseDateTime;
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel DeleteVehicleTasks(int id)
        {
            try
            {
                var x = dba.VehicleJobTaskLabours.Where(p => p.ID == id).FirstOrDefault();
                dba.VehicleJobTaskLabours.Remove(x);
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
            }
        }
        public DetailModel SelectVehicleTask(int TaskId)
        {
            try
            {
 
                return new DetailModel
                {
                    Content = dba.VehicleJobTaskLabours.Where(p => p.TaskId == TaskId).ToList()
                    .Select(x => AutoMapper.Mapper.Map<VehicleJobTaskLabourViewModel>(x)).ToList()
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
