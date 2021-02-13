
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello_mais_pas_trop.DAL.Models;
using trello_mais_pas_trop.BL.Services;


namespace trello_mais_pas_trop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUser")]
        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpPost("CreateUser")]
        public User CreateUser(string name)
        {

            return _userService.AddUser(name);
        }

        [HttpGet("GetUserById/{id}")]
        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpDelete("DeleteUser/{id}")]
        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }

        [HttpPut("EditUser")]
        public void EditUser(User user)
        {
            _userService.EditUser(user);
        }
    }
}
