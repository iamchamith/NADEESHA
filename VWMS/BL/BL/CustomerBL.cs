using BL.DAL;
using BL.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BL
{
    public class CustomerBL
    {
        public static ReturnObject UpdateBrands(CustomerModel objmodel, DBQ dbq)
        {

            ReturnObject validate = null;
            try
            {
                if (dbq == DBQ.Insert)
                {
 
                    return  
                        (CustomerDAL.InsertCustomer(objmodel)) ? new ReturnObject { Message = "Insert is succces", MessageCode = MessageCode.Success } :
                        new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                        ;

                }
                else if (dbq == DBQ.Update)
                {
              
                    return  
                       (CustomerDAL.UpdateCustomer(objmodel)) ? new ReturnObject { Message = "Update is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
                else
                {
                    
                    return 
                       (CustomerDAL.DeleteCustomer(objmodel)) ? new ReturnObject { Message = "Delete is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
            }
            catch (Exception ex)
            {

                return HELPER.Validation.SystemError(ex);
            }
        }

        //private static ReturnObject ValidateBrandObject(CustomerModel objmodel)
        //{

        //    StringBuilder message = new StringBuilder();
        //    bool Isvalied = true;
        //    if (string.IsNullOrWhiteSpace(objmodel.Name))
        //    {
        //        Isvalied = false;
        //        message.Append("name requred. \n");
        //    }
        //    if (!HELPER.Validation.IsNIC(objmodel.NIC))
        //    {
        //        Isvalied = false;
        //        message.Append("invalied NIC.\n");
        //    }
        //    if (!HELPER.Validation.IsTelephone(objmodel.Phone))
        //    {
        //        Isvalied = false;
        //        message.Append("invalied Phone. \n");
        //    }
           

        //    return Isvalied ? new ReturnObject { MessageCode = MessageCode.Success } :
        //        new ReturnObject { MessageCode = MessageCode.InputError, Message = message.ToString() };
        //}

        public static ReturnObject SelectCustomer()
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content =  CustomerDAL.SelectCustomer().Tables[0] 
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }

        //static List<CustomerModel> TableToModel(DataTable dt)
        //{

        //    //  ID, NAME, PHONE, ADDRESS, EMAIL, NIC, USER_EMAIL, REG_DATE, ENABLE 
        //    List<CustomerModel> lst = new List<CustomerModel>();
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        lst.Add(new CustomerModel
        //        {
        //            ID = int.Parse(item["ID"].ToString()),
        //            Name = item["NAME"].ToString(),
        //            NIC = item["NIC"].ToString(),
        //            Phone = item["PHONE"].ToString(),
        //            Address = item["ADDRESS"].ToString(),
        //            UserEmail = item["USER_EMAIL"].ToString(),
        //            RegDate= Convert.ToDateTime(item["REG_DATE"].ToString()),
        //            Enable = (EEnable)int.Parse(item["ENABLE"].ToString())
        //        });
        //    }
        //    return lst;
        //}
    }
}
