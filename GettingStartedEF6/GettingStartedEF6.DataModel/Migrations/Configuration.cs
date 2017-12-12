using GettingStartedEF6.Domain;

namespace GettingStartedEF6.DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GettingStartedEF6.DataModel.GettingStartedContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //Database.SetInitializer<GettingStartedContext>(new DropCreateDatabaseAlways<GettingStartedContext>());

            //TODO: вместо того, что выше попробовать что-то вроде: update-database -TargetMigration:0 | update-database -force | update-database -force
        }

        protected override void Seed(GettingStartedEF6.DataModel.GettingStartedContext context)
        {
            context.Users.Add(new User
            {
                Name = "SEED user",
                EmailAddress = "seed_test@mail.ru",
                DateCreated = DateTime.Parse("1900-01-01 00:00:00"),
                DateModified = DateTime.Parse("1900-01-01 00:00:00")
            });
        }
    }
}
