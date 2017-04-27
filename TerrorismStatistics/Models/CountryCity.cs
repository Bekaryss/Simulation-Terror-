using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrorismStatistics.Models
{
    public class CountryCity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double A { get; set; }
        public double B1 { get; set; }
        public double B2 { get; set; }
        public double X1 { get; set; }
        public double X2 { get; set; }
    }
}
