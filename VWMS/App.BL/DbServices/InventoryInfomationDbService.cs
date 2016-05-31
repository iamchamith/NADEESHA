using App.BL.DbServices;
using App.Model;
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
                if (x==null)
                {
                    throw new Exception("invalied item id");
                }

                x.Quantity = (obj.Type == 0) ? x.Quantity + obj.Qty : x.Quantity - obj.Qty;
                if (x.Quantity<0)
                {
                    throw new Exception("item count must be > 0");
                }
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch (Exception ex)
            {
                return Error(ex);
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
                    Content = dba.InventoryInfomations.ToList()
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
                    Content = dba.InventoryInfomations.Where(p => p.ID == id).FirstOrDefault()
                };
            }
            catch (Exception ex)
            {
                return Error(ex);

            }
        }
    }
}
