using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VWMS.WS
{
    public partial class FrmInputDialog : Form
    {
        public FrmInputDialog()
        {
            InitializeComponent();
        }

        FRMWS x = null;
        public FrmInputDialog(string caption,string labal,object frm)
        {
            InitializeComponent();
            lblText.Text = labal;
            this.Text = caption;

            if (frm is FRMWS)
            {
               x = frm as FRMWS;
            }
            
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                x.SetLabururCost(Convert.ToDecimal(txtValue.Text));
                this.Close();
            }
            catch {
                Helper.ErrorMessage("invalied amount");
            }
        }
    }
}
