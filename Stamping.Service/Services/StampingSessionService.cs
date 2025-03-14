﻿using AutoMapper;
using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
using StamingRobot.Repository.Enum;
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
    public class StampingSessionService : IStampingSessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StampingSessionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CreateStampingSession(StampingSessionModel stampingSessionModel)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var stampingSession = _mapper.Map<StampingSession>(stampingSessionModel);
                stampingSession.Status = StampingSessionStatus.NotStarted.ToString();

                await _unitOfWork.StampingSessionRepository.AddAsync(stampingSession);
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

        public async Task<bool> DeleteStampingSession(int id)
        {
            try
            {
                var stampingSession = await _unitOfWork.StampingSessionRepository.GetByIdAsync(id);
                if (stampingSession == null)
                {
                    return false;
                }

                await _unitOfWork.StampingSessionRepository.SoftDeleteAsync(stampingSession);
                var result = await _unitOfWork.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StampingSessionModel> GetStampingSessionById(int id)
        {
            try
            {
                var stampingSession = await _unitOfWork.StampingSessionRepository.GetByIdAsync(id);
                if (stampingSession == null)
                {
                    return null;
                }

                var result = _mapper.Map<StampingSessionModel>(stampingSession);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Pagination<StampingSessionModel>> GetStampingSessions(PaginationParameter paginationParameter, FilterSession filterSession)
        {
            try
            {
                var list = await _unitOfWork.StampingSessionRepository.GetByConditionAsync(c => (c.Status.Equals(filterSession.Status.ToString()) || filterSession.Status == null)
                                    && (c.IsDeleted.Equals(filterSession.IsDelete)|| filterSession.IsDelete == null));

                var result = list.Skip((paginationParameter.PageIndex - 1) * paginationParameter.PageSize)
                                .Take(paginationParameter.PageSize)
                                .ToList();

                var count = list.Count();

                var resultModel = _mapper.Map<List<StampingSessionModel>>(result);

                return new Pagination<StampingSessionModel>(resultModel, count, paginationParameter.PageIndex, paginationParameter.PageSize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateStampingSession(StampingSessionModel stampingSessionModel)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var stampingSession = _mapper.Map<StampingSession>(stampingSessionModel);
                await _unitOfWork.StampingSessionRepository.UpdateAsync(stampingSession);
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

        public async Task<Pagination<StampingSessionModel>> GetStampingSessionsByUser(PaginationParameter paginationParameter, FilterSession filterSession, int id)
        {
            try
            {
                var list = await _unitOfWork.StampingSessionRepository.GetByConditionAsync(c => (c.Status.Equals(filterSession.Status.ToString()) || filterSession.Status == null)
                                    && (c.IsDeleted.Equals(filterSession.IsDelete) || filterSession.IsDelete == null)
                                    && (c.Id == id));

                var result = list.Skip((paginationParameter.PageIndex - 1) * paginationParameter.PageSize)
                                .Take(paginationParameter.PageSize)
                                .ToList();

                var count = list.Count();

                var resultModel = _mapper.Map<List<StampingSessionModel>>(result);

                return new Pagination<StampingSessionModel>(resultModel, count, paginationParameter.PageIndex, paginationParameter.PageSize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
