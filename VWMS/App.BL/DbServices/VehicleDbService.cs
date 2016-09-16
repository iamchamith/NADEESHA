using App.BL.DbServices;
using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL
{
    public class VehicleDbService : Repo
    {
        public DetailModel Create(Vehicle obj)
        {
            try
            {
                dba.Vehicles.Add(obj);
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel Update(Vehicle obj)
        {

            try
            {
                var x = dba.Vehicles.Where(p => p.VehicleID == obj.VehicleID).FirstOrDefault();
                if (x == null)
                {
                    throw new Exception("invalied item");
                }
                else
                {
                    x.BrandID = obj.BrandID;
                    x.Discription = obj.Discription;
                    x.ChassiNumber = obj.ChassiNumber;
                    x.EngineNumber = obj.EngineNumber;
                    x.ModelId = obj.ModelId;
                    x.OwnerID = obj.OwnerID;
                    x.Url = obj.Url;
                    x.UserEmail = obj.UserEmail;
                    dba.SaveChanges();
                    return new DetailModel { State = true };
                }
            }
            catch
            {
                throw;
            }

        }

        public DetailModel Delete(string vehicleID)
        {

            try
            {
                var x = dba.Vehicles.Where(p => p.VehicleID == vehicleID).FirstOrDefault();
                dba.Vehicles.Remove(x);
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel Read()
        {

            try
            {
                return new DetailModel
                {
                    State = true,
                    Content = dba.Vehicles.ToList()
                };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel Read(string vehicleID)
        {

            try
            {
                return new DetailModel
                {
                    State = true,
                    Content = dba.Vehicles.Where(p => p.VehicleID == vehicleID).FirstOrDefault()
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
