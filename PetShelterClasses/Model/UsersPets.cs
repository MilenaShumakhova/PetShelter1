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
        public double Payment { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public User User { get; set; }
        public User Getter { get; set; }
    }
}
