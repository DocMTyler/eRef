﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRef.Data
{
    public class Voter
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Required]
        public int VoterID { get; set; }
        public string PartyAff { get; set; }
        public string Location { get; set; }

    }
}
