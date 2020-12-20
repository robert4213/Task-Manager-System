using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TaskManager.Core.Entities;
using TaskManager.Core.Exceptions;
using TaskManager.Core.Model.Request;
using TaskManager.Core.Model.Response;
using TaskManager.Core.RepositoryInterface;
using TaskManager.Core.ServiceInterface;

namespace TaskManager.Infrastructure.Service
{
    public class TaskHistoryService:ITaskHistoryService
    {
        private readonly IAsyncRepository<TaskHistory> _taskHistoryRepository;
        private readonly IAsyncRepository<Tasks> _taskRepository;
        private readonly IMapper _mapper;

        public TaskHistoryService( IAsyncRepository<Tasks> taskRepository, IAsyncRepository<TaskHistory> taskHistoryRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _taskHistoryRepository = taskHistoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskHistoryResponse>> ListAllTaskHistory()
        {
            var histories = await _taskHistoryRepository.ListAllAsync();
            return _mapper.Map<IEnumerable<TaskHistoryResponse>>(histories);
        }

        public async Task<TaskHistoryResponse> GetTaskHistoryById(int id)
        {
            var history = await _taskHistoryRepository.GetByIdAsync(id);
            return _mapper.Map<TaskHistoryResponse>(history);
        }

        public async Task<IEnumerable<TaskHistory>> ListTaskHistoryByUserId(int id)
        {
            var histories = await _taskHistoryRepository.ListAsync(th=>th.UserId==id);
            return histories;
        }

        public async Task<TaskHistoryResponse> CompleteTask(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task is null) throw new NotFoundException("Task", id);
            var taskHistory = _mapper.Map<TaskHistory>(task);
            await _taskHistoryRepository.AddAsync(taskHistory);
            var taskHistoryRes = await _taskHistoryRepository.GetByIdAsync(id);
            if (taskHistoryRes is null) throw new FailedExecutionException("Failed to add task to task history.");
            var res = _mapper.Map<TaskHistoryResponse>(taskHistoryRes);
            await _taskRepository.DeleteAsync(task);
            return res;
        }

        public async Task<TaskHistoryResponse> UpdateTaskHistory(TaskHistoryUpdateRequest historyUpdateRequest)
        {
            var taskHistory = _mapper.Map<TaskHistory>(historyUpdateRequest);
            await _taskHistoryRepository.UpdateAsync(taskHistory);
            var taskHistoryRes = await _taskHistoryRepository.GetByIdAsync(historyUpdateRequest.TaskId);
            return _mapper.Map<TaskHistoryResponse>(taskHistoryRes);
        }

        public async Task DeleteTaskHistory(int id)
        {
            var taskHistory = await _taskHistoryRepository.GetByIdAsync(id);
            if (taskHistory is null) throw new NotFoundException("Task History",id);
            await _taskHistoryRepository.DeleteAsync(taskHistory);
        }
        
    }
}