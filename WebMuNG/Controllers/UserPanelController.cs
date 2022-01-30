using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebMuNG.Models;

namespace WebMuNG.Controllers
{
    public class UserPanelController : Controller
    {
        private readonly IConfiguration configuration;

        public UserPanelController(IConfiguration config)
        {
            configuration = config;
        }

        [Authorize]
        public IActionResult UserPanel()
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(string username, string password, string returnUrl)
        {
            string MuDBConnString = configuration.GetConnectionString("MuDB");
            string query = "SELECT memb___id,memb__pwd FROM MEMB_INFO where memb___id = '" + username + "' and memb__pwd = '" + password + "';";
            var vdUser = new Regex(@"([a-zA-Z0-9]{4,32})$", RegexOptions.Compiled);
            var vdPass = new Regex(@"([a-zA-Z0-9]{4,32})$", RegexOptions.Compiled);
            Users getUser = new Users();

            returnUrl= "/UserPanel/UserPanel";

            if (vdUser.IsMatch(username) && vdPass.IsMatch(password))
            {
                using (SqlConnection conn = new SqlConnection(MuDBConnString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            getUser.username = (string)reader[0];
                            getUser.password = (string)reader[1];
                        }
                    }
                    conn.Close();
                    conn.Dispose();
                    if (getUser.username == username && getUser.password == password)
                    {
                        var claims = new List<Claim>();
                        claims.Add(new Claim("username", username));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                        claims.Add(new Claim(ClaimTypes.Name, username));
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        TempData["Error"] = "Warining. The user name or password is incorrect";
                        return View("login");
                    }
                }
            }
            TempData["Error"] = "Error. The user name or password is invalid";
            return View("login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
