using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model.ViewModel
{
    public class InventorySearchRequest {

        public DateTime FromDate { get; set; }
        public bool IsFromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsToDate { get; set; }
        public int Item { get; set; }
        public bool IsItem { get; set; }
        public int StockType { get; set; }
        public bool IsStock { get; set; }
    }

    public class InventorySearch
    {
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public int Qty { get; set; }
        public int Type { get; set; }
        public DateTime RegDate { get; set; }
    }

    public class InventorySearchViewModel
    {
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public int Qty { get; set; }
        public string Type { get; set; }
        public string RegDate { get; set; }
    }
}
