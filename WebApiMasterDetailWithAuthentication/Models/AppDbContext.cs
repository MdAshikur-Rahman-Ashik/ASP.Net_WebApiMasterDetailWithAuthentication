using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiMasterDetailWithAuthentication.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("AppDbContext")
        {           
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}