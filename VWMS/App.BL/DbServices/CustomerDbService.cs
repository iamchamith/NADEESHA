using App.BL.DbServices;
using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.DbServices
{
    public class CustomerDbService : Repo
    {
        public CustomerDbService() { }

        public DetailModel Create(Customer obj)
        {
            try
            {
                dba.Customers.Add(obj);
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel Update(Customer obj)
        {

            try
            {
                var x = dba.Customers.Where(p => p.ID == obj.ID).FirstOrDefault();
                if (x == null)
                {
                    throw new Exception("invalied item");
                }
                else
                {
                    x.Name = obj.Name;
                    x.Address = obj.Address;
                    x.Nic = obj.Nic;
                    x.Phone = obj.Phone;
                    x.UserEmale = obj.UserEmale;
                    x.Url = obj.Url;
                    x.Email = obj.Email;
                    dba.SaveChanges();
                    return new DetailModel { State = true };
                }
            }
            catch
            {
                throw;
            }

        }

        public DetailModel Delete(int id)
        {

            try
            {
                var x = dba.Customers.Where(p => p.ID == id).FirstOrDefault();
                dba.Customers.Remove(x);
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
                    Content = dba.Customers.ToList()
                };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel Read(int id)
        {

            try
            {
                return new DetailModel
                {
                    State = true,
                    Content = dba.Customers.Where(p => p.ID == id).FirstOrDefault()
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
