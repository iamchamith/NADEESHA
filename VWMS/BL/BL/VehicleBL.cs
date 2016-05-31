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
    public class VehicleBL
    {
        #region vehicle
        public static ReturnObject UpdateVehicle(VehicleModel objmodel, DBQ dbq)
        {

         ReturnObject validate = null;
            try
            {
                if (dbq == DBQ.Insert)
                {
                    validate = ValidateBrandObject(objmodel);
                    return (validate.MessageCode == MessageCode.InputError) ? validate :
                        (VehicleDAL.InsertVehicle(objmodel)) ? new ReturnObject { Message = "Insert is succces", MessageCode = MessageCode.Success } :
                        new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                        ;

                }
                else if (dbq == DBQ.Update)
                {
                    validate = ValidateBrandObject(objmodel);
                    return (validate.MessageCode == MessageCode.InputError) ? validate :
                       (VehicleDAL.UpdateVehicle(objmodel)) ? new ReturnObject { Message = "Update is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
                else
                {
                    return 
                       (VehicleDAL.DeleteVehicle(objmodel)) ? new ReturnObject { Message = "Delete is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
            }
            catch (Exception ex)
            {

                return HELPER.Validation.SystemError(ex);
            }
        }

        private static ReturnObject ValidateBrandObject(VehicleModel objmodel)
        {

            StringBuilder message = new StringBuilder();
            bool Isvalied = true;
            if (string.IsNullOrWhiteSpace(objmodel.ChassiNumber))
            {
                Isvalied = false;
                message.Append("chassi number requred. \n");
            }
            if (string.IsNullOrWhiteSpace(objmodel.EngineNumber))
            {
                Isvalied = false;
                message.Append("Engine number requred. \n");
            }

            return Isvalied ? new ReturnObject { MessageCode = MessageCode.Success } :
                new ReturnObject { MessageCode = MessageCode.InputError, Message = message.ToString() };
        }

        public static ReturnObject SelectVehicle()
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = VehicleDAL.SelectVehicle().Tables[0]
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }
        public static ReturnObject VehicleReport()
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = VehicleDAL.VehicleReport().Tables[0]
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }
        //static List<VehicleModel> TableToModel(DataTable dt)
        //{

        //    //   VEHICLE_ID , BRAND, MODEL, ENGINE_NUMBER, CHASSI_NUMBER, DISCRIPTION, OWNER, USER_EMAIL, ENABLE, REG_DATE
        //    List<VehicleModel> lst = new List<VehicleModel>();
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        lst.Add(new VehicleModel
        //        {
        //            VehicleID = item["VEHICLE_ID"].ToString(),
        //            Brand = new BrandsModel { ID = int.Parse(item["BRAND"].ToString()) },
        //            Discription = item["DISCRIPTION"].ToString(),
        //            Model = new BrandModelModel { ID = int.Parse(item["MODEL"].ToString()) },
        //            Enable = (EEnable)int.Parse(item["ENABLE"].ToString()),
        //            Owner = new CustomerModel { ID = int.Parse(item["OWNER"].ToString()) },
        //            EngineNumber = item["ENGINE_NUMBER"].ToString(),
        //            ChassiNumber = item["CHASSI_NUMBER"].ToString(),
        //            UserEmail = item["USER_EMAIL"].ToString(),
        //            RegDate = Convert.ToDateTime(item["REG_DATE"].ToString())
        //        });
        //    }
        //    return lst;
        //}

        #endregion

     
    }
}
