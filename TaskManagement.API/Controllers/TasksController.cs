using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Common.DTOs;
using TaskManagement.Application.Services;
using static TaskManagement.Application.Common.DTOs.TaskDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

     
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var response = await _taskService.GetAllTasksAsync();
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpGet("task-with-assignees/{id}")]
        public async Task<IActionResult> GetTasksWithAssigneesAsync([FromRoute] long id)
        {
            var response = await _taskService.GetTaskWithAssigneesAsync(id);
            return Ok(response);
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById([FromRoute] long id)
        {
            var response = await _taskService.GetTaskByIdAsync(id);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDTO.CreateTaskDTO dto)
        {
            await _taskService.CreateTaskAsync(dto);
            return Ok();
        }
        [Authorize(Roles = "Admin, User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask([FromRoute] long id, [FromBody] UpdateTaskDTO dto)
        {
            await _taskService.UpdateTaskAsync(id, dto);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("task/{id}")]
        public async Task<IActionResult> DeleteTask(long id)
        {
           var response = await _taskService.DeleteTaskAsync(id);
            return Ok(response);
        }
    }
}
