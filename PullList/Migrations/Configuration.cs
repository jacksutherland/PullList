namespace PullList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PullList.Models;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<PullList.DataAccess.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PullList.DataAccess.DataContext context)
        {
            WebSecurity.InitializeDatabaseConnection("SimpleMembership", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            
            if (!WebSecurity.UserExists("jacksutherl@gmail.com"))
            {
                WebSecurity.CreateUserAndAccount("jacksutherl@gmail.com", "4798jack");
                int userId = WebSecurity.GetUserId("jacksutherl@gmail.com");

                context.UserDetails.AddOrUpdate(x => x.Email,
                    new UserDetail()
                    {
                        UserId = userId, FirstName = "Jack", LastName = "Sutherland", Email = "jacksutherl@gmail.com", Phone = "7049963439",
                        Active = true, IsAdmin = true, EmailNotifications = true, SMSNotifications = true
                    }
                );
            }
        }
    }
}
