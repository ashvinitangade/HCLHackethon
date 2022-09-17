using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharpGaming.Models
{
    public class SportModel
    {
        [Key]
        public int id { get; set; }
       
        public string name { get; set; }
        public string translation { get; set; }
    }

    public class Root
    {
        public List<SportModel> sports { get; set; } 
    }
}
