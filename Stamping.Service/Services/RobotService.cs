using AutoMapper;
using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
using StamingRobot.Repository.Repositories;
using StamingRobot.Repository.Repositories.Interface;
using StamingRobot.Repository.UnitOfWork;
using StamingRobot.Repository.UnitOfWork.Interface;
using StampingRobot.Service.BussinessModels;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RobotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Pagination<RobotModel>> GetAllRobotPagination(PaginationParameter paginationParameter, FilterRobot filter)
        {
            var list = await _unitOfWork.RobotRepository.GetByConditionAsync(c => c.Model.Equals(filter.Model) || filter.Model == null);

            var result = list.Skip((paginationParameter.PageIndex - 1) * paginationParameter.PageSize)
                .Take(paginationParameter.PageSize)
                .ToList();

            var resultModel = _mapper.Map<List<RobotModel>>(result);

            return new Pagination<RobotModel>(resultModel, list.Count(), paginationParameter.PageIndex, paginationParameter.PageSize);
        }
    }
}
