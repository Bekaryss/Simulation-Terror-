using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrorismStatistics.Models
{
    public class TerrorAttack
    {
        public string Date { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Weapon { get; set; }
        public string Perpretrator { get; set; }
        public string Fatalities { get; set; }
        public string Description { get; set; }
    }
}
