using PetShelterClasses.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses
{
   public class Context:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Pet> Pets { get; set; }
        
        public Context(): base("PetShelter")
        {

        }

    }
}
