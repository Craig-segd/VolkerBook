using VolkerBook.Models;

namespace VolkerBook.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "VolkerBook.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //context.Members.AddOrUpdate(
            //    p => p.Id,
            //    new Models.Members
            //    {
            //        Id = 1,
            //        MemberId = new Guid("e6cac3d2-0713-42df-9efc-3389c881cf80"),
            //        FirstName = "Craig",
            //        LastName = "Taylor",
            //        PhoneNumber = "07769351018",
            //        Role = "COSS"

            //    });
        }
    }
}
