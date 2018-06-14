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
            Pet PetCt = new Pet { Type = "Cat" };
            Pet PetCh = new Pet { Type = "Chiken" };
            Pet PetDg = new Pet { Type = "Dog" };
            Pet PetHm = new Pet { Type = "Hamster" };
            Pet PetFr = new Pet { Type = "Frog" };
            Pet PetT = new Pet { Type = "Turtle" };
            Pet PetF = new Pet { Type = "Ferret" };
            Pet PetFi = new Pet { Type = "Fish" };
            Pet PetChi = new Pet { Type = "Chinchilla" };
            Pet PetIns = new Pet { Type = "Insects" };
            Pet PetErm= new Pet { Type = "Ermine" };
            Pet PetRab = new Pet { Type = "Rabbit" };
            Pet PetSn = new Pet { Type = "Snake" };
            Pet PetBird = new Pet { Type = "Bird" };
            Pet PetHor = new Pet { Type = "Horse" };
            Pet PetGoat = new Pet { Type = "Goat" };
            Pet PetDuck = new Pet { Type = "Duck" };
            Pet PetHedg = new Pet { Type = "Hedgehog" };

            context.Pets.AddOrUpdate(p => p.Type, PetCt, PetDg,PetHm,PetT,PetF,PetChi,PetIns,PetErm,PetRab,PetSn,PetBird,PetHor,PetGoat,PetDuck,PetHedg);
        }
    }
}
