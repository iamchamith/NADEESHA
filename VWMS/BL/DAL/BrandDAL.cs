using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.MODEL;
using System.Data;

namespace BL.DAL
{
    public class BrandDAL
    {
        public static bool InsertBrand(BrandsModel objModel) {
            try
            {
                var sql = new StringBuilder();
                sql.Append("INSERT INTO TB_BRANDS (NAME, DISCRIPTION, ENABLE) VALUES   ");
                sql.Append("(@NAME, @DISCRIPTION, @ENABLE)");

                var dic = new Dictionary<string,string> ();
                dic.Add("NAME",objModel.Name);
                dic.Add("DISCRIPTION",objModel.Discription);
                dic.Add("ENABLE",string.Format("{0}",(int)EEnable.Enable));

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

        public static bool UpdateBrand(BrandsModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" UPDATE    TB_BRANDS ");
                sql.Append(" SET   NAME = @NAME, DISCRIPTION = @DISCRIPTION ");
                sql.Append(" WHERE (ID = @ID)");

                var dic = new Dictionary<string, string>();
                dic.Add("NAME", objModel.Name);
                dic.Add("DISCRIPTION", objModel.Discription);
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

        public static bool DeleteBrand(BrandsModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" UPDATE    TB_BRANDS ");
                sql.Append(" SET   ENABLE  = '"+(int)EEnable.Disable+"' ");
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

        public static DataSet SelectBrands() {

            try
            {
                var sql = new StringBuilder();
                sql.Append(" SELECT     ID, NAME, DISCRIPTION, ENABLE FROM   TB_BRANDS WHERE ENABLE = '"+(int)EEnable.Enable+"' ");

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
