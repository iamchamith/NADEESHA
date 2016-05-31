using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.MODEL
{
    public enum ELabourType  
    {

        LABOUR = 1,
        SERVICE_ADVISOR = 2,
        TEAM_LEAD = 3
    }

    public enum EEnable { 
    
        Enable = 1,
        Disable = 2
    }

    public enum EUser { 
    
        Admin = 1,
        StockKeeper = 2,
        Maneger = 3,
        None = 4
    }
    public enum EJobType { 
    
        All = 1,
        Insurence = 2
    }
    public enum EIsFinished { 
    
        No = 1,
        Yes = 2
    }

    public enum MessageCode { 
    
        Success = 0,
        SystemError = 1,
        InputError = 2
    }

    public enum DBQ
    {

        Insert = 1,
        Update = 2,
        Delete = 3,
        Select = 4
    }
    public enum EReports
    {
        Customers = 1,
        Vehicle = 2,
        Labours = 3,
        Items = 4
    }

    public enum InventoryType
    {
        stockIn=1,
        stockOut=2
    }

    public enum EOrderBy { 
    
        Asc = 0,
        Desc = 1
    }
}
