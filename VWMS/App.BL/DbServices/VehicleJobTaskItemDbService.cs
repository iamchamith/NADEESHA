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
                x.Discription = obj.Discription;
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
    }
}

