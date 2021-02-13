using System;
using System.Collections.Generic;
using System.Linq;
using trello_mais_pas_trop.DAL.Models;
using trello_mais_pas_trop.DAL;
using Microsoft.EntityFrameworkCore;

namespace trello_mais_pas_trop.BL.Services
{
    public class TaskService : ITaskService
    {
        protected readonly TrelloMptContext _trelloContext;

        public TaskService(TrelloMptContext trelloContext)
        {
            _trelloContext = trelloContext;
        }

        public List<Task> GetAllTasks()
        {
            try
            {
                return _trelloContext.Tasks.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public Task AddTask(string state, string title, string desc)
        {
            try
            {
                Task task = new Task();
                task.state = state;
                task.title = title;
                task.description = desc;
                _trelloContext.Tasks.Add(task);
                _trelloContext.SaveChanges();

                return task;

            } catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public Task GetTaskById(int id)
        {
            try
            {
                return _trelloContext.Tasks.FirstOrDefault(x => x.ID == id);
            } catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeleteTask(int id)
        {
            
            try
            {
                Task task = _trelloContext.Tasks.FirstOrDefault(task => task.ID == id);

                /*foreach(TaskUser taskuser in task.TaskUser)
                {
                    _trelloContext.Remove(taskuser);
                    _trelloContext.SaveChanges();
                }*/

                _trelloContext.Remove(task);
                _trelloContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void EditTask(Task in_task)
        {
            _trelloContext.Entry(in_task).State = EntityState.Modified;

            try
            {
                _trelloContext.SaveChanges();

            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("Tache non trouvée");
            }
        }
    }
}
