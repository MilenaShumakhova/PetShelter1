using PetShelterClasses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses
{
   public  class RepositoryDB
    {
        public List<User> Users{ get; set; }
        public List<Pet> Pets { get; set; }
        public List<UsersPets> UsersPets { get; set; }

        public RepositoryDB()
        {
            RestoreUsers();
        }

        Context context = new Context();

        public void RestoreUsers()
        {
            try
            {
                Users = (from us in context.Users
                         select us).ToList();
            }
            catch
            {
                Users = new List<User>();
            }

        }
        public void RestoPets()
        {
            try
            {
                Pets = (from p in context.Pets
                         select p).ToList();
            }
            catch
            {
                Pets = new List<Pet>();
            }

        }
        public void RestoUsersPets()
        {
            try
            {
                UsersPets = (from usp in context.UsersPets
                        select usp).ToList();
            }
            catch
            {
                UsersPets = new List<UsersPets>();
            }

        }


        public User ToCreateNewPerson(string name,string pass, string log,string city,string address)
        {
            User u = new User()
            {
                NameSurname = name,
                Password = pass,
                Email = log,
                City=city,
                Address=address,
               StartGiver= new DateTime (1970,01,01),
               EndGiver= new DateTime(1970, 01, 01),
               StartGetter= new DateTime(1970, 01, 01),
               EndGetter= new DateTime(1970, 01, 01),
            };
            return u;
        }

        public void ToRegistrate(User us)
        {
            context.Users.Add(us);
            context.SaveChanges();
        }

        public bool ToCompare(string email)
        {

            bool m = Users.All(us => us.Email!= email);
            return m;
        }


    }
}
