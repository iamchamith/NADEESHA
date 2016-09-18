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
    public class ItemDbService : Repo
    {
        public DetailModel Create(ItemViewModel obj)
        {
            try
            {
                dba.Items.Add(Mapper.Map<Item>(obj));
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
            }
        }

        public DetailModel Update(ItemViewModel obj)
        {
            try
            {
                var x = dba.Items.Where(p => p.ID == obj.ID).FirstOrDefault();
                if (x == null)
                {
                    throw new Exception("invalied item");
                }
                else
                {
                    x.Name = obj.Name;
                    x.CategoryId = obj.CategoryId;
                    x.Discription = obj.Discription;
                    x.PriceIn = obj.PriceIn;
                    x.PriceOut = obj.PriceOut;
                    x.ReorderLevel = obj.ReorderLevel;
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
                var x = dba.Items.Where(p => p.ID == id).FirstOrDefault();
                dba.Items.Remove(x);
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
                    Content = dba.Items.ToList().Select(x => AutoMapper.Mapper.Map<ItemViewModel>(x)).ToList()
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
                    Content = Mapper.Map<ItemViewModel>(dba.Items.Where(p => p.ID == id).FirstOrDefault())
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
