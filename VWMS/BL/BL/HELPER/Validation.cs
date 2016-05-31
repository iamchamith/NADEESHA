using BL.MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BL.BL.HELPER
{
    public class Validation
    {

        // validate email
        public static bool IsValidEmail(string strEmail)
        {
            // Return true if strIn is in valid e-mail format.
            if (strEmail ==null)
            {
                strEmail = "";
            }
            return Regex.IsMatch(strEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        // validate telephone
        public static bool IsTelephone(string strTP)
        {


            if (strTP.Length == 10)
            {
                try
                {
                    double i = double.Parse(strTP);
                }
                catch (Exception)
                {

                    return false;
                }
            }

            return true;
        }


        // validate name
        public static bool IsName(string strName)
        {

            if (Regex.Match(strName, "[A-Z][a-zA-Z]").Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsNumber(string strnumber)
        {
            double outDouble = 0.0;
            return double.TryParse(strnumber,out outDouble);
        }

        // validate NIC
        public static bool IsNIC(string strNIC)
        {
            //880240684V

            bool isOK = true;

            if (strNIC.Length == 10)
            {
                try
                {
                    int i = int.Parse(strNIC.Substring(0, 9));

                    if (strNIC.Substring(9, 1).Equals("V"))
                    {
                        isOK = true;
                    }
                    else
                    {
                        isOK = false;
                    }
                }
                catch { isOK = false; }
            }
            else
            {
                isOK = false;
            }

            return isOK;

        }

        // validate date
        public static bool IsValiedDate(string strvalideDate)
        {

            DateTime d1 = DateTime.Now;
            DateTime d2 = Convert.ToDateTime(strvalideDate);

            TimeSpan t = d1 - d2;
            double NrOfDays = t.TotalDays;

            if (NrOfDays < 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

       public static ReturnObject SystemError(Exception ex){

           return new ReturnObject { MessageCode = MessageCode.SystemError, Message = ex.Message };
       }
 
 
    }
}
