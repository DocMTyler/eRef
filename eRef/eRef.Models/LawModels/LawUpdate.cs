using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRef.Models.LawModels
{
    public class LawUpdate
    {
        public int ID { get; set; }
        
        public string Name { get; set; }

        [Display(Name="Majority Description")]
        public string MajDescrip { get; set; }

        [Display(Name="Minority Description")]
        public string MinDescrip { get; set; }

        [Display(Name="Additional Description")]
        public string AddDescrip { get; set; }

        [Display(Name = "Author(Representative ID)")]
        public int Author { get; set; }

        [Display(Name="Date of Vote")]
        public DateTimeOffset VoteScheduled { get; set; }
        
        public int? VotesFor { get; set; }

        public int? VotesAgainst { get; set; }
    }
}
