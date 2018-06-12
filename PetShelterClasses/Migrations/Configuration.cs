namespace PetShelterClasses.Migrations
{
    using PetShelterClasses.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetShelterClasses.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PetShelterClasses.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var PCt = new Pet { Type = "Cat" };
            var PDg =new Pet { Type = "Dog" };
            context.Pets.AddOrUpdate(p => p.Type, PCt, PDg);
            context.SaveChanges();
        }
    }
}
