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
    public class DocumentoVeiculosController : Controller
    {
        private readonly net_car_ASPNETCOREContext _context;

        public DocumentoVeiculosController(net_car_ASPNETCOREContext context)
        {
            _context = context;
        }

        private bool DocumentoVeiculoExists(string id)
        {
            return _context.DocumentoVeiculo.Any(e => e.documento_veiculo == id);
        }
    }
}
