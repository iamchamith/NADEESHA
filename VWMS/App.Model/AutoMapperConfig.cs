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
        }
    }
}
