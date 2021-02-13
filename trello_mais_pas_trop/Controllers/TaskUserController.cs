using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using trello_mais_pas_trop.BL.Services;
using trello_mais_pas_trop.DAL.Models;

namespace trello_mais_pas_trop.Controllers
{
    public class TaskUserController : ControllerBase
    {
        readonly ITaskUserService _taskUserService;

        public TaskUserController(ITaskUserService taskUserService)
        {
            _taskUserService = taskUserService;
        }

        [HttpPost("CreateTaskUser")]
        public TaskUser CreateTaskUser(int userId, int taskId)
        {
            return _taskUserService.CreateTaskUser(taskId, userId);
        }

        [HttpDelete("DeleteTaskUserByIds/{taskId}/{userId}")]
        public void DeleteTaskUserByIds(int taskId, int userId)
        {
               _taskUserService.DeleteTaskUserByIds(taskId, userId);
        }
        
    }
}
