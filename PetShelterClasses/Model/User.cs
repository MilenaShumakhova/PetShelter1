using PetShelterClasses.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
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
        public string Phone { get; set; }
        public List<UsersPets> MyPets { get; set; }
        public List<Pet> ExpectedPets { get; set; }
        public double PaymentGetter { get; set; }
        public DateTime? StartGetter { get; set; }
        public DateTime? EndGetter { get; set; }
        

        public string GetHash(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(
            password));
            return Convert.ToBase64String(hash);
        }


    }


}
