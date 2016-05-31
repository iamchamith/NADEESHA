using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BL.DAL
{
    public class CostDAL
    {
        public static DataTable GetItemCost(int jobID)
        {

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT     TB_VEHICLE_JOB_TASK_ITEMS.ITEM_ID, TB_ITEMS.NAME, TB_VEHICLE_JOB_TASK_ITEMS.QUANTITY, TB_ITEMS.PRICE_OUT, ");
            sql.Append("   TB_VEHICLE_JOB_TASKS.JOB_ID, TB_ITEMS.ID ");
            sql.Append(" FROM         TB_ITEMS INNER JOIN ");
            sql.Append(" TB_VEHICLE_JOB_TASK_ITEMS ON TB_ITEMS.ID = TB_VEHICLE_JOB_TASK_ITEMS.ITEM_ID INNER JOIN ");
            sql.Append("  TB_VEHICLE_JOB_TASKS ON TB_VEHICLE_JOB_TASK_ITEMS.TASK_ID = TB_VEHICLE_JOB_TASKS.ID ");
            sql.Append(" WHERE(TB_VEHICLE_JOB_TASKS.JOB_ID = " + jobID + ") ");

            return DBAccess.Select(new DataObject
            {
                KeyValue = new Dictionary<string, string>(),
                Sql = sql.ToString()
            }).Tables[0];

        }

        public static DataTable GetLabourCost(int jobID)
        {

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT TB_VEHICLE_JOB_TASKS.ID, TB_TASKS.TASK, TB_VEHICLE_JOB_TASKS.DISCRIPITION, ");

            sql.Append("  TB_VEHICLE_JOB_TASKS.TASK_COST FROM   TB_VEHICLE_JOB_TASKS INNER JOIN TB_TASKS ON TB_VEHICLE_JOB_TASKS.TASK_ID = TB_TASKS.ID ");
            sql.Append("  WHERE(TB_VEHICLE_JOB_TASKS.JOB_ID = " + jobID + ")");

            return DBAccess.Select(new DataObject
            {
                KeyValue = new Dictionary<string, string>(),
                Sql = sql.ToString()
            }).Tables[0];

        }
    }
}
