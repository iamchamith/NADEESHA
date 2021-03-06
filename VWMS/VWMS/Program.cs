﻿using App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VWMS.ENTITY;

namespace VWMS
{
    static class Program
    {
        /// <summary>
        ///// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new AutoMapperConfig();
            Application.Run(new FrmLogin());

        }
    }


    #region <Utilities>
    public class Helper
    {
        public static string FilePath = @"G:\STUDENT PROJECTS\NADEESHA\1\VWMS2015-10-4\NADEESHA\VWMS\VWMS\IMAGES\";
        public static bool Confirmation(string caption = "confirmation", string message = " Are you sure ?")
        {

            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void ErrorMessage(string message = "invalid information", string caption = "invalid information")
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void SuccessMessage(string message = "Success", string caption = "Success")
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ErrorMessage(Exception ex, string message = "invalid information", string caption = "invalid information")
        {
            try
            {
                if ((ex.InnerException.InnerException as SqlException).Number == 547)
                {
                    ErrorMessage(message: "This tupple reference to another table", caption: "FK validation error");
                }
                else
                {
                    ErrorMessage();
                }
            }
            catch
            {
                ErrorMessage();
            }
        }
        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }
            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

    }
    #endregion

}
#region <Utilities>
namespace BL.BL.HELPER
{
    public class Validation
    {

        // validate email
        public static bool IsValidEmail(string strEmail)
        {
            // Return true if strIn is in valid e-mail format.
            if (strEmail == null)
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
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
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
            return double.TryParse(strnumber, out outDouble);
        }

        public static bool IsPossitive(string strnumber)
        {
            double outDouble = 0.0;
            if (!double.TryParse(strnumber, out outDouble)) { return false; }
            return outDouble > 0;
        }
        // validate NIC
        public static bool IsNIC(string strNIC)
        {
            try
            {

                bool isOK = true;

                if (strNIC.Length == 10)
                {
                    try
                    {
                        int i = int.Parse(strNIC.Substring(0, 9));

                        if (strNIC.Substring(9, 1).ToUpper().Equals("V"))
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
            catch { return false; }

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
    }


}
#endregion
