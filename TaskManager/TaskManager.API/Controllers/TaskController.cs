using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Core.Model.Request;
using TaskManager.Core.ServiceInterface;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasks();
            return Ok(tasks);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTasksByUserId(int id)
        {
            var tasks = await _taskService.GetTasksByUserId(id);
            return Ok(tasks);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateTask(TaskCreateRequest taskCreateRequest)
        {
            if (!ModelState.IsValid) return BadRequest("Invalidate Data");
            
            var task = await _taskService.CreateTask(taskCreateRequest);
            return Ok(task);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateTask(TaskCreateRequest taskCreateRequest)
        {
            if (!ModelState.IsValid) return BadRequest("Invalidate Data");
            var task = await _taskService.UpdateTask(taskCreateRequest);
            return Ok(task);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTask(id);
            return Ok();
        }
    }
}