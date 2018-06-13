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
            var PetHm = new Pet { Type = "Hamster" };
            var PetPig = new Pet { Type = "Guinea pig" };
            var PetRabbit = new Pet { Type = "Rabbit" };
            var PetMs = new Pet { Type = "Mouse" };
            var PetBd = new Pet { Type = "Bird" };
            var PetFish = new Pet { Type = "Fish" };
            var PetFerret = new Pet { Type = "Ferret" };
            var PetIn = new Pet { Type = "Insects" };
            var PetCk = new Pet { Type = "Cockroaches" };
            var PetHd = new Pet { Type = "Hedhehog" };
            var PetCh = new Pet { Type = "Chicken" };
            var PetHo = new Pet { Type = "Horse" };
            var PetSn = new Pet { Type = "Snail" };
            var PetSna = new Pet { Type = "Snake" };
       
            context.Pets.AddOrUpdate(p => p.Type, PetCt, PetDg, PetHm,PetPig,PetRabbit,PetMs,PetBd,PetFish,PetFerret,PetIn,PetCk,PetHd,PetCh,PetHo,PetSn,PetSna);
            context.SaveChanges();
        }
    }
}
