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
            var PetBd = new Pet { Type = "Bird" };
            var PetCt = new Pet { Type = "Cat" };
            var PetCh = new Pet { Type = "Chicken" };
            var PetCk = new Pet { Type = "Cockroaches" };
            var PetDg = new Pet { Type = "Dog" };
            var PetFerret = new Pet { Type = "Ferret" };
            var PetFish = new Pet { Type = "Fish" };
            var PetPig = new Pet { Type = "Guinea pig" };
            var PetHm = new Pet { Type = "Hamster" };
            var PetHd = new Pet { Type = "Hedhehog" };
            var PetHo = new Pet { Type = "Horse" };
            var PetIn = new Pet { Type = "Insects" };
            var PetMs = new Pet { Type = "Mouse" };
            var PetRabbit = new Pet { Type = "Rabbit" };
            var PetSn = new Pet { Type = "Snail" };
            var PetSna = new Pet { Type = "Snake" };


            context.Pets.AddOrUpdate(p => p.Type, PetBd, PetCt, PetCh, PetCk, PetDg, PetFerret, PetFish, PetPig, PetHm, PetHd, PetHo, PetIn, PetMs, PetRabbit, PetSn, PetSna);

            context.SaveChanges();
        }
    }
}
