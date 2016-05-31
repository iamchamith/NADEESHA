using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BL.MODEL;

namespace BL.BL
{
    public static class CostBL
    {
        // item cost calc
        public static ReturnObject GetItemCost(int jobid, out double oitemCost)
        {
            DataTable dt = DAL.CostDAL.GetItemCost(jobid);

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Item_id");
            dt2.Columns.Add("Item_name");
            dt2.Columns.Add("Item_quntity");
            dt2.Columns.Add("unit_price");
            dt2.Columns.Add("total_price");
            double itemCost = 0.0;
            foreach (DataRow item in dt.Rows)
            {

                double tuppleCost = double.Parse(item["QUANTITY"].ToString()) * double.Parse(item["PRICE_OUT"].ToString());
                itemCost += tuppleCost;

                dt2.Rows.Add(item["ITEM_ID"].ToString(),
                    item["NAME"].ToString(),
                    item["QUANTITY"].ToString(),
                    item["PRICE_OUT"].ToString() + ".00",
                    string.Format("{0}.00", tuppleCost
                    ));

            }
            oitemCost = itemCost;
            return new ReturnObject
            {
                Content = dt2
            };
        }

        // labour cost calc
        public static ReturnObject GetLabourCost(int jobID,out double fullAmount)
        {
            DataTable dt = DAL.CostDAL.GetLabourCost(jobID);
            double totalAmount = 0.0;
            foreach (DataRow item in dt.Rows)
            {
                try
                {
                    totalAmount += Convert.ToDouble(item["TASK_COST"].ToString());
                }
                catch (Exception)
                {
                    continue;
                }
            }
            fullAmount = totalAmount;
            return new ReturnObject
            {
                Content = dt
            };
        }
    }
}
