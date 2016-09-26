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
    public class VehicleDbService : Repo
    {
        public DetailModel Create(VehicleViewModel obj)
        {
            try
            {
                dba.Vehicles.Add(Mapper.Map<Vehicle>(obj));
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
                    Content = dba.Vehicles.ToList().Select(x => AutoMapper.Mapper.Map<VehicleViewModel>(x)).ToList()
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
                    Content = Mapper.Map<VehicleViewModel>(dba.Vehicles.Where(p => p.VehicleID == vehicleID).FirstOrDefault())
                };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel ReadVehicleWithCustomer()
        {

            try
            {
                var x = from cust in dba.Customers
                        join v in dba.Vehicles
                             on cust.ID equals v.OwnerID
                        select new
                        {
                            cusNic = cust.Nic,
                            cusName = cust.Name,
                            vnum = v.VehicleID,
                            chassy = v.ChassiNumber,
                            eng = v.EngineNumber
                        };
                var lst = new List<VehicleCustomerViewModel>();
                foreach (var item in x)
                {
                    lst.Add(new VehicleCustomerViewModel
                    {
                        ChassiNumber = item.chassy,
                        CustomerName = item.cusName,
                        CustomerNic = item.cusNic,
                        EngineNumber = item.eng,
                        VehicleID = item.vnum
                    });
                }
                return new DetailModel
                {
                    State = true,
                    Content = lst
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
