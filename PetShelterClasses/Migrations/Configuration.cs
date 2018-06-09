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

            var PetCt = new Pet { Type = "Cat" };
            var PetDg = new Pet { Type = "Dog" };
            var PetFh = new Pet { Type = "Fish" };
            var PetBd = new Pet { Type = "Bird" };
            var PetGg = new Pet { Type = "Guinea pig" };
            var PetMe = new Pet { Type = "Home mouse" };
            var PetRt = new Pet { Type = "Rabbit" };
            var PetDt = new Pet { Type = "Decorative rat" };
            var PetUn = new Pet { Type = "Pygmy hedgehog" };
            var PetHr = new Pet { Type = "Hamster" };
            var PetSl = new Pet { Type = "Snail" };
            var PetFx = new Pet { Type = "Fox" };
            var PetIt = new Pet { Type = "Insect" };
            var PetSe = new Pet { Type = "Snake" };
            context.Pets.AddOrUpdate(p => p.Type, PetBd, PetCt, PetDg, PetDt, PetFh, PetFx, PetGg, PetHr, PetIt, PetMe, PetRt, PetSe,PetSl,PetUn);
            context.SaveChanges();

        }
    }
}
