﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eRef.Data.Legislator;

namespace eRef.Models.LegislatorModels
{
    public class NewLegislatorCreate
    {
        [Display(Name = "Representative ID")]
        public int ID { get; set; }

        public string Name { get; set; }

        [Display(Name="Job Role")]
        public Position JobRole { get; set; }

        public int District { get; set; }
    }
}
