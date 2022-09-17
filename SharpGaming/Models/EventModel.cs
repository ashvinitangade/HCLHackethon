using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharpGaming.Models
{
    public class Event
    {
        public int id { get; set; }

        public string name { get; set; }

        public int sportId { get; set; }
        public int countryId { get; set; }
        [Required(ErrorMessage ="Required")]
        public int tournamentId { get; set; }
        public string dateStart { get; set; }
        public bool isLive { get; set; }
        public bool isRacingEvent { get; set; }
        public Teams teams { get; set; }
        //public object raceInfo { get; set; }
        public bool outright { get; set; }
        //public List<object> participantInfo { get; set; }
    }

    public class Teams
    {
        public int id { get; set; }
        public string home { get; set; }
        public string homeTranslation { get; set; }
        public string away { get; set; }
        public string awayTranslation { get; set; }
    }

    public class EventModel
    {
        public List<Event> events { get; set; }
    }
}
