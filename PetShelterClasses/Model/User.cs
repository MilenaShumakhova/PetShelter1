using PetShelterClasses.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses
{
    public class User
    {
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<UsersPets> MyPets { get; set; }
        public List<Pet> ExpectedPets { get; set; }
        public decimal PaymentGiver { get; set; }
        public DateTime StartGiver { get; set; }
        public DateTime EndGiver { get; set; }
        public decimal PaymentGetter { get; set; }
        public DateTime StartGetter { get; set; }
        public DateTime EndGetter { get; set; }


    }
    

}
