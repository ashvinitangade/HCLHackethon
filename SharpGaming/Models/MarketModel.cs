using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharpGaming.Models
{

    public class Market
    {
        [Key]
        [Required(ErrorMessage = "Required")]
        public int eventId { get; set; }
       
        public string marketId { get; set; }
        public string marketName { get; set; }
        public string marketTranslation { get; set; }
        public EachWay eachWay { get; set; }
        public List<Selection> selections { get; set; }
    }

    public class EachWay
    {
        public int id { get; set; }
        public int numerator { get; set; }
        public int denominator { get; set; }
        public int places { get; set; }
        public bool enabled { get; set; }
    }

    public class MarketModel
    {
        public List<Market> Markets { get; set; }
    }

    public class RacingInfo
    {
        public int id { get; set; }
        public bool allowBog { get; set; }
        public bool allowSP { get; set; }
        public bool onlySP { get; set; }
        public int priceType { get; set; }
    }

    public class MarketModelRoot
    {
        public MarketModel markets { get; set; }
    }

    public class Selection
    {
        public int id { get; set; }
        public string @decimal { get; set; }
        public string fraction { get; set; }
        public string american { get; set; }
        public bool frozen { get; set; }
        public string selectionName { get; set; }
        public string selectionName2 { get; set; }
        public string selectionNameTranslation { get; set; }
        public string selectionNameTranslation2 { get; set; }
        public int numerator { get; set; }
        public int denominator { get; set; }
       // public object additionalValue { get; set; }
        public EachWay eachWay { get; set; }
        public RacingInfo racingInfo { get; set; }
        public int participantId { get; set; }
    }
}
