using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.MODEL;
using BL.DAL;
using System.Data;
namespace BL.BL
{
    public class TaskBL
    {
        public static ReturnObject UpdateBrands(TaskModel objmodel, DBQ dbq)
        {

            ReturnObject validate = null;
            try
            {
                if (dbq == DBQ.Insert)
                {
                    validate = ValidateTaskObject(objmodel);
                    return (validate.MessageCode == MessageCode.InputError) ? validate :
                        (TaskDAL.InsertTask(objmodel)) ? new ReturnObject { Message = "Insert is succces", MessageCode = MessageCode.Success } :
                        new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                        ;

                }
                else if (dbq == DBQ.Update)
                {
                    validate = ValidateTaskObject(objmodel);
                    return (validate.MessageCode == MessageCode.InputError) ? validate :
                       (TaskDAL.UpdateTask(objmodel)) ? new ReturnObject { Message = "Update is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
                else
                {
                    return (TaskDAL.DeleteTask(objmodel)) ? new ReturnObject { Message = "Delete is succces", MessageCode = MessageCode.Success } :
                     new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                     ;
                }
            }
            catch (Exception ex)
            {

                return HELPER.Validation.SystemError(ex);
            }
        }

        private static ReturnObject ValidateTaskObject(TaskModel objmodel)
        {

            StringBuilder message = new StringBuilder();
            bool Isvalied = true;
            if (string.IsNullOrWhiteSpace(objmodel.Name))
            {
                Isvalied = false;
                message.Append("name requred. \n");
            }
            if (string.IsNullOrWhiteSpace(objmodel.Discription))
            {
                Isvalied = false;
                message.Append("discription requred. \n");
            }

            return Isvalied ? new ReturnObject { MessageCode = MessageCode.Success } :
                new ReturnObject { MessageCode = MessageCode.InputError, Message = message.ToString() };
        }

        public static ReturnObject SelectTask()
        {
            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = TableToModel(TaskDAL.SelectTask().Tables[0])
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }

        static List<TaskModel> TableToModel(DataTable dt)
        {

            // ID, NAME, DISCRIPTION, ENABLE
            List<TaskModel> lst = new List<TaskModel>();
            foreach (DataRow item in dt.Rows)
            {
                lst.Add(new TaskModel
                {
                    ID = int.Parse(item["ID"].ToString()),
                    Name = item["TASK"].ToString(),
                    Discription = item["DISCRIPTION"].ToString(),
                    Enable = (EEnable)int.Parse(item["ENABLE"].ToString())
                });
            }
            return lst;
        }

      
    }
}
