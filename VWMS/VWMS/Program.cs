using System;
using System.Collections.Generic;
using System.Linq;
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
            Application.Run(new FrmLogin());
            //Application.Run(new frm());
        }
    }

    public class Helper {

        public static bool Confirmation(string caption="confirmation",string message = " Are you sure ?") {

            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void ErrorMessage(string caption = "invalied infomration", string message = "invalied infomration")
        {
              MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
 
    }
}
