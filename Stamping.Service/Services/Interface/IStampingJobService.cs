using StamingRobot.Repository.Commons;
using StampingRobot.Service.BussinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Services.Interface
{
    public interface IStampingJobService
    {
        Task<Pagination<StampingJobModel>> GetStampingJobPagination(PaginationParameter paginationParameter, FilterStampingJob filter);
        Task<StampingJobModel> GetStampingJobByIdAsync(int id);
        Task<bool> CreateStampingJobAsync(StampingJobModel stampingJobModel);
        Task<bool> UpdateStampingJobAsync(StampingJobModel stampingJobModel);
        Task<bool> DeleteStampingJobAsync(int id);
    }
}
