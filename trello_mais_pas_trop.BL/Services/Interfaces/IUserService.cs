using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello_mais_pas_trop.DAL.Models;

namespace trello_mais_pas_trop.BL.Services
{
    public interface IUserService
    {
        public List<User> GetAllUsers();
        public User AddUser(string name);
        public User GetUserById(int id);
        public void DeleteUser(int id);

        public void EditUser(User user);
    }
}
