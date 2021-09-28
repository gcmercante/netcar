using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using net_car_ASPNETCORE.Models;

namespace net_car_ASPNETCORE.Controllers
{
    public class AlugueisController : Controller
    {
        private readonly net_car_ASPNETCOREContext _context;

        public AlugueisController(net_car_ASPNETCOREContext context)
        {
            _context = context;
        }

        // GET: Alugueis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aluguel.ToListAsync());
        }

        // GET: Alugueis/Create
        public IActionResult Create()
        {
            var clienteQuery = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome });
            var clienteCount = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome }).Count();

            var veiculoQuery = _context.Veiculo.Select(veiculo => new { veiculo.documento_veiculo, veiculo.modelo, veiculo.placa, veiculo.cliente }).Where(veiculo => veiculo.cliente == "12345678974567");
            var veiculoCount = _context.Veiculo.Select(veiculo => new { veiculo.documento_veiculo, veiculo.modelo, veiculo.cliente }).Where(veiculo => veiculo.cliente == "12345678974567").Count();

            List<string> cnpj = new List<string>();
            List<string> valueCnpj = new List<string>();

            List<string> documento = new List<string>();
            List<string> valueDocumento = new List<string>();

            foreach (var item in clienteQuery)
            {
                cnpj.Add(item.nome + " - " + Util.formatCnpj(item.cnpj));
                valueCnpj.Add(item.cnpj);
            }

            foreach (var item in veiculoQuery)
            {
                documento.Add(item.modelo + " - " + Util.formatPlaca(item.placa));
                valueDocumento.Add(item.documento_veiculo);
            }

            ViewBag.cnpj = cnpj.ToArray();
            ViewBag.valueCnpj = valueCnpj.ToArray();
            ViewBag.clienteCount = clienteCount;

            ViewBag.documento = documento.ToArray();
            ViewBag.valueDocumento = valueDocumento.ToArray();
            ViewBag.veiculoCount = veiculoCount;

            return View();
        }

        // POST: Alugueis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,veiculo,cliente,valor_aluguel,data_aluguel,duracao,status")] Aluguel aluguel)
        {
            DateTime date = DateTime.Today;
            CultureInfo culture = new CultureInfo("pt-BR");
            if (ModelState.IsValid)
            {
                aluguel.data_aluguel = date.ToString("dd/MM/yyyy", culture);
                aluguel.status = "Ativo";
                _context.Add(aluguel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluguel);
        }

        // GET: Alugueis/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var aluguel = await _context.Aluguel.FindAsync(id);
            if (aluguel == null)
            {
                return NotFound();
            }
            var clienteQuery = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome });
            var clienteCount = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome }).Count();

            var veiculoQuery = _context.Veiculo.Select(veiculo => new { veiculo.documento_veiculo, veiculo.modelo, veiculo.placa });
            var veiculoCount = _context.Veiculo.Select(veiculo => new { veiculo.documento_veiculo, veiculo.modelo }).Count();

            List<string> cnpj = new List<string>();
            List<string> valueCnpj = new List<string>();

            List<string> documento = new List<string>();
            List<string> valueDocumento = new List<string>();

            foreach (var item in clienteQuery)
            {
                cnpj.Add(item.nome + " - " + Util.formatCnpj(item.cnpj));
                valueCnpj.Add(item.cnpj);
            }

            foreach (var item in veiculoQuery)
            {
                documento.Add(item.modelo + " - " + Util.formatPlaca(item.placa));
                valueDocumento.Add(item.documento_veiculo);
            }

            ViewBag.cnpj = cnpj.ToArray();
            ViewBag.valueCnpj = valueCnpj.ToArray();
            ViewBag.clienteCount = clienteCount;

            ViewBag.documento = documento.ToArray();
            ViewBag.valueDocumento = valueDocumento.ToArray();
            ViewBag.veiculoCount = veiculoCount;

            return View(aluguel);
        }

        // POST: Alugueis/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,veiculo,cliente,valor_aluguel,data_aluguel,data_devolucao,duracao,status")] Aluguel aluguel)
        {
            DateTime date = DateTime.Today;
            CultureInfo culture = new CultureInfo("pt-BR");
            if (id != aluguel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    aluguel.data_aluguel = date.ToString("dd/MM/yyyy", culture); ;
                    aluguel.data_devolucao = date.ToString("dd/MM/yyyy", culture);
                    _context.Update(aluguel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AluguelExists(aluguel.id))
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
            return View(aluguel);
        }

        // GET: Alugueis/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var aluguel = await _context.Aluguel
                .FirstOrDefaultAsync(m => m.id == id);
            if (aluguel == null)
            {
                return NotFound();
            }

            return View(aluguel);
        }

        // POST: Alugueis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluguel = await _context.Aluguel.FirstOrDefaultAsync( a => a.id == id);
            aluguel.status = "Cancelado";
            if(await TryUpdateModelAsync<Aluguel>(
                aluguel,
                "",
                a => a.status
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

        private bool AluguelExists(int id)
        {
            return _context.Aluguel.Any(e => e.id == id);
        }
    }
}
