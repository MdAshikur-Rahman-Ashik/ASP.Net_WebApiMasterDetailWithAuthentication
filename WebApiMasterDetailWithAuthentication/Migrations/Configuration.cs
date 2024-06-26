namespace WebApiMasterDetailWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiMasterDetailWithAuthentication.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApiMasterDetailWithAuthentication.Models.AppDbContext context)
        {
            context.Products.AddOrUpdate(x => x.ProductId,
                new Models.Product() { ProductId = 1, ProductName = "laptop" },
                new Models.Product() { ProductId = 2, ProductName = "Mobile" },
                new Models.Product() { ProductId = 3, ProductName = "Refrigerator" }
             );

            context.Users.AddOrUpdate(x => x.UserId,
                new Models.User() { UserId = 1, UserName = "nishat", Password = "1234", Email = "nishat@gmail.com", Roles = "Admin,User" });
        }
    }
}
