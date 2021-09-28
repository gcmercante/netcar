using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using net_car_ASPNETCORE.Models;

namespace net_car_ASPNETCORE.Controllers
{
    public class SegurosController : Controller
    {
        private readonly net_car_ASPNETCOREContext _context;

        public SegurosController(net_car_ASPNETCOREContext context)
        {
            _context = context;
        }

        private bool SeguroExists(string id)
        {
            return _context.Seguro.Any(e => e.contrato_seguro == id);
        }
    }
}
