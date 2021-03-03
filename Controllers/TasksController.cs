using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {

        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        IConfiguration _configuration;


        public TasksController(ILogger<WeatherForecastController> logger, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("get-all-task")]
        public IActionResult Get()
        {
            var result = _unitOfWork.Task.GetAllTask();

            return Ok(result);
        }
        

        [HttpPost("delete/{taskId}")]
        public IActionResult DeleteTask(string taskId, [FromBody] Task task)
        {
            var result = _unitOfWork.Task.DeleteTask(task);

            return Ok(result);
        }

        [HttpPost("update/{taskId}")]
        public IActionResult UpadateTask(string taskId, [FromBody] Task task)
        {
            var result = _unitOfWork.Task.EditTask(taskId,task);

            return Ok(result);

        }

        [HttpPost("create")]
        public IActionResult CreateTask([FromBody] Task newTask)
        {
            var task = new Task()
            {
                CreatedAt = DateTime.Now,
                Description = "",
                TaskName = newTask.TaskName,
                TaskStatus = 1
            };
            var result = _unitOfWork.Task.CreateTask(task);

            return Ok(task);
        }
    }
}
