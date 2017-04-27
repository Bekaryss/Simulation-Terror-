using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TerrorismStatistics.Models;

namespace TerrorismStatistics
{
    public class Parser
    {
        //first JSON
        public List<TerrorAttack> LoadFirst()
        {
            StreamReader r = new StreamReader("data/first.json");
            string json = r.ReadToEnd();
            List<TerrorAttack> items = JsonConvert.DeserializeObject<List<TerrorAttack>>(json);
            return items;
        }

        //second JSON
        public List<TerrorCountry> LoadSecond()
        {
            StreamReader r = new StreamReader("data/second.json");
            string json = r.ReadToEnd();
            List<TerrorCountry> items = JsonConvert.DeserializeObject<List<TerrorCountry>>(json);
            return items;
        }

        //Country XMl
        public List<CountryCity> LoadCountryByID(string s)
        {
            StreamReader r = new StreamReader("Data/" + s + ".json");
            string json = r.ReadToEnd();
            List<CountryCity> items = JsonConvert.DeserializeObject<List<CountryCity>>(json);
            return items;
        }
    }
}
