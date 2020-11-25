using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRef.Data
{
    public class Legislator
    {
        public enum Position
        {
            Legislator,
            Staffer
        }
        
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name="First and Last Name")]
        public string Name { get; set; }
        public Position JobRole { get; set; }
        public string PartyAffiliation { get; set; }
        [Required]
        public int District { get; set; }
    }
}
