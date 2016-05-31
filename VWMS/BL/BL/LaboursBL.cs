using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.DAL;
using BL.MODEL;

namespace BL.BL
{
    public class LaboursBL
    {
        public static ReturnObject UpdateLabours(LaboursModel objmodel, DBQ dbq)
        {

            ReturnObject validate = null;
            try
            {
                if (dbq == DBQ.Insert)
                {
                    validate = ValidateLaboursObject(objmodel);
                    return (validate.MessageCode == MessageCode.InputError) ? validate :
                        (LaboursDAL.InsertLabours(objmodel)) ? new ReturnObject { Message = "Insert is succces", MessageCode = MessageCode.Success } :
                        new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                        ;

                }
                else if (dbq == DBQ.Update)
                {
                    validate = ValidateLaboursObject(objmodel);
                    return (validate.MessageCode == MessageCode.InputError) ? validate :
                       (LaboursDAL.UpdateLabours(objmodel)) ? new ReturnObject { Message = "Update is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
                else
                {
                    validate = ValidateLaboursObject(objmodel);
                    return (validate.MessageCode == MessageCode.InputError) ? validate :
                       (LaboursDAL.DeleteLabours(objmodel)) ? new ReturnObject { Message = "Delete is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
            }
            catch (Exception ex)
            {

                return HELPER.Validation.SystemError(ex);
            }
        }

        private static ReturnObject ValidateLaboursObject(LaboursModel objmodel)
        {

            StringBuilder message = new StringBuilder();
            bool Isvalied = true;
            if (string.IsNullOrWhiteSpace(objmodel.Name))
            {
                Isvalied = false;
                message.Append("name requred. \n");
            }
            if (!HELPER.Validation.IsNIC(objmodel.NIC))
            {
                Isvalied = false;
                message.Append("invalied nic. \n");
            }
            

            return Isvalied ? new ReturnObject { MessageCode = MessageCode.Success } :
                new ReturnObject { MessageCode = MessageCode.InputError, Message = message.ToString() };
        }

        public static ReturnObject SelectLabours()
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = LaboursDAL.SelectLabours().Tables[0]
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }

        static List<LaboursModel> TableToModel(DataTable dt)
        {

            // ID, NAME, DISCRIPTION, ENABLE
            List<LaboursModel> lst = new List<LaboursModel>();
            foreach (DataRow item in dt.Rows)
            {
                lst.Add(new LaboursModel
                {
                    ID = int.Parse(item["ID"].ToString()),
                    Name = item["NAME"].ToString(),
                    Discription = item["DISCRIPTION"].ToString(),
                    Enable = (EEnable)int.Parse(item["ENABLE"].ToString())
                });
            }
            return lst;
        }
    }
}
