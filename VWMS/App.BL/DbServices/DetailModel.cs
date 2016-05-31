using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.DbServices
{
    public class DetailModel
    {
        public object Content { get; set; }
        public string Message { get; set; }
        public bool State { get; set; }
        public Exception Exception { get; set; }
        public EError Error { get; set; }
    }

    public enum EError
    {
        Success = 0,
        ServerError = 1,
        Validation = 2
    }
}
