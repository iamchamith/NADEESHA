using App.BL.DbServices;
using m = App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.DbServices
{
    public class ModelDbService : Repo
    {
        public DetailModel Create(m.Model obj)
        {
            try
            {
                dba.Models.Add(obj);
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        public DetailModel Update(m.Model obj)
        {

            try
            {
                var x = dba.Models.Where(p => p.ID == obj.ID).FirstOrDefault();
                if (x == null)
                {
                    throw new Exception("invalied item");
                }
                else
                {
                    x.Name = obj.Name;
                    x.Discription = obj.Discription;
                    x.BrandId = obj.BrandId;
                    dba.SaveChanges();
                    return new DetailModel { State = true };
                }
            }
            catch (Exception ex)
            {
                return Error(ex);
            }

        }

        public DetailModel Delete(int id)
        {

            try
            {
                var x = dba.Models.Where(p => p.ID == id).FirstOrDefault();
                dba.Models.Remove(x);
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        public DetailModel Read()
        {

            try
            {
                return new DetailModel
                {
                    State = true,
                    Content = dba.Models.ToList()
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
                    Content = dba.Models.Where(p => p.ID == id).FirstOrDefault()
                };
            }
            catch (Exception ex)
            {
                return Error(ex);

            }
        }
    }
}

