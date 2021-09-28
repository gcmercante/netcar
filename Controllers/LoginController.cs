using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using net_car_ASPNETCORE.Models;

namespace net_car_ASPNETCORE.Controllers
{
    public class LoginController : Controller
    {
        private readonly net_car_ASPNETCOREContext _context;
        private string user { get; set; }
        private string senha { get; set; }

        public LoginController(net_car_ASPNETCOREContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logon()
        {
            var query = _context.Cliente.Select(c => new { c.user, c.senha }).ToList();
            this.user = Request.Query["user"];
            this.senha = Request.Query["senha"];
            foreach(var item in query)
            {
                if(item.user == this.user)
                {
                    if(Util.Compara(this.senha, item.senha))
                    {
                    }
                }
            }
            return View(nameof(Login));
            
        }
    }
}