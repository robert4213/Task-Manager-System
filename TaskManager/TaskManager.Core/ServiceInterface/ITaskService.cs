using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Core.Model.Request;
using TaskManager.Core.Model.Response;

namespace TaskManager.Core.ServiceInterface
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponse>> GetAllTasks();
        Task<TaskResponse> GetTaskById(int id);
        Task<IEnumerable<Tasks>> GetTasksByUserId(int id);
        Task<TaskResponse> CreateTask(TaskCreateRequest taskCreateRequest);
        Task<TaskResponse> UpdateTask(TaskCreateRequest taskCreateRequest);
        Task DeleteTask(int id);
    }
}