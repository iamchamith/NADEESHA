using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model.ViewModel
{
    public class CustomerInvoiceViewModel
    {
        public List<JobItemReportViewModel> JobItemReportViewModel { get; set; }
        public double ItemSum { get; set; }
        public double labourCost { get; set; }
    }
}
