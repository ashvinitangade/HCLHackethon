using System.ComponentModel.DataAnnotations;

namespace SharpGamingAPI.Models
{
    public class AddSportsModel
    {
        [Required(ErrorMessage = "Name is required!")]
        [RegularExpression("^[a-zA-Z ]$", ErrorMessage = "Name must contains only (a-zA-Z)")]
        public string Name { get; set; }
        public int UserGroupId { get; set; }
    }
}
