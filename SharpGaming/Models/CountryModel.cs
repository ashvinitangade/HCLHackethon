using System.Collections.Generic;

namespace SharpGaming.Models
{   
    public class CountryModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string translation { get; set; }
    }

    public class RootCountry
    {
        public List<CountryModel> countries { get; set; }
    }
}
