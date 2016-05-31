using App.BL.DbServices;
using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL
{
    public class UserDbService:Repo
    {
        public DetailModel Login(User obj)
        {
            try
            {
                var x = dba.Users.FirstOrDefault(p => p.Email == obj.Email && p.Password == obj.Password);
                return (x != null) ? (new DetailModel
                    {
                        State = true,
                        Content = x
                    }) : (new DetailModel
                    {
                        State = false,
                        Message = "invalied login",
                        Error = EError.Validation,
                        Exception = new Exception ("invalied login")
                    });
 
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        public DetailModel Register(User obj) {

            try
            {
                dba.Users.Add(obj);
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        public DetailModel UpdateUser(User obj)
        {

            try
            {
                var x = dba.Users.Where(p => p.Email == obj.Email).First();
                x.Name = obj.Name;
                x.Nic = obj.Nic;
                x.State = obj.State;
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        public DetailModel Selectuser() {

            try
            {
                return new DetailModel { 
                 Content = dba.Users.ToList(),
                 State = true
                };
            }
            catch (Exception ex)
            {
                 return Error(ex);
            }
        }
        public DetailModel Selectuser(string email)
        {

            try
            {
                return new DetailModel
                {
                    Content = dba.Users.Where(p=>p.Email == email).First(),
                    State = true
                };
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
        public DetailModel ChangePassword(User obj,string NewPassword)
        {

            try
            {
                var x = dba.Users.FirstOrDefault(p=>p.Email == obj.Email && p.Password == obj.Password);
                if (x == null)
                {
                    return (new DetailModel
                      {
                          State = false,
                          Message = "invalied Current password",
                          Error = EError.Validation,
                          Exception = new Exception("invalied cuttent password")
                      });
                }
                else {

                    x.Password = NewPassword;
                    dba.SaveChanges();
                    return new DetailModel { State = true };
                }

            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }
    }
}
