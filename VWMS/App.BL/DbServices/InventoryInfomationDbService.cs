using App.BL.DbServices;
using App.Model;
using App.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL
{
    public class InventoryInfomationDbService : Repo
    {
        public DetailModel Insert(InventoryInfomation obj)
        {
            try
            {
                dba.InventoryInfomations.Add(obj);
                var x = dba.Items.Where(p => p.ID == obj.ItemID).FirstOrDefault();
                if (x == null)
                {
                    throw new Exception("invalied item id");
                }

                x.Quantity = (obj.Type == 0) ? x.Quantity + obj.Qty : x.Quantity - obj.Qty;
                if (x.Quantity < 0)
                {
                    throw new Exception("item count must be > 0");
                }
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel Delete(int orderID)
        {

            try
            {
                var c = dba.InventoryInfomations.Where(p => p.ID == orderID).First();
                int ItemId = c.ItemID;

                var x = dba.Items.Where(p => p.ID == ItemId).FirstOrDefault();
                if (x == null)
                {
                    throw new Exception("invalied item id");
                }

                x.Quantity = x.Quantity - c.Qty;
                if (x.Quantity < 0)
                {
                    throw new Exception("item count must be > 0");
                }
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
                    Content = dba.InventoryInfomations.ToList().OrderByDescending(p => p.ID).ToList()
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
                    Content = dba.InventoryInfomations.Where(p => p.ID == id).FirstOrDefault()
                };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel ReadReportInfomation()
        {

            string sql = @"SELECT   Items.Name, InventoryInfomation.Qty, InventoryInfomation.RegDate, Items.PriceIn
                FROM Items INNER JOIN InventoryInfomation ON Items.ID = InventoryInfomation.ItemID ";
            try
            {
                return new DetailModel
                {
                    State = true,
                    Content = dba.Database.SqlQuery<SearchInventoryReport>(sql).ToList()
                };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel TestCrud(string taskName,string discript) {

            string sql = @"insert into dbo.Tasks(TaskName, Discription) values(@TaskName, @Discription)";
            try
            {
                return new DetailModel
                {
                    State = true,
                    Content = dba.Database.SqlQuery<int>(sql, new { TaskName = taskName,
                        Discription = discript
                    })
                };
            }
            catch
            {
                throw;
            }
        }

       

    }
}
