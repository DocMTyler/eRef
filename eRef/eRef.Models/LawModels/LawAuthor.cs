using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRef.Models.LawModels
{
    public class LawAuthor
    {
        public int ID { get; set; }
     
        public string Name { get; set; }
       
        public string MajDescrip { get; set; }
        
        public string MinDescrip { get; set; }
       
        public string AddDescrip { get; set; }
        
        public string Author { get; set; }
        
        public DateTimeOffset VoteScheduled { get; set; }

        public int? VotesFor { get; set; }

        public int? VotesAgainst { get; set; }
    }
}
