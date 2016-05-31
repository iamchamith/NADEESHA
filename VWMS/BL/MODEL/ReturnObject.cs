using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.MODEL
{
    public class ReturnObject
    {
        public object Content { get; set; }
        public MessageCode MessageCode { get; set; }
        public string Message { get; set; }
    }
}
