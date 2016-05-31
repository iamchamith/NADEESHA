using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.MODEL;

namespace BL.DAL
{
   public class BookingDAL
    {

        public static bool InsertBookingDetails(BookingModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" INSERT INTO TB_BOOKING ");
                sql.Append(" (VEHICLE_ID, CUS_CONCERN,FROM_TIME, BOOKING_DATE) ");
                sql.Append(" VALUES (@VEHICLE_ID, @CUS_CONCERN, @FROM_TIME, @BOOKING_DATE) ");

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

        public static bool UpdateBookingDetails(BookingModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" UPDATE    TB_BOOKING ");
                sql.Append(" SET   VEHICLE_ID =@VEHICLE_ID,CUS_CONCERN= @CUS_CONCERN,FROM_TIME= @FROM_TIME, BOOKING_DATE=@BOOKING_DATE");
                sql.Append(" WHERE ID = @ID");

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

        static Dictionary<string, string> GetValueModel(BookingModel objModel)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("ID", objModel.ID.ToString());
            dic.Add("VEHICLE_ID", objModel.VEHICLE_ID.ToString());
            dic.Add("CUS_CONCERN", objModel.CUS_CONCERN);
            dic.Add("FROM_TIME", objModel.FROM_TIME.ToString());
            dic.Add("BOOKING_DATE", objModel.BOOKING_DATE.ToShortDateString());
            dic.Add("USER_EMAIL", objModel.USER_EMAIL);

            return dic;
        }

        public static bool DeleteBookingDetails(BookingModel objModel)
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append("DELETE FROM TB_BOOKING ");
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

        public static DataSet SelectAllBookings()
        {

            try
            {
                var sql = new StringBuilder();
                sql.Append(" SELECT TB_BOOKING.ID AS ID, VEHICLE_ID,CUS_CONCERN, BOOKING_DATE,FROM_TIME");
                sql.Append(" FROM TB_BOOKING ORDER BY ID DESC");

                //sql.Append(" SELECT TB_BOOKING.ID AS ID, VEHICLE_ID,CUS_CONCERN, BOOKING_DATE,FROM_TIME");
                //sql.Append(" FROM TB_BOOKING  where BOOKING_DATE between '"+DateTime.Now.ToShortDateString()+"' and '"+DateTime.MaxValue.ToShortDateString()+"' ");


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


        public static DataSet SelectAllBookingsByReservedDate( string date)
        {

            try
            {
                var sql = new StringBuilder();
                sql.Append(" SELECT ID, VEHICLE_ID,CUS_CONCERN, BOOKING_DATE, FROM_TIME");
                sql.Append(" FROM TB_BOOKING WHERE BOOKING_DATE=@BOOKING_DATE");

                var dic = new Dictionary<string, string>();
                dic.Add("BOOKING_DATE", date);
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
