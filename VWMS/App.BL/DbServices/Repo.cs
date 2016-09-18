using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Dal;
using App.BL.DbServices;
using App.Model;
using AutoMapper;
namespace App.BL
{
    public class Repo : DBase
    {
        public DBase dba;
        public Repo()
        {
            dba = new DBase();
            Automapper();
        }

        public DetailModel Error(Exception ex)
        {

            return new DetailModel
            {
                Exception = ex,
                State = false,
                Error = EError.ServerError,
                Message = ex.Message
            };
        }

        void Automapper()
        {
            Mapper.CreateMap<VehicleJobTaskItemViewModel, VehicleJobTaskItem>();
            Mapper.CreateMap<VehicleJobTaskItem, VehicleJobTaskItemViewModel>();

            Mapper.CreateMap<VehicleJobTaskLabourViewModel, VehicleJobTaskLabour>();
            Mapper.CreateMap<VehicleJobTaskLabour, VehicleJobTaskLabourViewModel>();

            Mapper.CreateMap<VehicleJobTaskViewModel, VehicleJobTask>();
            Mapper.CreateMap<VehicleJobTask, VehicleJobTaskViewModel>();

            Mapper.CreateMap<VehicleJobViewModel, VehicleJob>();
            Mapper.CreateMap<VehicleJob, VehicleJobViewModel>();

            Mapper.CreateMap<LabourViewModel, Labour>();
            Mapper.CreateMap<Labour, LabourViewModel>();

            Mapper.CreateMap<App.Model.Task, TaskViewModel>();
            Mapper.CreateMap<TaskViewModel, App.Model.Task>();

            Mapper.CreateMap<Vehicle, VehicleViewModel>();
            Mapper.CreateMap<VehicleViewModel, Vehicle>();
        }
    }

}
