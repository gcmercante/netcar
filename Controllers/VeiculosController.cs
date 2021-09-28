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
    public class VeiculosController : Controller
    {
        /*
         * STATUS
         * 
         * Em viagem
         * Ativo
         * Em manutenção
         * Inativo
        */
        private readonly net_car_ASPNETCOREContext _context;

        public VeiculosController(net_car_ASPNETCOREContext context)
        {
            _context = context;
        }

        // GET: Veiculos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Veiculo.ToListAsync());
        }

        // GET: Veiculos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo
                .FirstOrDefaultAsync(m => m.documento_veiculo == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // GET: Veiculos/Create
        public IActionResult Create()
        {
            var clienteQuery = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome });
            var clienteCount = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome }).Count();

            var query = _context.Seguro.Select(seguro => new { seguro.contrato_seguro, seguro.tipo_seguro });
            var count = _context.Seguro.Select(seguro => seguro.contrato_seguro).Count();

            List<string> cnpj = new List<string>();
            List<string> valueCnpj = new List<string>();

            List<string> seguro = new List<string>();
            List<string> contrato_seguro = new List<string>();

            foreach (var item in clienteQuery)
            {
                cnpj.Add(item.nome + " - " + Util.formatCnpj(item.cnpj));
                valueCnpj.Add(item.cnpj);
            }

            foreach (var item in query)
            {
                seguro.Add(item.tipo_seguro);
                contrato_seguro.Add(item.contrato_seguro);
            }

            ViewBag.cnpj = cnpj.ToArray();
            ViewBag.valueCnpj = valueCnpj.ToArray();
            ViewBag.clienteCount = clienteCount;

            ViewBag.seguro = seguro.ToArray();
            ViewBag.contrato_seguro = contrato_seguro.ToArray();

            ViewBag.count = count;
            return View();
        }

        // POST: Veiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("documento_veiculo,marca,cor,modelo,placa,quilometragem,seguro,ipva,status,cliente")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                veiculo.status = "Ativo";
                veiculo.placa = Util.formatPlaca(veiculo.placa);
                _context.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veiculo);
        }

        // GET: Veiculos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var veiculo = await _context.Veiculo.FindAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            var clienteQuery = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome });
            var clienteCount = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome }).Count();

            List<string> cnpj = new List<string>();
            List<string> valueCnpj = new List<string>();

            foreach (var item in clienteQuery)
            {
                cnpj.Add(item.nome + " - " + Util.formatCnpj(item.cnpj));
                valueCnpj.Add(item.cnpj);
            }

            ViewBag.cnpj = cnpj.ToArray();
            ViewBag.valueCnpj = valueCnpj.ToArray();
            ViewBag.clienteCount = clienteCount;
            
            return View(veiculo);
        }

        // POST: Veiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("documento_veiculo,marca,cor,modelo,placa,quilometragem,seguro,ipva,status,cliente")] Veiculo veiculo)
        {
            if (id != veiculo.documento_veiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculoExists(veiculo.documento_veiculo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(veiculo);
        }

        // GET: Veiculos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo
                .FirstOrDefaultAsync(m => m.documento_veiculo == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var veiculo = await _context.Veiculo.FirstOrDefaultAsync(v => v.documento_veiculo == id);
            veiculo.status = "Inativo";
            if(await TryUpdateModelAsync<Veiculo>(
                veiculo,
                "",
                v => v.status
                ))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch(DbUpdateException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculoExists(string id)
        {
            return _context.Veiculo.Any(e => e.documento_veiculo == id);
        }
    }
}
