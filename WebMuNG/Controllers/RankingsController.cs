using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebMuNG.Data;
using WebMuNG.Models;

namespace WebMuNG.Controllers
{
    public class RankingsController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly MuOnlineContext _db;

        public RankingsController(IConfiguration config, MuOnlineContext db)
        {
            configuration = config;
            _db = db;
        }

        // GET: Rankings
        public IActionResult Index()
        {
            var x = _db.Database.CanConnect();
            string path = Directory.GetCurrentDirectory();
            string jpath = path + "/CharacterMapping.json";
            string jpathm = path + "/MapMapping.json";
            StreamReader r = new StreamReader(jpath);
            string json = r.ReadToEnd();
            IList<MyAccount.CharacterMapping> CharMapp = JsonConvert.DeserializeObject<IList<MyAccount.CharacterMapping>>(json);
            ViewBag.CharMapp = CharMapp;
            StreamReader sr = new StreamReader(jpathm);
            json = sr.ReadToEnd();
            IList<MyAccount.MapMapping> MapMapp = JsonConvert.DeserializeObject<IList<MyAccount.MapMapping>>(json);
            ViewBag.MapMapp = MapMapp;


            var characterList = new Character();
            var characters = _db.Characters.OrderByDescending(m => ((m.Resets * 400) + m.CLevel)).Take(50);

            return View(characters);
        }




    }
}