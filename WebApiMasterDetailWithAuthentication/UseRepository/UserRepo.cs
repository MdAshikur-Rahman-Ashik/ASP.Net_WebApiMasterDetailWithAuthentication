using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMasterDetailWithAuthentication.Models;

namespace WebApiMasterDetailWithAuthentication.UseRepository
{
    public class UserRepo : IDisposable
    {
        private AppDbContext db;
        public User ValidateUser(string username , string password)
        {
            return db.Users.FirstOrDefault(u=>u.UserName.Equals
            (username, StringComparison.OrdinalIgnoreCase) && u.Password==password );
        }
        public UserRepo()
        {
            db = new AppDbContext();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}