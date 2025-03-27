using AutoMapper;
using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
using StamingRobot.Repository.Enum;
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

        public async Task<bool> CreateRobotAsync(RobotModel robotModel)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var robot = _mapper.Map<Robot>(robotModel);
                robot.Status = RobotStatus.Idle.ToString();

                await _unitOfWork.RobotRepository.AddAsync(robot);

                var result = await _unitOfWork.SaveChanges();

                if (result > 0)
                {
                    await _unitOfWork.CommitTransactionAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw ex;
            }
        }

        public async Task<bool> DeleteRobotAsync(int id)
        {
            try
            {
                var robot = await _unitOfWork.RobotRepository.GetByIdAsync(id);

                if (robot == null)
                {
                    throw new Exception("Robot not exist");
                }

                await _unitOfWork.RobotRepository.SoftDeleteAsync(robot);
                await _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Pagination<RobotModel>> GetRobotPagination(PaginationParameter paginationParameter, FilterRobot filter)
        {
            try
            {
                var list = await _unitOfWork.RobotRepository.GetByConditionAsync(c => (c.Model.Equals(filter.Model.ToString()) || filter.Model == null) &&
                                (filter.Name == null || c.Name.Contains(filter.Name)) && (c.Status.Equals(filter.Status.ToString()) || filter.Status == null)
                                && (c.IsDeleted.Equals(filter.IsDelete) || filter.IsDelete == null),
                                i => (filter.Sort == true) ? i.OrderByDescending(c => c.CreatedAt) : i.OrderBy(c => c.CreatedAt)
                                );

                var result = list.Skip((paginationParameter.PageIndex - 1) * paginationParameter.PageSize)
                    .Take(paginationParameter.PageSize)
                    .ToList();

                var resultModel = _mapper.Map<List<RobotModel>>(result);

                return new Pagination<RobotModel>(resultModel, list.Count(), paginationParameter.PageIndex, paginationParameter.PageSize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RobotModel> GetRobotByIdAsync(int id)
        {
            try
            {
                var robot = await _unitOfWork.RobotRepository.GetByIdAsync(id);

                if (robot == null)
                {
                    return null;
                }

                var result = _mapper.Map<RobotModel>(robot);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateRobotAsync(RobotModel robotModel)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var robot = _mapper.Map<Robot>(robotModel);

                await _unitOfWork.RobotRepository.UpdateAsync(robot);
                var result = await _unitOfWork.SaveChanges();
                if (result > 0)
                {
                    await _unitOfWork.CommitTransactionAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw ex;
            }
        }
    }
}
