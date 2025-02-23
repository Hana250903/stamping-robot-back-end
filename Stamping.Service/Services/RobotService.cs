using AutoMapper;
using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
using StamingRobot.Repository.Repositories;
using StamingRobot.Repository.Repositories.Interface;
using StampingRobot.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Services
{
    public class RobotService : IRobotService
    {
        private readonly IRobotRepository _robotRepository;
        private readonly IMapper _mapper;

        public RobotService(IRobotRepository robotRepository, IMapper mapper)
        {
            _robotRepository = robotRepository;
            _mapper = mapper;
        }

        public async Task<Pagination<Robot>> GetAllRobotPagination(PaginationParameter paginationParameter, FilterRobot filter)
        {
            var list = await _robotRepository.GetAllWithFilter(filter);

            var result = list.Skip((paginationParameter.PageIndex - 1) * paginationParameter.PageSize)
                .Take(paginationParameter.PageSize)
                .ToList();

            return new Pagination<Robot>(result, list.Count(), paginationParameter.PageIndex, paginationParameter.PageSize);
        }
    }
}
