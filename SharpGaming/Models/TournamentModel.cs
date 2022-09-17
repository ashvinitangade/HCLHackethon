using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace SharpGaming.Models
{
    public class TournamentModel
    {
        public List<Tournament> tournaments { get; set; }
    }

    public class Tournament
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string translation { get; set; }
        [Required(ErrorMessage = "Required")]
        public int sportId { get; set; }
        public int countryId { get; set; }
        public int live { get; set; }
        public int preMatch { get; set; }
        public DateTime? meetingDate { get; set; }
    }
}
