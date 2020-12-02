using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRef.Models.VoterModels
{
    public class VoterListItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int VoterID { get; set; }
        public string PartyAff { get; set; }
        public int District { get; set; }
    }
}
