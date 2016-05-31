using BL.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAL
{
    public class CustomerDAL
    {
        public static bool InsertCustomer(CustomerModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append("INSERT INTO TB_CUSTOMER ");
                sql.Append(" (NAME, PHONE, ADDRESS, EMAIL, NIC, USER_EMAIL,CONTACT_PERSON, REG_DATE, ENABLE,URL) ");
                sql.Append(" VALUES     (@NAME, @PHONE, @ADDRESS, @EMAIL, @NIC, @USER_EMAIL,@CONTACT_PERSON, @REG_DATE, @ENABLE,@URL) ");

                var dic = GetValueModel(objModel);
                dic.Add("REG_DATE", DateTime.Today.ToShortDateString());
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

        public static bool UpdateCustomer(CustomerModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" UPDATE    TB_CUSTOMER ");
                sql.Append(" SET    NAME =@NAME, PHONE =@PHONE, ADDRESS =@ADDRESS, EMAIL =@EMAIL, NIC =@NIC,CONTACT_PERSON=@CONTACT_PERSON, USER_EMAIL =@USER_EMAIL,URL = @URL ");
                sql.Append(" WHERE     (ID = @ID)");

                var dic = GetValueModel(objModel);
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

        static Dictionary<string, string> GetValueModel(CustomerModel objModel)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("NAME", objModel.Name);
            dic.Add("PHONE", objModel.Phone);
            dic.Add("ADDRESS", objModel.Address);
            dic.Add("EMAIL", objModel.Email.Replace("@","#"));
            dic.Add("NIC", objModel.NIC);
            dic.Add("USER_EMAIL", objModel.UserEmail);
            dic.Add("CONTACT_PERSON", objModel.ContactPerson);
            dic.Add("URL", objModel.URL);
            return dic;
        }

        public static bool DeleteCustomer(CustomerModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" UPDATE    TB_CUSTOMER ");
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

        public static DataSet SelectCustomer()
        {

            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT   ID, NAME, PHONE, ADDRESS,CONTACT_PERSON, EMAIL, NIC, USER_EMAIL, REG_DATE, ENABLE,URL FROM   TB_CUSTOMER");

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
    }
}
