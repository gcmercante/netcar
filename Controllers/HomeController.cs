using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_car_ASPNETCORE.Models;

namespace net_car_ASPNETCORE.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly net_car_ASPNETCOREContext _context;
        private string user { get; set; }
        private string senha { get; set; }

        public HomeController(net_car_ASPNETCOREContext context)
        {
            _context = context;
        }

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logon()
        {
            var query = _context.Cliente.Select(c => new { c.user, c.senha }).ToList();
            this.user = Request.Query["user"];
            this.senha = Request.Query["senha"];
            foreach (var item in query)
            {
                if (item.user == this.user)
                {
                    if (Util.Compara(this.senha, item.senha))
                    {
                        var count = _context.Viagem.Select(v => new { v.numero_chamado, v.status }).Where(v => v.status == "Ativo").Count();
                        var countFinish = _context.Viagem.Select(v => new { v.numero_chamado, v.status }).Where(v => v.status == "Finalizado").Count();

                        ViewBag.count = count;
                        ViewBag.countFinish = countFinish;
                        return View(nameof(Index));
                    }
                }
            }
            return View(nameof(Login));
        }
        public IActionResult Index()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
