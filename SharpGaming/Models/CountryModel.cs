using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharpGaming.Models
{   
    public class CountryModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="Name is required")]
        public string name { get; set; }
        public string translation { get; set; }
    }

    public class RootCountry
    {
        public List<CountryModel> countries { get; set; }
    }
}
