using BL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BL.DAL
{
    public class WSDAL
    {
        #region Register job

        public static bool JobUpdate(JobModel objModel)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE    TB_VEHICLE_JOBS SET   CLOSE_DATE =@CLOSE_DATE, CLOSE_TIME =@CLOSE_TIME, ");
            sql.Append(" USER_EMAIL =@USER_EMAIL, IS_FINISHED =@IS_FINISHED,FINAL_AMOUNT=@FINAL_AMOUNT");
            sql.Append(" WHERE  (ID = @ID)");

            try
            {
                return DBAccess.Update(new DataObject
                {
                    KeyValue = GetValueModelJob(objModel),
                    Sql = sql.ToString()
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool JobInsert(JobModel objModel)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO TB_VEHICLE_JOBS (VEHICLE_NUMBER, TYPE, USER_EMAIL, IS_FINISHED, OPEN_DATE, OPEN_TIME)");
            sql.Append("VALUES (@VEHICLE_NUMBER, @TYPE, @USER_EMAIL, @IS_FINISHED, @OPEN_DATE, @OPEN_TIME);");

            try
            {
                return DBAccess.Update(new DataObject
                {
                    KeyValue = GetValueModelJob(objModel),
                    Sql = sql.ToString()
                });
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
          
        }
        static Dictionary<string, string> GetValueModelJob(JobModel objModel)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("ID", objModel.JobID.ToString());
            dic.Add("VEHICLE_NUMBER", objModel.VehicleNumber);
            dic.Add("TYPE", ((int)objModel.JobType).ToString());
            dic.Add("USER_EMAIL", objModel.UserEmail);
            dic.Add("IS_FINISHED", ((int)objModel.IsFinished).ToString());
            dic.Add("OPEN_DATE", objModel.OpenDate.ToShortDateString());
            dic.Add("OPEN_TIME", objModel.OpenTime.ToShortDateString());
            dic.Add("CLOSE_DATE", objModel.CloseDate.ToShortDateString());
            dic.Add("CLOSE_TIME", objModel.CloseTime.ToShortDateString());
            dic.Add("FINAL_AMOUNT", objModel.FinalAmount.ToString());
            return dic;
        }

        public static DataSet SelectVehicleJob(string vehicleID)
        {

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ID, VEHICLE_NUMBER, TYPE, USER_EMAIL, IS_FINISHED, CLOSE_DATE, CLOSE_TIME, OPEN_DATE, OPEN_TIME,FINAL_AMOUNT ");
            sql.Append(" FROM  TB_VEHICLE_JOBS ");
            sql.Append("  WHERE  (VEHICLE_NUMBER = '" + vehicleID + "') order by ID desc");

            try
            {
                return DBAccess.Select(new DataObject
                {
                    KeyValue = new Dictionary<string,string>(),
                    Sql = sql.ToString()
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region job,vehicle

        public static bool InsertVehicleTask(VehicleTaskModel objModel)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO TB_VEHICLE_JOB_TASKS  (JOB_ID,TASK_ID, DISCRIPITION, USER_EMAIL, DATE, IS_CLOSERD) ");
                sql.Append(" VALUES   (@JOB_ID,@TASK_ID, @DISCRIPITION, @USER_EMAIL, @DATE,  @IS_CLOSERD)");
                var dic = GetValueModelVehicleTask(objModel);

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

        public static bool UpdateVehicleTask(VehicleTaskModel objModel)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE    TB_VEHICLE_JOB_TASKS ");
                sql.Append(" SET    DISCRIPITION =  @DISCRIPITION, USER_EMAIL = @USER_EMAIL, IS_CLOSERD = @IS_CLOSERD ");
                sql.Append(" WHERE     (ID = @ID)");
                var dic = GetValueModelVehicleTask(objModel);

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
        public static bool DeleteVehicleTask(VehicleTaskModel objModel)
        {
     
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("DELETE FROM TB_VEHICLE_JOB_TASKS ");
                sql.Append("  WHERE  (ID = @ID)");
                var dic = GetValueModelVehicleTask(objModel);

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

        public static DataSet SelectVahicleTasks(int jobID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT ID,JOB_ID, TASK_ID,  DISCRIPITION, USER_EMAIL, DATE, IS_CLOSERD,Task_Cost FROM  TB_VEHICLE_JOB_TASKS WHERE JOB_ID = '" + jobID + "' ");
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

        static Dictionary<string, string> GetValueModelVehicleTask(VehicleTaskModel objModelTask)
        {
            var dic = new Dictionary<string, string>();
            TaskModel objModel = objModelTask.Task[0];
            dic.Add("ID", objModelTask.ID.ToString());
            dic.Add("JOB_ID", objModelTask.JobID.ToString());
            dic.Add("TASK_ID", objModel.ID.ToString());
            dic.Add("DISCRIPITION", objModelTask.Discription);
            dic.Add("USER_EMAIL", objModelTask.UserEmail);
            dic.Add("DATE", DateTime.Now.ToShortDateString());
            dic.Add("IS_CLOSERD", ((int)objModelTask.IsFinishied).ToString());

            return dic;
        }

        #endregion

        #region labours

        static Dictionary<string, string> GetValueModelLabourTask(TaskLabour objModelTask)
        {
            var dic = new Dictionary<string, string>();

            dic.Add("ID", objModelTask.ID.ToString());
            dic.Add("TASK_ID", objModelTask.TaskID.ToString());
            dic.Add("LABOUR_ID", objModelTask.LabourID.ToString());
            dic.Add("DISCRIPTION", objModelTask.Discription);
            dic.Add("USER_EMAIL", objModelTask.UserEmail);
            dic.Add("IS_CLOSED", ((int)objModelTask.IsFinied).ToString());
            dic.Add("OPEN_DATE_TIME", string.Format("{0} {1}",DateTime.Now.ToShortDateString(),DateTime.Now.ToShortTimeString()));
            dic.Add("CLOSE_DATE_TIME", string.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
            return dic;
        }

        public static bool InsertTaskLabour(TaskLabour objModel)
        {

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO TB_VEHICLE_JOB_TASK_LABOURS ");
                sql.Append(" (TASK_ID, LABOUR_ID, DISCRIPTION, USER_EMAIL, IS_CLOSED, OPEN_DATE_TIME) ");
                sql.Append(" VALUES     (@TASK_ID, @LABOUR_ID, @DISCRIPTION, @USER_EMAIL, @IS_CLOSED, @OPEN_DATE_TIME)");
                var dic = GetValueModelLabourTask(objModel);

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

        public static bool UpdateTaskLabour(TaskLabour objModel)
        {

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE    TB_VEHICLE_JOB_TASK_LABOURS ");
                sql.Append(" SET  DISCRIPTION =@DISCRIPTION, USER_EMAIL =@USER_EMAIL, IS_CLOSED =@IS_CLOSED,LABOUR_ID=@LABOUR_ID,CLOSE_DATE_TIME =@CLOSE_DATE_TIME ");
                sql.Append("  WHERE     (ID = @ID)");
                var dic = GetValueModelLabourTask(objModel);

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

        public static bool DeleteTaskLabour(TaskLabour objModel)
        {

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("DELETE FROM TB_VEHICLE_JOB_TASK_LABOURS ");
                sql.Append("  WHERE  (ID = @ID)");
                var dic = GetValueModelLabourTask(objModel);

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

        public static DataSet SelectTaskLabour(int taskID)
        {

            StringBuilder sql = new StringBuilder("SELECT   ID, TASK_ID, LABOUR_ID, DISCRIPTION, USER_EMAIL,");
            sql.Append("IS_CLOSED, OPEN_DATE_TIME, CLOSE_DATE_TIME FROM  TB_VEHICLE_JOB_TASK_LABOURS WHERE TASK_ID='" + taskID + "'");

            return DBAccess.Select(new DataObject
            {
                KeyValue = new Dictionary<string,string>(),
                Sql = sql.ToString()
            });
        }
        public static DataSet SelectLabourExists(int taskID,int LabourId)
        {

            StringBuilder sql = new StringBuilder("SELECT  * FROM TB_VEHICLE_JOB_TASK_LABOURS WHERE TASK_ID='" + taskID + "' AND LABOUR_ID='" + LabourId + "'");

            return DBAccess.Select(new DataObject
            {
                KeyValue = new Dictionary<string, string>(),
                Sql = sql.ToString()
            });
        }
        public static DataSet SelectVehicleJobExists(int taskID, int jobId)
        {

            StringBuilder sql = new StringBuilder("SELECT  * FROM TB_VEHICLE_JOB_TASKS WHERE TASK_ID='" + taskID + "' AND JOB_ID='" + jobId + "'");

            return DBAccess.Select(new DataObject
            {
                KeyValue = new Dictionary<string, string>(),
                Sql = sql.ToString()
            });
        }
        public static DataSet SelectitemsExists(int taskID, int itemId)
        {

            StringBuilder sql = new StringBuilder("SELECT  * FROM TB_VEHICLE_JOB_TASK_ITEMS WHERE TASK_ID='" + taskID + "' AND ITEM_ID='" + itemId + "'");

            return DBAccess.Select(new DataObject
            {
                KeyValue = new Dictionary<string, string>(),
                Sql = sql.ToString()
            });
        }
        //public static DataSet SelectJobsByEmpId(string empID)
        //{

        //    StringBuilder sql = new StringBuilder();
        //    sql.Append(" SELECT * ");
        //    sql.Append(" FROM  TB_VEHICLE_JOB_TASK_LABOURS ");
        //    sql.Append("  WHERE  (LABOUR_ID = '" + empID + "')");

        //    try
        //    {
        //        return DBAccess.Select(new DataObject
        //        {
        //            KeyValue = new Dictionary<string, string>(),
        //            Sql = sql.ToString()
        //        });
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        #endregion


        #region
        //ID, TASK_ID, ITEM_ID, QUANTITY, PRICE, DISCRIPTION, USER_EMAIL, DATE)
        static Dictionary<string, string> GetValueModelMaterials(Material objModelTask)
        {
            var dic = new Dictionary<string, string>();

            dic.Add("ID", objModelTask.ID.ToString());
            dic.Add("TASK_ID", objModelTask.Task_ID.ToString());
            dic.Add("ITEM_ID", objModelTask.Item_ID.ToString());
            dic.Add("QUANTITY", objModelTask.Quantity.ToString());
            dic.Add("PRICE", objModelTask.Price.ToString());
            dic.Add("DISCRIPTION", objModelTask.Description.ToString());
            dic.Add("USER_EMAIL", objModelTask.UserEmail);
            dic.Add("DATE", string.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
         
            return dic;
        }
        public static bool InsertMaterial(Material objModel)
        {

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("INSERT INTO TB_VEHICLE_JOB_TASK_ITEMS");
                sql.Append(" (TASK_ID, ITEM_ID, QUANTITY, PRICE, DISCRIPTION, USER_EMAIL, DATE) ");
                sql.Append(" VALUES     (@TASK_ID, @ITEM_ID, @QUANTITY, @PRICE, @DISCRIPTION,@USER_EMAIL, @DATE)");
                var dic = GetValueModelMaterials(objModel);

                bool isOK = DBAccess.Update(new DataObject
                {
                    KeyValue = dic,
                    Sql = sql.ToString()
                });

                if (isOK)
                {
                    return UpdateStock(objModel.Item_ID, objModel.Quantity, "-");
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool UpdateMaterial(Material objModel)
        {

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE    TB_VEHICLE_JOB_TASK_ITEMS ");
                sql.Append(" SET  DISCRIPTION =@DISCRIPTION, ITEM_ID =@ITEM_ID,PRICE =@PRICE,QUANTITY=@QUANTITY");
                sql.Append("  WHERE  (ID = @ID)");
                var dic = GetValueModelMaterials(objModel);

                var isOK = DBAccess.Update(new DataObject
                {
                    KeyValue = dic,
                    Sql = sql.ToString()
                });

                if (isOK)
                {
                    return UpdateStock(objModel.Item_ID, objModel.QuantityDeference,"+");
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool DeleteMaterial(Material objModel)
        {

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM  TB_VEHICLE_JOB_TASK_ITEMS ");
                sql.Append("  WHERE  (ID = @ID)");
                var dic = GetValueModelMaterials(objModel);

                bool isok =  DBAccess.Update(new DataObject
                {
                    KeyValue = dic,
                    Sql = sql.ToString()
                });

                if (isok)
                {
                    return UpdateStock(objModel.Item_ID, objModel.Quantity, "+");
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool UpdateStock(int itemID,int quantiry,string op) {

            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE TB_ITEMS SET QUANTITY = (select QUANTITY from TB_ITEMS where ID = '"+ itemID + "') "+ op + " "+ quantiry + " ");
            sql.Append(" WHERE(ID = '"+ itemID + "') ");
            try
            {
                return DBAccess.Update(new DataObject
                {
                    KeyValue = new Dictionary<string, string>(),
                    Sql = sql.ToString()
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static DataSet SelectMaterials(string taskID)
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("  SELECT ID,TASK_ID, ITEM_ID, QUANTITY, PRICE, DISCRIPTION, USER_EMAIL, DATE ");
            sql.Append(" FROM  TB_VEHICLE_JOB_TASK_ITEMS  ");
            sql.Append("  WHERE  (TASK_ID = '" + taskID + "')");

            try
            {
                return DBAccess.Select(new DataObject
                {
                    KeyValue = new Dictionary<string, string>(),
                    Sql = sql.ToString()
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}
