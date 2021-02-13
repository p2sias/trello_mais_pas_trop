using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello_mais_pas_trop.DAL.Models;

namespace trello_mais_pas_trop.BL.Services
{
    public interface ITaskUserService
    {

        public TaskUser CreateTaskUser(int taskId, int userId);

        public void DeleteTaskUserByIds(int taskId, int userId);
    }
}
