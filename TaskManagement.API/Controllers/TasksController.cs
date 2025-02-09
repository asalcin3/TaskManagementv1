using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Common.DTOs;
using TaskManagement.Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.API.Controllers
{
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
        [HttpGet("getAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var response = await _taskService.GetAllTasksAsync();
            return Ok(response);
        }
        
    }
}
