using BL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BL.DAL;

namespace BL.DAL
{
    class UserDAL
    {
        public static DataSet Validate(UserModel objModel)
        {
            try
            {

                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT     STATE, NAME FROM   TB_USER ");
                sql.Append(" WHERE     (EMAIL = @EMAIL) AND (PASSWORD = @PASSWORD)");

                var dic = new Dictionary<string, string>();
                dic.Add("EMAIL", objModel.Email);
                dic.Add("PASSWORD", objModel.Password);

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

        public static bool InsertUser(UserModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append("INSERT INTO TB_USER(EMAIL, PASSWORD, NAME, NIC,STATE) VALUES   ");
                sql.Append("(@EMAIL, @PASSWORD,@NAME,@NIC,@STATE)");

                var dic = new Dictionary<string, string>();
                dic.Add("EMAIL", objModel.Email);
                dic.Add("PASSWORD", objModel.Password);
                dic.Add("NAME",objModel.Name );
                dic.Add("NIC", objModel.NIC);
                dic.Add("STATE", ((int)objModel.UserType).ToString());
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

        public static bool UpdateUser(UserModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append("UPDATE TB_USER SET EMAIL =@EMAIL,NAME =@NAME, NIC =@NIC,STATE=@STATE");
                sql.Append(" WHERE (EMAIL = @EMAIL)");

                var dic = new Dictionary<string, string>();
                dic.Add("EMAIL", objModel.Email);
                dic.Add("NAME", objModel.Name);
                dic.Add("NIC", objModel.NIC);
                dic.Add("STATE", ((int)objModel.UserType).ToString());
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

        public static bool DeleteUser(UserModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" UPDATE    TB_USER ");
                sql.Append(" SET   STATE  = '" + (int)EUser.None + "' ");
                sql.Append(" WHERE (EMAIL = @EMAIL)");

                var dic = new Dictionary<string, string>();
                dic.Add("EMAIL", objModel.Email.ToString());

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

        public static bool ChangePassword(UserModel objModel)
        {

            try
            {

                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE    TB_USER SET  PASSWORD =@PASSWORD WHERE  (EMAIL = @EMAIL )  ");

                var dic = new Dictionary<string, string>();
                dic.Add("EMAIL", objModel.Email);
                dic.Add("PASSWORD", objModel.NewPassword);

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

        public static DataSet SelectUser()
        {

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT   EMAIL,STATE, NAME, NIC FROM TB_USER  ");


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
    }
}
