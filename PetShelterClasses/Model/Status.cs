using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses.Model
{
   public class Status
    {
        public int ID { get; set; }
        public string UserStatus { get; set; }
        public List<User> Users { get; set; }

    }
}
