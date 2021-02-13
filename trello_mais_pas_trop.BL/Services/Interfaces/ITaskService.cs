using System;
using System.Collections.Generic;
using System.Linq;
using trello_mais_pas_trop.DAL.Models;

namespace trello_mais_pas_trop.BL.Services
{
    public interface ITaskService
    {
        public List<Task> GetAllTasks();
        public Task AddTask(string state, string title, string desc);
        public Task GetTaskById(int id);
        public void DeleteTask(int id);
        public void EditTask(Task in_task);
    }
}
