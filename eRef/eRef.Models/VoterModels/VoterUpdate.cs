using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRef.Models.VoterModels
{
    public class VoterUpdate
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name="Voter ID")]
        public int VoterID { get; set; }
        [Display(Name="Party Affiliation(if any)")]
        public string PartyAff { get; set; }
        public int District { get; set; }
    }
}
