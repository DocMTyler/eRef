using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eRef.Data.Legislator;

namespace eRef.Models.LegislatorModels
{
    public class LegislatorUpdate
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Position JobRole { get; set; }

        public int District { get; set; }
    }
}
