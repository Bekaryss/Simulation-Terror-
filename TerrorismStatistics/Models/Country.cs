using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrorismStatistics.Models
{
    public class Country
    {
        public string Id { get; set; }
        public string CountryName { get; set; }
        public int Count { get; set; }
        public double Probability { get; set; }
    }
}
