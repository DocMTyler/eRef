using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRef.Data
{
    public class Law
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name="Legislation Title")]
        public string Name { get; set; }
        [Display(Name ="Description from the Majority party")]
        public string MajDescrip { get; set; }
        [Display(Name = "Description from the Minority party")]
        public string MinDescrip { get; set; }
        [Display(Name = "Additional Descriptions relevant to the legislation")]
        public string AddDescrip { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name = "Date and Time of Vote")]
        public DateTimeOffset VoteScheduled { get; set; }
        [Display(Name = "Votes For")]
        public int VotesFor { get; set; }
        [Display(Name = "Votes Against")]
        public int VotesAgainst { get; set; }
    }
}
