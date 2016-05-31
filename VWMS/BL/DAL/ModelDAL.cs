using BL.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAL
{
    public class ModelDAL
    {
        public static bool InsertModel(BrandModelModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" INSERT INTO TB_MODELS (BRAND_ID, NAME, DISCRIPTION, ENABLE) ");
                sql.Append("  VALUES (@BRAND_ID, @NAME, @DISCRIPTION, '"+(int)EEnable.Enable+"') ");

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

        public static bool UpdateModel(BrandModelModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" UPDATE    TB_MODELS SET    BRAND_ID =@BRAND_ID, NAME =@NAME, DISCRIPTION =@DISCRIPTION ");
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

        static Dictionary<string, string> GetValueModel(BrandModelModel objModel)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("BRAND_ID", objModel.BrandID.ToString());
            dic.Add("NAME", objModel.Name);
            dic.Add("DISCRIPTION", objModel.Discription);
  
            return dic;
        }

        public static bool DeleteModel(BrandModelModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" UPDATE    TB_MODELS ");
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

        public static DataSet SelectModels()
        {

            try
            {
                var sql = new StringBuilder();
                sql.Append(" SELECT     TB_MODELS.ID, TB_MODELS.BRAND_ID, TB_MODELS.NAME, TB_MODELS.DISCRIPTION, TB_MODELS.ENABLE, TB_BRANDS.NAME AS [BRAND_NAME] ");
                sql.Append(" FROM         TB_MODELS INNER JOIN ");
                sql.Append("   TB_BRANDS ON TB_MODELS.BRAND_ID = TB_BRANDS.ID where TB_MODELS.ENABLE = '"+(int)EEnable.Enable+"'");

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
