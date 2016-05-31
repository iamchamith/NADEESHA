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
    public class ModelBL
    {
        public static ReturnObject UpdateModel(BrandModelModel objmodel, DBQ dbq)
        {

            ReturnObject validate = null;
            try
            {
                if (dbq == DBQ.Insert)
                {
                    validate = ValidateModelObject(objmodel);
                    return (validate.MessageCode == MessageCode.InputError) ? validate :
                        (ModelDAL.InsertModel(objmodel)) ? new ReturnObject { Message = "Insert is succces", MessageCode = MessageCode.Success } :
                        new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                        ;

                }
                else if (dbq == DBQ.Update)
                {
                    validate = ValidateModelObject(objmodel);
                    return (validate.MessageCode == MessageCode.InputError) ? validate :
                       (ModelDAL.UpdateModel(objmodel)) ? new ReturnObject { Message = "Update is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
                else
                {
                    return 
                       (ModelDAL.DeleteModel(objmodel)) ? new ReturnObject { Message = "Delete is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
            }
            catch (Exception ex)
            {

                return HELPER.Validation.SystemError(ex);
            }
        }

        private static ReturnObject ValidateModelObject(BrandModelModel objmodel)
        {

            StringBuilder message = new StringBuilder();
            bool Isvalied = true;
            if (string.IsNullOrWhiteSpace(objmodel.Name))
            {
                Isvalied = false;
                message.Append("name requred. \n");
            }
           

            return Isvalied ? new ReturnObject { MessageCode = MessageCode.Success } :
                new ReturnObject { MessageCode = MessageCode.InputError, Message = message.ToString() };
        }

        public static ReturnObject SelectModels()
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content =  ModelDAL.SelectModels().Tables[0] 
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }
         
    }
}
