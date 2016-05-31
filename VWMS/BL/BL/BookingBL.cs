using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DAL;
using BL.MODEL;

namespace BL.BL
{
   public class BookingBL
    {


       public static ReturnObject UpdateBookings(BookingModel objmodel, DBQ dbq)
       {

           ReturnObject validate = null;
           try
           {
               if (dbq == DBQ.Insert)
               {
                   validate = ValidateBookingObject(objmodel);
                   return (validate.MessageCode == MessageCode.InputError) ? validate :
                       (BookingDAL.InsertBookingDetails(objmodel)) ? new ReturnObject { Message = "Insert is succces", MessageCode = MessageCode.Success } :
                       new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                       ;

               }
               else if (dbq == DBQ.Update)
               {
                   validate = ValidateBookingObject(objmodel);
                   return (validate.MessageCode == MessageCode.InputError) ? validate :
                      (BookingDAL.UpdateBookingDetails(objmodel)) ? new ReturnObject { Message = "Update is succces", MessageCode = MessageCode.Success } :
                      new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                      ;
               }
               else
               {
                   return
                      (BookingDAL.DeleteBookingDetails(objmodel)) ? new ReturnObject { Message = "Delete is succces", MessageCode = MessageCode.Success } :
                      new ReturnObject { Message = "something wrong", MessageCode = MessageCode.SystemError }
                      ;
               }
           }
           catch (Exception ex)
           {

               return HELPER.Validation.SystemError(ex);
           }
       }

       public static ReturnObject SelectBooking()
       {

           try
           {
               return new ReturnObject
               {
                   MessageCode = MessageCode.Success,
                   Content = BookingDAL.SelectAllBookings().Tables[0]
               };
           }
           catch (Exception ex)
           {
               return HELPER.Validation.SystemError(ex);
           }
       }

       public static ReturnObject SelectBookingsByReservedDate(string date)
       {

           try
           {
               return new ReturnObject
               {
                   MessageCode = MessageCode.Success,
                   Content = BookingDAL.SelectAllBookingsByReservedDate(date).Tables[0]
               };
           }
           catch (Exception ex)
           {
               return HELPER.Validation.SystemError(ex);
           }
       }

       private static ReturnObject ValidateBookingObject(BookingModel objmodel)
       {

           StringBuilder message = new StringBuilder();
           bool Isvalied = true;
           if (string.IsNullOrWhiteSpace(objmodel.VEHICLE_ID.ToString()))
           {
               Isvalied = false;
               message.Append("chassi number requred. \n");
           }
           //if (string.IsNullOrWhiteSpace(objmodel.))
           //{
           //    Isvalied = false;
           //    message.Append("Engine number requred. \n");
           //}

           return Isvalied ? new ReturnObject { MessageCode = MessageCode.Success } :
               new ReturnObject { MessageCode = MessageCode.InputError, Message = message.ToString() };
       }


    }
}
