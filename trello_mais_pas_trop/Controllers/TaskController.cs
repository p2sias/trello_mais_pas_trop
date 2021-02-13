using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using trello_mais_pas_trop.BL.Services;
using trello_mais_pas_trop.DAL.Models;

namespace trello_mais_pas_trop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetAllTasks")]
        public List<Task> GetAllTasks()
        {
            return _taskService.GetAllTasks();
        }

        [HttpPost("CreateTask")]
        public Task CreateUser(string state, string title, string desc)
        {
            return _taskService.AddTask(state, title, desc);
        }

        [HttpGet("GetTaskById/{id}")]
        public Task GetTaskById(int id)
        {
            return _taskService.GetTaskById(id);
        }

        [HttpDelete("DeleteTask/{id}")]
        public void DeleteTask(int id)
        {
            _taskService.DeleteTask(id);
        }

        [HttpPut("EditTask")]
        public void EditTask(Task task)
        {
            _taskService.EditTask(task);
        }
    }
}
