using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.MODEL;
using System.Data;
namespace BL.DAL
{
    public class TaskDAL
    {
        public static bool InsertTask(TaskModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append("INSERT INTO TB_TASKS (TASK, DISCRIPTION, ENABLE) VALUES   ");
                sql.Append("(@NAME, @DISCRIPTION, @ENABLE)");

                var dic = new Dictionary<string, string>();
                dic.Add("NAME", objModel.Name);
                dic.Add("DISCRIPTION", objModel.Discription);
                dic.Add("ENABLE", string.Format("{0}", (int)EEnable.Enable));

                return DBAccess.Update(new DataObject
                {
                    KeyValue = dic,
                    Sql = sql.ToString()
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool UpdateTask(TaskModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" UPDATE    TB_TASKS ");
                sql.Append(" SET   TASK = @NAME, DISCRIPTION = @DISCRIPTION ");
                sql.Append(" WHERE (ID = @ID)");

                var dic = new Dictionary<string, string>();
                dic.Add("NAME", objModel.Name);
                dic.Add("DISCRIPTION", objModel.Discription);
                dic.Add("ID", objModel.ID.ToString());

                return DBAccess.Update(new DataObject
                {
                    KeyValue = dic,
                    Sql = sql.ToString()
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool DeleteTask(TaskModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" UPDATE    TB_TASKS ");
                sql.Append(" SET   ENABLE  = '" + (int)EEnable.Disable + "' ");
                sql.Append(" WHERE (ID = @ID)");

                var dic = new Dictionary<string, string>();
                dic.Add("ID", objModel.ID.ToString());

                return DBAccess.Update(new DataObject
                {
                    KeyValue = dic,
                    Sql = sql.ToString()
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet SelectTask()
        {

            try
            {
                var sql = new StringBuilder();
                sql.Append(" SELECT  ID, TASK, DISCRIPTION, ENABLE FROM   TB_TASKS ");

                var dic = new Dictionary<string, string>();

                return DBAccess.Select(new DataObject
                {
                    KeyValue = dic,
                    Sql = sql.ToString()
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool CloseJobTask(int taskID, double taskCost)
        {

            StringBuilder sql = new StringBuilder();

            sql.Append(" UPDATE TB_VEHICLE_JOB_TASKS ");
            sql.Append(" SET IS_CLOSERD = '" + (int)EIsFinished.Yes + "', TASK_COST = '" + taskCost + "' ");
            sql.Append(" WHERE(ID = '" + taskID + "') ");

            return DBAccess.Update(new DataObject
            {
                KeyValue = new Dictionary<string, string>(),
                Sql = sql.ToString()
            });
        }
    }
}
