using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses.Model
{
    public class Pet
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public List<User> Users { get; set; }

    }
}
