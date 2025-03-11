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
    public class TaskAssignmentService : ITaskAssignmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskAssignmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateTaskAssignment(TaskAssignmentModel assignment)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var taskAssignment = _mapper.Map<TaskAssignment>(assignment);
                
                await _unitOfWork.TaskAssignmentRepository.AddAsync(taskAssignment);
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

        public async Task<bool> DeleteTaskAssignment(int id)
        {
            try
            {
                var taskAssignment = await _unitOfWork.TaskAssignmentRepository.GetByIdAsync(id);
                if (taskAssignment != null)
                {
                    await _unitOfWork.TaskAssignmentRepository.SoftDeleteAsync(taskAssignment);
                    var result = await _unitOfWork.SaveChanges();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TaskAssignmentModel> GetTaskAssignmentById(int id)
        {
            try
            {
                var result = await _unitOfWork.TaskAssignmentRepository.GetByIdAsync(id);
                if (result == null)
                {
                    throw new Exception("Task Assignment not found");
                }

                var resultModel = _mapper.Map<TaskAssignmentModel>(result);

                return resultModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pagination<TaskAssignmentModel>> GetTaskAssignments(PaginationParameter paginationParameter, FilterTaskAssignment filterTaskAssignment)
        {
            try
            {
                var list = await _unitOfWork.TaskAssignmentRepository.GetByConditionAsync(c => (c.IsDeleted.Equals(filterTaskAssignment.IsDelete) || filterTaskAssignment.IsDelete == null)
                                && (filterTaskAssignment.StartDate == null || c.CreatedAt >= filterTaskAssignment.StartDate.Value.ToUniversalTime())
                                && (filterTaskAssignment.EndDate == null || c.CreatedAt <= filterTaskAssignment.EndDate.Value.ToUniversalTime()));

                if (list == null)
                {
                    throw new Exception("Task Assignment is empty.");
                }

                var taskAssignments = list.Skip((paginationParameter.PageIndex - 1) * paginationParameter.PageSize)
                                          .Take(paginationParameter.PageSize)
                                          .ToList();
                var count = list.Count();

                var taskAssignmentModel = _mapper.Map<List<TaskAssignmentModel>>(taskAssignments);

                return new Pagination<TaskAssignmentModel>(taskAssignmentModel, count, paginationParameter.PageIndex, paginationParameter.PageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateTaskAssignment(TaskAssignmentModel assignment)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var taskAssignment = _mapper.Map<TaskAssignment>(assignment);

                await _unitOfWork.TaskAssignmentRepository.UpdateAsync(taskAssignment);
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
                throw new Exception(ex.Message);
            }
        }
    }
}
