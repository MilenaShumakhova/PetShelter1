using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses.Model
{
    public class UsersPets
    {
        public int ID { get; set; }
        public  Pet Pet { get; set; }
        public string Description { get; set; }
        public Giver Giver { get; set; }
        public Getter Getter { get; set; }
    }
}
