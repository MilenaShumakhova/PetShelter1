using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses.Model
{
    public class Mark
    {
        public int ID { get; set; }
        public double Grade { get; set; }
        public User RatedUser { get; set; }
        public GetterRequests IRequest { get; set; }
       
    }
}
