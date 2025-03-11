using StamingRobot.Repository.Commons;
using StampingRobot.Service.BussinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Services.Interface
{
    public interface IStampService
    {
        Task<Pagination<StampModel>> GetStamps(PaginationParameter paginationParameter, FilterStamp filterStamp);
        Task<StampModel> GetStampById(int id);
        Task<bool> CreateStamp(StampModel model);
        Task<bool> UpdateStamp(StampModel model);
        Task<bool> DeleteStamp(int id);
    }
}
