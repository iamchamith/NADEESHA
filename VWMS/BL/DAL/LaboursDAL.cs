using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.MODEL;

namespace BL.DAL
{
    public class LaboursDAL
    {
        public static bool InsertLabours(LaboursModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append("INSERT INTO TB_LABOURS (NAME, TYPE, DISCRIPTION, USER_EMAIL, NIC, ENABLE) VALUES   ");
                sql.Append("(@NAME, @TYPE, @DISCRIPTION, @USER_EMAIL, @NIC,'"+(int)EEnable.Enable+"')");

                var dic = GetValueModel(objModel);

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

        public static bool UpdateLabours(LaboursModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" UPDATE    TB_LABOURS ");
                sql.Append(" SET   NAME =@NAME, TYPE =@TYPE, DISCRIPTION =@DISCRIPTION, USER_EMAIL =@USER_EMAIL, NIC = @NIC");
                sql.Append(" WHERE (ID = @ID)");

                var dic = GetValueModel(objModel);
                dic.Add("ID",objModel.ID.ToString());

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

        public static bool DeleteLabours(LaboursModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" UPDATE    TB_LABOURS ");
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

        static Dictionary<string, string> GetValueModel(LaboursModel objModel)
        {
            //@NAME, @TYPE, @DISCRIPTION, @USER_EMAIL, @NIC
            var dic = new Dictionary<string, string>();
            dic.Add("NAME", objModel.Name);
            dic.Add("TYPE", (int)objModel.Type+"");
            dic.Add("DISCRIPTION", objModel.Discription);
            dic.Add("USER_EMAIL", objModel.UserEmail);
            dic.Add("NIC", objModel.NIC);

            return dic;
        }

        public static DataSet SelectLabours()
        {

            try
            {
                var sql = new StringBuilder();
                sql.Append(" SELECT     ID, NAME, TYPE, DISCRIPTION, USER_EMAIL, NIC, ENABLE FROM   TB_LABOURS ");

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
