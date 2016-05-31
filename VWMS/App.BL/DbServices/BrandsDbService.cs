using App.BL.DbServices;
using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL
{
    public class BrandsDbService:Repo
    {
        public DetailModel Create(Brand obj) {
            try
            {
                dba.Brands.Add(obj);
                dba.SaveChanges();
                return new DetailModel {State=true };
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        public DetailModel Update(Brand obj) {

            try
            {
                var x = dba.Brands.Where(p => p.ID==obj.ID).FirstOrDefault();
                if (x==null)
                {
                    throw new Exception("invalied item");
                }
                else
                {
                    x.Name = obj.Name;
                    x.Discription = obj.Discription;
                    dba.SaveChanges();
                    return new DetailModel { State = true };
                }
            }
            catch (Exception ex)
            {
                return Error(ex);
            }

        }

        public DetailModel Delete(int id) {

            try
            {
                var x = dba.Brands.Where(p => p.ID == id).FirstOrDefault();
                dba.Brands.Remove(x);
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        public DetailModel Read() {

            try
            {
                return new DetailModel
                {
                    State = true,
                    Content = dba.Brands.ToList() 
                };
            }
            catch (Exception ex)
            {
                return Error(ex); 
               
            }
        }

        public DetailModel Read(int id)
        {

            try
            {
                return new DetailModel
                {
                    State = true,
                    Content = dba.Brands.Where(p => p.ID == id).FirstOrDefault()
                };
            }
            catch (Exception ex)
            {
                return Error(ex);

            }
        }
    }
}
