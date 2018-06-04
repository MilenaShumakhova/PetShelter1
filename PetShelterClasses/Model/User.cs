using PetShelterClasses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Status StatusID { get; set; }
        public string City { get; set; }
        //public List<UserPets> Pets { get; set; }
        public List<Pet> Pet { get; set; }
        public decimal Payment { get; set; }




    }
}
