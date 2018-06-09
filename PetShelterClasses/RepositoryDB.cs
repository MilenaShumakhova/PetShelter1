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
        Context context = new Context();
        public List<User> Users{ get; set; }

        public User ToCreateNewPerson(string name,string pass, string log,string city,string address)
        {
            User u = new User()
            {
                NameSurname = name,
                Password = pass,
                Email = log,
                City=city,
                Address=address
                
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
        public string GetHash(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(
            password));
            return Convert.ToBase64String(hash);
        }

    }
}
