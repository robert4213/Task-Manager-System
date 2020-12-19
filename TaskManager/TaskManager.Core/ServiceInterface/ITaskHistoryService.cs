using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Core.Model.Request;
using TaskManager.Core.Model.Response;

namespace TaskManager.Core.ServiceInterface
{
    public interface ITaskHistoryService
    {
        Task<IEnumerable<TaskHistoryResponse>> ListAllTaskHistory();
        Task<IEnumerable<TaskHistory>> ListTaskHistoryByUserId(int id);
        // Complete task. Move task from task table to task history table.
        // id: Task id
        Task<TaskHistoryResponse> CompleteTask(int id);
        Task<TaskHistoryResponse> UpdateTaskHistory(TaskHistoryUpdateRequest historyUpdateRequest);
        Task DeleteTaskHistory(int id);


    }
}