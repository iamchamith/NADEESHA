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

        public DetailModel SearchInventory(InventorySearchRequest obj)
        {

            try
            {
                string sql = @"SELECT ID as InvoiceId, ItemID, Qty, Type, RegDate 
                                FROM InventoryInfomation     WHERE ";
                if (obj.IsFromDate)
                {
                    sql += $" RegDate > '{obj.FromDate.ToShortDateString()}'   AND   ";
                }
                if (obj.IsToDate)
                {
                    sql += $" RegDate < '{obj.ToDate.ToShortDateString()}'   AND   ";
                }
                if (obj.IsItem)
                {
                    sql += $" ItemId = '{obj.Item}'   AND   ";
                }
                if (obj.IsStock)
                {
                    sql += $" [Type]  = '{obj.StockType}'   AND   ";
                }

                var d = dba.Database.SqlQuery<InventorySearch>(sql.Substring(0, sql.Length - 7));
                var data = new List<InventorySearchViewModel>();
                foreach (var item in d)
                {
                    data.Add(new InventorySearchViewModel
                    {
                        InvoiceId = item.InvoiceId,
                        ItemId = item.ItemId,
                        Qty = item.Qty,
                        RegDate = item.RegDate + "",
                        Type = item.Type == 0 ? "Stock In" : "Stock Out"

                    });
                }
                return new DetailModel
                {
                    Content = data
                };
            }
            catch (Exception ex)
            {
                var e = ex;
                throw;
            }
        }

        public DetailModel TestCrud(string taskName, string discript)
        {

            string sql = @"insert into dbo.Tasks(TaskName, Discription) values(@TaskName, @Discription)";
            try
            {
                return new DetailModel
                {
                    State = true,
                    Content = dba.Database.SqlQuery<int>(sql, new
                    {
                        TaskName = taskName,
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
