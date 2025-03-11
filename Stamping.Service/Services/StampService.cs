using AutoMapper;
using StamingRobot.Repository.Commons;
using StamingRobot.Repository.Entities;
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
    public class StampService : IStampService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StampService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateStamp(StampModel model)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var stamp = _mapper.Map<Stamp>(model);

                if (stamp != null)
                {
                    await _unitOfWork.StampRepository.AddAsync(stamp);
                    var result = await _unitOfWork.SaveChanges();
                    if (result > 0)
                    {
                        await _unitOfWork.CommitTransactionAsync();
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw ex;
            }
        }

        public async Task<bool> DeleteStamp(int id)
        {
            try
            {
                var stamp = await _unitOfWork.StampRepository.GetByIdAsync(id);
                if (stamp != null)
                {
                    await _unitOfWork.StampRepository.SoftDeleteAsync(stamp);
                    var result = await _unitOfWork.SaveChanges();
                    if ( result > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StampModel> GetStampById(int id)
        {
            try
            {
                var stamp = await _unitOfWork.StampRepository.GetByIdAsync(id);
                var stampModel = _mapper.Map<StampModel>(stamp);
                if (stamp != null)
                {
                    return stampModel;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Pagination<StampModel>> GetStamps(PaginationParameter paginationParameter, FilterStamp filterStamp)
        {
            try
            {
                var list = await _unitOfWork.StampRepository.GetByConditionAsync(c => (c.InkColor.Equals(filterStamp.InkColor) || filterStamp.InkColor == null)
                                && (c.Type.Equals(filterStamp.Type) || filterStamp.Type == null) && (c.Size.Equals(filterStamp.Size) || filterStamp.Size == null)
                                && (c.IsDeleted.Equals(filterStamp.IsDelete) || filterStamp.IsDelete == null));

                var result = list.Skip((paginationParameter.PageIndex - 1) * paginationParameter.PageSize)
                                .Take(paginationParameter.PageSize)
                                .ToList();

                var count = list.Count();

                var resultModel = _mapper.Map<List<StampModel>>(result);

                return new Pagination<StampModel>(resultModel, count, paginationParameter.PageIndex, paginationParameter.PageSize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateStamp(StampModel model)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var stamp = _mapper.Map<Stamp>(model);
                await _unitOfWork.StampRepository.UpdateAsync(stamp);
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
