using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrorismStatistics.Models;

namespace TerrorismStatistics
{
    public class ProbabilityCalculator
    {
        public double Probability(double a, double b1, double b2, double x1, double x2)
        {
            double res = Math.Abs((a + b1 * x1 + b2 * x2) * a - b1 * a - b2 * a);
            return res;
        }
        public List<Country> GetAllCountry()
        {
            Parser pars = new Parser();
            
            List<Country> Countries = new List<Country>();
            List<TerrorCountry> terCountries = pars.LoadSecond();
            foreach (var cur in terCountries)
            {
                Country coun = new Country();
                if (cur.Id != null)
                {
                    coun.Id = cur.Id;
                    coun.CountryName = cur.Country;
                    coun.Count = cur.Count;
                    coun.Probability = Probability(cur.A, cur.B1, cur.B2, cur.X1, cur.X2);
                    Countries.Add(coun);
                }                                                                          
            }
            
            return Countries;
        }

        public List<City> GetAllCities(string s)
        {
            Parser pars = new Parser();

            List<City> Countries = new List<City>();
            List<CountryCity> terCountries = pars.LoadCountryByID(s);
            foreach (var cur in terCountries)
            {
                City coun = new City();
                if (cur.Id != null)
                {
                    coun.Id = cur.Id;
                    coun.Name = cur.Name;
                    coun.Count = cur.Count;
                    coun.Probability = Probability(cur.A, cur.B1, cur.B2, cur.X1, cur.X2);
                    Countries.Add(coun);
                }
            }

            return Countries;
        }
    }
   
}
