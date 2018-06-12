using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses.Model
{
    public class GetterRequests
    {
        public int ID { get; set; }
        public UsersPets Request { get; set; }
        public User User { get; set; }

    }
}
