using App.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class AutoMapperConfig
    {
        public AutoMapperConfig()
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

            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<UserViewModel, User>();

            Mapper.CreateMap<Item, ItemViewModel>();
            Mapper.CreateMap<ItemViewModel, Item>();
        }
    }
}
