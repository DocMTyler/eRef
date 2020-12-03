using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRef.Models.LawModels
{
    public class LawAuthor
    {
        public int ID { get; set; }
     
        public string Name { get; set; }
        
        [Display(Name="Majority Description")]
        public string MajDescrip { get; set; }
        
        [Display(Name="Minority Description")]
        public string MinDescrip { get; set; }
        
        [Display(Name="Additional Description")]
        public string AddDescrip { get; set; }
        
        public string Author { get; set; }
        
        [Display(Name="Date of Vote")]
        public DateTimeOffset VoteScheduled { get; set; }

        [Display(Name="Votes For")]
        public int? VotesFor { get; set; }

        [Display(Name="Votes Against")]
        public int? VotesAgainst { get; set; }
    }
}
