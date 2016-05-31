using BL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BL.DAL;

namespace BL.BL
{
    public class UserBL
    {
        public static ReturnObject Validate(UserModel objModel)
        {
            try
            {
                string message = string.Empty;
                if (!ValidateLogin(objModel, out message)) {

                    return new ReturnObject { Message = message, MessageCode = MessageCode.InputError };
                }

                UserModel UserSession = new UserModel();
                if (!GetSessionModel(UserDAL.Validate(objModel).Tables[0], out UserSession)) {

                    return new ReturnObject { MessageCode = MessageCode.InputError, Message = "invalied inputs." };
                }
                else
                {
                    UserSession.Email = objModel.Email;
                    return new ReturnObject { MessageCode = MessageCode.Success, Content = UserSession };
                }
            }
            catch (Exception ex)
            {

                return HELPER.Validation.SystemError(ex);
            }
        }

        public static ReturnObject UpdateUsers(UserModel objmodel, DBQ dbq)
        {

            ReturnObject validate = null;
            try
            {
                if (dbq == DBQ.Insert)
                {

                    return
                        (UserDAL.InsertUser(objmodel)) ? new ReturnObject { Message = "Insert is succces", MessageCode = MessageCode.Success } :
                        new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                        ;

                }
                else if (dbq == DBQ.Update)
                {

                    return
                       (UserDAL.UpdateUser(objmodel)) ? new ReturnObject { Message = "Update is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
                else
                {

                    return
                       (UserDAL.DeleteUser(objmodel)) ? new ReturnObject { Message = "Delete is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;
                }
            }
            catch (Exception ex)
            {

                return HELPER.Validation.SystemError(ex);
            }
        }

        public static ReturnObject SelectUsers()
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = UserDAL.SelectUser().Tables[0]
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }


        static bool ValidateLogin(UserModel objModel, out string messageOut)
        {

            StringBuilder message = new StringBuilder();
            bool IsOk = true;
            if (string.IsNullOrEmpty(objModel.Email))
            {
                IsOk = false;
                message.Append("email requred. \n");
            }
            if (string.IsNullOrEmpty(objModel.Email))
            {
                IsOk = false;
                message.Append("password requred. \n");
            }
            messageOut = message.ToString();
            return IsOk;
        }

        static bool GetSessionModel(DataTable dt, out UserModel UserSession)
        {
            bool Isvalied = false;
            UserModel objModel = new UserModel();
            foreach (DataRow item in dt.Rows)
            {
                objModel.Name = item["NAME"].ToString();
                objModel.UserType = (EUser)int.Parse(item["STATE"].ToString());
                Isvalied = true;

            }

            UserSession = (Isvalied) ? objModel : null;
            return Isvalied;
        }

        public static ReturnObject ChangePassword(UserModel objModel)
        {
            try
            {
                ReturnObject validateObject = Validate(objModel);
                if (validateObject.MessageCode != MessageCode.Success)
                {
                    return validateObject;
                }
                else
                {
                    return new ReturnObject
                    {
                        MessageCode = (UserDAL.ChangePassword(objModel)) ? MessageCode.Success : MessageCode.SystemError
                    };
                }
            }
            catch (Exception ex)
            {

                return HELPER.Validation.SystemError(ex);
            }

        }

      

        static List<UserModel> TableToObject(DataTable dt)
        {

            // EMAIL, STATE, NAME, NIC
            List<UserModel> lst = new List<UserModel>();
            foreach (DataRow item in dt.Rows)
            {
                lst.Add(new UserModel {
                    Email = item["EMAIL"].ToString(),
                    UserType = (EUser)int.Parse(item["STATE"].ToString()),
                    NIC = item["NIC"].ToString(),
                    Name = item["NAME"].ToString()
                });
            }
            return lst;
        }


        public static ReturnObject SelectUser()
        {

            try
            {
                return new ReturnObject
                {
                    MessageCode = MessageCode.Success,
                    Content = UserDAL.SelectUser().Tables[0]
                };
            }
            catch (Exception ex)
            {
                return HELPER.Validation.SystemError(ex);
            }
        }
    }
}
