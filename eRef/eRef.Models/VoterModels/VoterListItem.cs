using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRef.Models.VoterModels
{
    public class VoterListItem
    {
        public int ID { get; set; }
        [Display(Name="Full Name")]
        public string Name { get; set; }
        [Display(Name="Voter ID")]
        public int VoterID { get; set; }
        [Display(Name="Party Affiliation(If any)")]
        public string PartyAff { get; set; }
        [Display(Name="District")]
        public int District { get; set; }
    }
}
