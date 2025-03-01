using AutoMapper;
using StamingRobot.Repository.Entities;
using StampingRobot.Service.BussinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Mapper
{
    public class MapperConfigProfile : Profile
    {
        public MapperConfigProfile()
        {
            CreateMap<ProductModel, Product>().ReverseMap();
            CreateMap<RobotModel, Robot>().ReverseMap();
            CreateMap<StampModel, Stamp>().ReverseMap();
            CreateMap<StampingSessionModel, StampingSession>().ReverseMap();
            CreateMap<StampingJobModel, StampingJob>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<TaskAssignmentModel, TaskAssignment>().ReverseMap();
        }
    }
}
