using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharpGaming.Data;
using SharpGaming.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace SharpGaming.Controllers
{
    public class SportController : Controller
    {
        private readonly AppDbContext _context;
        public SportController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var apiSportData = new Root();
            string apiUrl = "https://affiliate-feed.petfre.sgp.bet/1/sports?languageCode=en";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                apiSportData = JsonConvert.DeserializeObject<Root>(response.Content.ReadAsStringAsync().Result);
            }

            foreach (var item in apiSportData.sports)
            {
                if (!_context.Sports.Any(o => o.id == item.id && o.name.Equals(item.name)))
                {
                    var data = new SportModel
                    {
                        name = item.name,
                        translation = item.translation
                    };
                    _context.Sports.Add(data);
                }
            }
            _context.SaveChanges();

            return View(apiSportData);
        }

        public IActionResult Countries()
        {
            var apiSportData = new RootCountry();
            string apiUrl = "https://affiliate-feed.petfre.sgp.bet/1/countries?languageCode=en";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                apiSportData = JsonConvert.DeserializeObject<RootCountry>(response.Content.ReadAsStringAsync().Result);
            }

            foreach (var item in apiSportData.countries)
            {
                if (!_context.Countries.Any(o => o.id != item.id && o.name.Equals(item.name)))
                {
                    var data = new CountryModel
                    {
                        name = item.name,
                        translation = item.translation
                    };
                    _context.Countries.Add(data);
                }
            }
            _context.SaveChanges();

            return View(apiSportData);
        }

        public IActionResult Tournament()
        {
            ViewBag.Sports = _context.Sports.ToList();
            ViewBag.Country = _context.Countries.ToList();
           
            return View(new TournamentModel());
        }
        [HttpPost]
        public IActionResult Tournament(int sports, int country,string lang)
        {
            var apiSportData = new TournamentModel();
            string apiUrl = $"https://affiliate-feed.petfre.sgp.bet/1/sports/"+sports+"/tournaments?countryIds="+country+"&languageCode="+lang+"";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                apiSportData = JsonConvert.DeserializeObject<TournamentModel>(response.Content.ReadAsStringAsync().Result);
            }

            foreach (var item in apiSportData.tournaments)
            {
                if (!_context.Tournaments.Any(o => o.id != item.id && o.name.Equals(item.name)))
                {
                    var data = new Tournament
                    {
                        name = item.name,
                        translation = item.translation,
                        countryId=item.countryId,
                        live=item.live,
                        meetingDate=item.meetingDate,
                        preMatch=item.preMatch,
                        sportId=item.sportId
                    };
                    _context.Tournaments.Add(data);
                }
            }
            _context.SaveChanges();

            return View(apiSportData);
        }
        public IActionResult Events()
        {

            return View();
        }
        public IActionResult Markets()
        {
            return View();
        }
    }
}
