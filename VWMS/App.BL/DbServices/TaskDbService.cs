using App.BL.DbServices;
using  m = App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL
{
    public class TaskDbService : Repo
    {
        public DetailModel Create(m.Task obj)
        {
            try
            {
                dba.Tasks.Add(obj);
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel Update(m.Task obj)
        {

            try
            {
                var x = dba.Tasks.Where(p => p.ID == obj.ID).FirstOrDefault();
                if (x == null)
                {
                    throw new Exception("invalied item");
                }
                else
                {
                    x.TaskName = obj.TaskName;
                    x.Discription = obj.Discription;
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
                var x = dba.Tasks.Where(p => p.ID == id).FirstOrDefault();
                dba.Tasks.Remove(x);
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
                    Content = dba.Tasks.ToList()
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
                    Content = dba.Tasks.Where(p => p.ID == id).FirstOrDefault()
                };
            }
            catch
            {
                throw;
            }
        }
    }
}

