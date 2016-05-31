using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Dal;
using App.BL.DbServices;

namespace App.BL
{
    public class Repo : DBase
    {
        public DBase dba;
        public Repo() {

            dba = new DBase();
        }

        public DetailModel Error(Exception ex) {

            return new DetailModel
            {
                Exception = ex,
                State = false,
                Error = EError.ServerError
            };
        }
    }
}
