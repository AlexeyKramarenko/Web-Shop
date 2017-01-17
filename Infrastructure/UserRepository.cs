using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.DAL.POCO;
using WebShop.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Infrastructure;
using WebShop.DAL;
using ApplicationCore.DomainServices;
using ApplicationCore.DomainModel;

namespace WebShop.DAL
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public User GetUser(string username, string password)
        {
            User user = db.Users.FirstOrDefault(a => a.Name == username && a.Password == password);
            if (user != null)
                return user;
            return null;
        }
    } 
}
