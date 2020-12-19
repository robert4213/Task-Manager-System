using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Core.Model.Request;
using TaskManager.Core.ServiceInterface;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskHistoryController:ControllerBase
    {
        private ITaskHistoryService _taskHistoryService;

        public TaskHistoryController(ITaskHistoryService taskHistoryService)
        {
            _taskHistoryService = taskHistoryService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllTaskHistory()
        {
            var taskHistory = await _taskHistoryService.ListAllTaskHistory();
            return Ok(taskHistory);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTaskHistoryByUserId(int id)
        {
            var taskHistory = await _taskHistoryService.ListTaskHistoryByUserId(id);
            return Ok(taskHistory);
        }

        [HttpGet]
        [Route("complete/{id}")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var res = await _taskHistoryService.CompleteTask(id);
            return Ok(res);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateTaskHistory(TaskHistoryUpdateRequest taskHistoryUpdateRequest)
        {
            if (!ModelState.IsValid) return BadRequest("Invalidate Data");
            var res = await _taskHistoryService.UpdateTaskHistory(taskHistoryUpdateRequest);
            return Ok(res);
        }
        
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteTaskHistory(int id)
        {
            await _taskHistoryService.DeleteTaskHistory(id);
            return Ok();
        }
    }
}