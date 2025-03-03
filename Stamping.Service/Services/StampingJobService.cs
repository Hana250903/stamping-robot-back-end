using AutoMapper;
using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
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
    public class StampingJobService : IStampingJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StampingJobService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateStampingJobAsync(StampingJobModel stampingJobModel)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var stampingJob = _mapper.Map<StampingJob>(stampingJobModel);

                await _unitOfWork.StampingJobRepository.AddAsync(stampingJob);
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

        public Task<bool> DeleteStampingJobAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination<StampingJobModel>> GetStampingJobPagination(PaginationParameter paginationParameter, FilterStampingJob filter)
        {
            try
            {
                var stampingJob = await _unitOfWork.StampingJobRepository.GetByConditionAsync(c => c.Status.Equals(filter.Status));

                var result = stampingJob.Skip((paginationParameter.PageIndex - 1) * paginationParameter.PageSize)
                    .Take(paginationParameter.PageSize)
                    .ToList();

                var total = stampingJob.Count();
                var resultModel = _mapper.Map<List<StampingJobModel>>(result);

                return new Pagination<StampingJobModel>(resultModel, total, paginationParameter.PageIndex, paginationParameter.PageSize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StampingJobModel> GetStampingJobByIdAsync(int id)
        {
            try
            {
                var stampingJob = await _unitOfWork.StampingJobRepository.GetByIdAsync(id);
                return _mapper.Map<StampingJobModel>(stampingJob);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateStampingJobAsync(StampingJobModel stampingJobModel)
        {
            await _unitOfWork.BeginTransactionAsync();

            throw new NotImplementedException();
        }
    }
}
