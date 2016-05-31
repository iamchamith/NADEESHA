using App.BL.DbServices;
using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.BL.DbServices
{
    public class LaboursDbService : Repo
    {
        public DetailModel Create(Labour obj)
        {
            try
            {
                dba.Labours.Add(obj);
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        public DetailModel Update(Labour obj)
        {

            try
            {
                var x = dba.Labours.Where(p => p.ID == obj.ID).FirstOrDefault();
                if (x == null)
                {
                    throw new Exception("invalied item");
                }
                else
                {
                    x.Name = obj.Name;
                    x.Discription = obj.Discription;
                    x.Nic = obj.Nic;
                    x.UserEmail = obj.UserEmail;
                    x.Type = 1;
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
                var x = dba.Labours.Where(p => p.ID == id).FirstOrDefault();
                dba.Labours.Remove(x);
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
                    Content = dba.Labours.ToList()
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
                    Content = dba.Labours.Where(p => p.ID == id).FirstOrDefault()
                };
            }
            catch (Exception ex)
            {
                return Error(ex);

            }
        }
    }
}
