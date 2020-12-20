using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;
using TaskManager.Core.Exceptions;
using TaskManager.Core.Model.Request;
using TaskManager.Core.Model.Response;
using TaskManager.Core.RepositoryInterface;
using TaskManager.Core.ServiceInterface;

namespace TaskManager.Infrastructure.Service
{
    public class TaskService:ITaskService
    {
        private readonly IAsyncRepository<Tasks> _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(IAsyncRepository<Tasks> taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskResponse>> GetAllTasks()
        {
            var tasks = await _taskRepository.ListAllAsync();
            return _mapper.Map<IEnumerable<TaskResponse>>(tasks);
        }
        
        public async Task<TaskResponse> GetTaskById(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            return _mapper.Map<TaskResponse>(task);
        }

        public async Task<IEnumerable<Tasks>> GetTasksByUserId(int id)
        {
            var tasks = await _taskRepository.ListAsync(t => t.UserId == id);
            return tasks;
        }

        public async Task<TaskResponse> CreateTask(TaskCreateRequest taskCreateRequest)
        {
            var task = _mapper.Map<Tasks>(taskCreateRequest);
            var taskCreate = await _taskRepository.AddAsync(task);
            var taskRes = await _taskRepository.GetByIdAsync(taskCreate.Id);
            return _mapper.Map<TaskResponse>(taskRes);
        }

        public async Task<TaskResponse> UpdateTask(TaskCreateRequest taskCreateRequest)
        {
            var task = _mapper.Map<Tasks>(taskCreateRequest);
            var taskUpdate = await _taskRepository.UpdateAsync(task);
            var taskRes = await _taskRepository.GetByIdAsync(taskUpdate.Id);
            return _mapper.Map<TaskResponse>(taskRes);
        }

        public async Task DeleteTask(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task is null) throw new NotFoundException("Task",id);
            await _taskRepository.DeleteAsync(task);
        }
    }
}