using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses.Model
{
   public class Getter
    {
        
        public int ID { get; set; }
        public User User { get; set; }
        public decimal Payment { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<UsersPets> Pets { get; set; }
        public List<Giver> Givers { get; set; }
    }
}
