using PetShelterClasses.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<UsersPets> UsersPets { get; set; }

        public Context() : base("PetShelterFirst")
        {

        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<User>()
        //                .HasRequired(s => s.Giver)
        //                .WithRequiredPrincipal(ad => ad.User);
        //    modelBuilder.Entity<User>()
        //        .HasRequired(s => s.Getter)
        //        .WithRequiredPrincipal(ad => ad.User);
        //}


    }
}
