using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebMuNG.Models;

namespace WebMuNG.Controllers
{
    public class MyAccountController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly MuOnlineContext _db;

        public MyAccountController(IConfiguration config, MuOnlineContext db)
        {
            configuration = config;
            _db = db;
        }
        [Authorize]
        public IActionResult AddStats()
        {
            string username = User.Identity.Name;
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
            var characters = _db.Characters.Where(m => m.AccountId == username);

            return PartialView("_AddStats", characters);
        }
        [HttpPost]
        public ActionResult AddStatsTo(string Name,int Strength,int Dexterity, int Vitality, int Energy, int Command)
        {
            var totalpoints = Strength + Dexterity + Vitality + Energy;
            var q = _db.Characters.Where(m=> m.Name == Name && m.LevelUpPoint >= totalpoints).FirstOrDefault();
            if (q != null)
            {
                q.Strength = q.Strength + Strength;
                q.Dexterity = q.Dexterity + Dexterity;
                q.Vitality = q.Vitality + Vitality;
                q.Energy = q.Energy + Energy;
                q.LevelUpPoint = q.LevelUpPoint - totalpoints;
                _db.SaveChanges();
            }

            return View("Index");
        }

        [Authorize]
        public IActionResult MyAccount()
        {
            string username = User.Identity.Name;
            string MuDBConnString = configuration.GetConnectionString("MuDB");
            string query = "SELECT ms.memb___id, ms.ConnectStat, mi.mail_addr, isnull(c.Name, 'N/A') as Name,isnull(c.cLevel, 0) as cLevel,isnull(c.ResetCount, 0) as ResetCount, " +
                            "isnull(c.Class, 255) as Class,isnull(c.Strength, 0) as Strength,isnull(c.Dexterity, 0) as Dexterity,isnull(c.Vitality, 0) as Vitality, " +
                            "isnull(c.Energy, 0) as Energy,isnull(c.Leadership, 0) as Leadership,isnull(c.MapNumber, 0) as MapNumber,isnull(c.MapPosX, 0) as MapPosX, " +
                            "isnull(c.MapPosY, 0) as MapPosY,isnull(gm.G_Name, 'N/A') as G_Name,isnull(c.Inventory, 0) as Inventory FROM MEMB_STAT ms JOIN MEMB_INFO mi on mi.memb___id = ms.memb___id " +
                            "LEFT JOIN Character c on c.AccountID = mi.memb___id LEFT JOIN GuildMember gm on gm.Name = c.Name WHERE ms.memb___id = '" + username + "';";
            List<MyAccount> CharsInfo = new List<MyAccount>();
            string path = Directory.GetCurrentDirectory();
            string jpath = path + "/CharacterMapping.json";
            string jpathm = path + "/MapMapping.json";
            StreamReader r = new StreamReader(jpath);
            string json = r.ReadToEnd();
            IList <MyAccount.CharacterMapping> CharMapp = JsonConvert.DeserializeObject<IList<MyAccount.CharacterMapping>>(json);
            ViewBag.CharMapp = CharMapp;
            StreamReader sr = new StreamReader(jpathm);
            json = sr.ReadToEnd();
            IList<MyAccount.MapMapping> MapMapp = JsonConvert.DeserializeObject<IList<MyAccount.MapMapping>>(json);
            ViewBag.MapMapp = MapMapp;


            using (SqlConnection conn = new SqlConnection(MuDBConnString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MyAccount UserInfo = new MyAccount();
                        UserInfo.username       = (string)reader[0];
                        UserInfo.connected      = (byte)reader[1];
                        UserInfo.UserMail       = (string)reader[2];
                        UserInfo.CharName       = (string)reader[3];
                        UserInfo.CharLevel      = (int)reader[4];
                        UserInfo.CharResests    = (int)reader[5];
                        UserInfo.CharClass      = (byte)reader[6];
                        UserInfo.CharSTR        = (int)reader[7];
                        UserInfo.CharAGI        = (int)reader[8];
                        UserInfo.CharVIT        = (int)reader[9];
                        UserInfo.CharENE        = (int)reader[10];
                        UserInfo.CharCMD        = (int)reader[11];
                        UserInfo.CharMap        = (Int16)reader[12];
                        UserInfo.CharMapPosX    = (Int16)reader[13];
                        UserInfo.CharMapPosY    = (Int16)reader[14];
                        UserInfo.CharGuildName  = (string)reader[15];
                        UserInfo.CharInventory = (byte[])reader[16];

                        CharsInfo.Add(UserInfo);
                    }
                }
                conn.Close();
                conn.Dispose();
            } 


                return PartialView("_MyAccount", CharsInfo);
        }
        [HttpPost]
        public ActionResult ChangePassword(string NewPassword)
        {
            string username = User.Identity.Name;
            string MuDBConnString = configuration.GetConnectionString("MuDB");
            var vdPass = new Regex(@"([a-zA-Z0-9]{4,32})$", RegexOptions.Compiled);
            string query = "UPDATE MEMB_INFO SET memb__pwd = '" + NewPassword + "' where memb___id = '" + username + "';";

            if (vdPass.IsMatch(NewPassword))
            {
                using (SqlConnection conn = new SqlConnection(MuDBConnString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
            
            return RedirectToAction("MyAccount");
        }
    }
}
