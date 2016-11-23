using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class Enums
    {
        public enum EIsClosed
        {
            Closed = 2,
            NotClosed = 1
        }
        public enum EReports
        {
            Customers = 1,
            Vehicle = 2,
            Labours = 3,
            Items = 4,
            SearchItemReport = 5
        }

        public enum EUser
        {

            Admin = 1,
            StockKeeper = 2,
            Maneger = 3,
            None = 4
        }
        public enum InventoryType
        {
            stockIn = 1,
            stockOut = 2
        }
    }
}
