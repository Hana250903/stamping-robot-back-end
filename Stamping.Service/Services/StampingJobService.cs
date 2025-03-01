using StamingRobot.Repository.Commons;
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

        public StampingJobService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateStampingJobAsync(StampingJobModel stampingJobModel)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw ex;
            }

            throw new NotImplementedException();
        }

        public Task<bool> DeleteStampingJobAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<StampingJobModel>> GetAllStampingJobPagination(PaginationParameter paginationParameter, FilterStampingJob filter)
        {
            throw new NotImplementedException();
        }

        public Task<StampingJobModel> GetStampingJobByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStampingJobAsync(StampingJobModel stampingJobModel)
        {
            throw new NotImplementedException();
        }
    }
}
