using BL.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAL
{
    public class VehicleDAL
    {
        #region vehicle
        public static bool InsertVehicle(VehicleModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" INSERT INTO TB_VEHICLE ");
                sql.Append(" (VEHICLE_ID, BRAND, MODEL, ENGINE_NUMBER, CHASSI_NUMBER, DISCRIPTION, OWNER, USER_EMAIL, ENABLE, REG_DATE,URL) ");
                sql.Append(" VALUES     (@VEHICLE_ID, @BRAND, @MODEL, @ENGINE_NUMBER, @CHASSI_NUMBER, @DISCRIPTION, @OWNER, @USER_EMAIL," + (int)EEnable.Enable + ", '" + DateTime.Now.ToShortDateString() + "',@URL) ");

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

        public static bool UpdateVehicle(VehicleModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" UPDATE    TB_VEHICLE ");
                sql.Append(" SET   BRAND =@BRAND, MODEL =@MODEL, ENGINE_NUMBER =@ENGINE_NUMBER, CHASSI_NUMBER =@CHASSI_NUMBER, DISCRIPTION =@DISCRIPTION, OWNER =@OWNER, USER_EMAIL =@USER_EMAIL,URL=@URL");
                sql.Append(" WHERE     (VEHICLE_ID = @VEHICLE_ID)");

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

        static Dictionary<string, string> GetValueModel(VehicleModel objModel)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("VEHICLE_ID", objModel.VehicleID);
            dic.Add("BRAND", objModel.Brand.ID.ToString());
            dic.Add("MODEL", objModel.Model.ID.ToString());
            dic.Add("ENGINE_NUMBER", objModel.EngineNumber);
            dic.Add("CHASSI_NUMBER", objModel.ChassiNumber);
            dic.Add("DISCRIPTION", objModel.Discription);
            dic.Add("OWNER", objModel.Owner.ID.ToString());
            dic.Add("USER_EMAIL", objModel.UserEmail);
            dic.Add("URL", objModel.URL);
            return dic;
        }

        public static bool DeleteVehicle(VehicleModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" UPDATE    TB_VEHICLE ");
                sql.Append(" SET   ENABLE  = '" + (int)EEnable.Disable + "' ");
                sql.Append(" WHERE (VEHICLE_ID = @VEHICLE_ID)");

                var dic = new Dictionary<string, string>();
                dic.Add("VEHICLE_ID", objModel.VehicleID);

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

        public static DataSet SelectVehicle()
        {

            try
            {
                var sql = new StringBuilder();
                sql.Append(" SELECT   VEHICLE_ID , BRAND, MODEL, ENGINE_NUMBER, CHASSI_NUMBER, DISCRIPTION, OWNER, USER_EMAIL, ENABLE, REG_DATE,URL ");
                sql.Append(" FROM       TB_VEHICLE ");

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
        #endregion

        #region Report


//        SELECT   TB_VEHICLE.VEHICLE_ID, TB_VEHICLE.ENGINE_NUMBER, TB_VEHICLE.CHASSI_NUMBER, TB_MODELS.NAME, TB_CUSTOMER.NAME AS [CUSTOMER NAME]
//FROM            TB_VEHICLE INNER JOIN
//                         TB_CUSTOMER ON TB_VEHICLE.OWNER = TB_CUSTOMER.ID LEFT OUTER JOIN
//                         TB_MODELS ON TB_VEHICLE.MODEL = TB_MODELS.ID

        public static DataSet VehicleReport()
        {

            try
            {

                var sql = new StringBuilder();
                sql.Append(" SELECT   TB_VEHICLE.VEHICLE_ID, TB_VEHICLE.ENGINE_NUMBER, TB_VEHICLE.CHASSI_NUMBER, TB_MODELS.NAME, TB_CUSTOMER.NAME AS [CUSTOMER NAME]");
                sql.Append("FROM TB_VEHICLE INNER JOIN   TB_CUSTOMER ON TB_VEHICLE.OWNER = TB_CUSTOMER.ID LEFT OUTER JOIN ");
                sql.Append("  TB_MODELS ON TB_VEHICLE.MODEL = TB_MODELS.ID");
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
        #endregion
    }
}
 