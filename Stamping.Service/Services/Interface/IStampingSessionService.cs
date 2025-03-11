using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
using StampingRobot.Service.BussinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampingRobot.Service.Services.Interface
{
    public interface IStampingSessionService
    {
        Task<Pagination<StampingSessionModel>> GetStampingSessions(PaginationParameter paginationParameter, FilterSession filterSession);
        Task<StampingSessionModel> GetStampingSessionById(int id);
        Task<bool> CreateStampingSession(StampingSessionModel stampingSessionModel);
        Task<bool> UpdateStampingSession(StampingSessionModel stampingSessionModel);
        Task<bool> DeleteStampingSession(int id);
        Task<Pagination<StampingSessionModel>> GetStampingSessionsByUser(PaginationParameter paginationParameter, FilterSession filterSession, int id);
    }
}
