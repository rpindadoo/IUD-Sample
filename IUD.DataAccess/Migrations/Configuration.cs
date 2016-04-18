using System.Collections.Generic;
using IUD.DataAccess.Entities;

namespace IUD.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IUD.DataAccess.Context.DbEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(IUD.DataAccess.Context.DbEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Users.RemoveRange(context.Users);

            context.Users.AddRange(
              new List<User>(){
              new User() { Id = 0, Name = "Robert", Birthdate = new DateTime(1984,2,18)},
              new User() { Id = 0, Name = "Bob", Birthdate = new DateTime(1950,1,1)},
              }
            );
            //
        }
    }
}
