using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello_mais_pas_trop.DAL;
using trello_mais_pas_trop.DAL.Models;


namespace trello_mais_pas_trop.BL.Services
{
    public class TaskUserService : ITaskUserService
    {
        readonly TrelloMptContext _trelloContext;
        public TaskUserService(TrelloMptContext trelloContext)
        {
            _trelloContext = trelloContext;
        }


        public TaskUser CreateTaskUser(int taskId, int userId)
        {
            try
            {
                TaskUser taskuser = new TaskUser();
                taskuser.UserId = userId;
                taskuser.TaskId = taskId;
                _trelloContext.TaskUser.Add(taskuser);
                _trelloContext.SaveChanges();

                return taskuser;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeleteTaskUserByIds(int taskId, int userId)
        {
           
            try
            {
                TaskUser taskuser = _trelloContext.TaskUser.FirstOrDefault(taskuser => taskuser.TaskId == taskId && taskuser.UserId == userId);

                if (taskuser.Task.state == "ongoing" || taskuser.Task.state == "done") throw new Exception();

                _trelloContext.Remove(taskuser);
                _trelloContext.SaveChanges();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
