using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRef.Models
{
    public class VoterRegister
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int VoterID { get; set; }
        public string PartyAff { get; set; }
        public string Location { get; set; }
    }
}
