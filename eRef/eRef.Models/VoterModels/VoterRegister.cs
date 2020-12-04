using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRef.Models
{
    public class VoterRegister
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name="Voter Identification Number")]
        public int VoterID { get; set; }
        [Display(Name="Party Affiliation(If any)")]
        public string PartyAff { get; set; }
        [Display(Name = "Representative ID (Legislator must FIRST be registered!)")]
        public int LegislatorID { get; set; }
    }
}
