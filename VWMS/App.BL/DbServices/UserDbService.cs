using App.BL.DbServices;
using App.Model;
using App.Model.ViewModel;
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
            catch
            {
                throw;
            }
        }

        public DetailModel Register(User obj) {

            try
            {
                dba.Users.Add(obj);
                dba.SaveChanges();
                return new DetailModel { State = true };
            }
            catch
            {
                throw;
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
            catch
            {
                throw;
            }
        }

        public DetailModel Selectuser() {

            try
            {
                return new DetailModel { 
                 Content = dba.Users.ToList().Select(x => AutoMapper.Mapper.Map<UserViewModel>(x)).ToList(),
                 State = true
                };
            }
            catch
            {
                throw;
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
            catch
            {
                throw;
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
            catch
            {
                throw;
            }
        }


        public DetailModel GetUserInfo() {

            try
            {
                var obj = dba.Database.SqlQuery<UserReportViewModel>("select email as Email, state as State, name as Name, nic as Nic  from[user]").ToList();

                return new DetailModel
                {
                    Content = obj
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
