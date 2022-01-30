using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebMuNG.Data;
using WebMuNG.Models;

namespace WebMuNG.Controllers
{
    public class RankingsController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly MuOnline _db;

        public RankingsController(IConfiguration config, MuOnline db)
        {
            configuration = config;
            _db = db;
        }

        // GET: Rankings
        public async Task<IActionResult> Index()
        {
            var characterList = new Character();
            var characters = _db.Characters.OrderByDescending(m => (m.resets * 400) + m.cLevel).Take(50);


            return View(characters);
        }




    }
}