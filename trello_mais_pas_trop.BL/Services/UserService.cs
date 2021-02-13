using System;
using System.Collections.Generic;
using System.Linq;
using trello_mais_pas_trop.DAL.Models;
using trello_mais_pas_trop.DAL;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net;

namespace trello_mais_pas_trop.BL.Services
{
    public class UserService : IUserService
    {
        protected readonly TrelloMptContext _trelloContext;

        public UserService(TrelloMptContext trelloContext)
        {
            _trelloContext = trelloContext;
        }

        public List<User> GetAllUsers()
        { 
            try
            {
                return _trelloContext.Users.Include(u => u.TaskUser).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public User AddUser(string name)
        {
            try
            {
                User user = new User();
                user.Name = name;
                _trelloContext.Users.Add(user);
                _trelloContext.SaveChanges();

                return user;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                return _trelloContext.Users.Include(u => u.TaskUser).FirstOrDefault(x => x.ID == id);

            }
            catch (Exception)
            {
                throw new Exception("Utilisateur introuvable");
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                User user = _trelloContext.Users.FirstOrDefault(user => user.ID == id);
                
                _trelloContext.Remove(user);
                _trelloContext.SaveChanges();

            } catch (Exception)
            {
                throw new Exception("Utilisateur introuvable");
            }
            
        }

        public void EditUser(User in_user)
        {
            _trelloContext.Entry(in_user).State = EntityState.Modified;

            try
            {
                _trelloContext.SaveChanges();

            } catch (DbUpdateConcurrencyException)
            {

                throw new Exception("Utilisateur non trouvé");
            }
            
        }
    }
}
