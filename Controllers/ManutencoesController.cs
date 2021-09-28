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
    /*
     * STATUS:
     * Em manutenção
     * Finalizado
     */
    public class ManutencoesController : Controller
    {
        private readonly net_car_ASPNETCOREContext _context;

        public ManutencoesController(net_car_ASPNETCOREContext context)
        {
            _context = context;
        }

        // GET: Manutencoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Manutencao.ToListAsync());
        }

        // GET: Manutencoes/Create
        public IActionResult Create()
        {
            var veiculoQuery = _context.Veiculo.Select(veiculo => new { veiculo.documento_veiculo, veiculo.modelo, veiculo.placa });
            var veiculoCount = _context.Veiculo.Select(veiculo => new { veiculo.documento_veiculo, veiculo.modelo }).Count();

            List<string> documento = new List<string>();
            List<string> valueDocumento = new List<string>();

            foreach (var item in veiculoQuery)
            {
                documento.Add(item.modelo + " - " + Util.formatPlaca(item.placa));
                valueDocumento.Add(item.documento_veiculo);
            }

            ViewBag.documento = documento.ToArray();
            ViewBag.valueDocumento = valueDocumento.ToArray();
            ViewBag.veiculoCount = veiculoCount;

            return View();
        }

        // POST: Manutencoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ordem_servico,veiculo,tipo_manutencao,custo_manutencao,status,data_manutencao")] Manutencao manutencao)
        {
            DateTime date = DateTime.Today;
            CultureInfo culture = new CultureInfo("pt-BR");
            if (ModelState.IsValid)
            {
                manutencao.data_manutencao = date.ToString("dd/MM/yyyy", culture);
                manutencao.status = "Em manutenção";
                _context.Add(manutencao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manutencao);
        }

        // GET: Manutencoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manutencao = await _context.Manutencao.FindAsync(id);
            if (manutencao == null)
            {
                return NotFound();
            }

            var veiculoQuery = _context.Veiculo.Select(veiculo => new { veiculo.documento_veiculo, veiculo.modelo, veiculo.placa });
            var veiculoCount = _context.Veiculo.Select(veiculo => new { veiculo.documento_veiculo, veiculo.modelo }).Count();

            List<string> documento = new List<string>();
            List<string> valueDocumento = new List<string>();

            foreach (var item in veiculoQuery)
            {
                documento.Add(item.modelo + " - " + Util.formatPlaca(item.placa));
                valueDocumento.Add(item.documento_veiculo);
            }

            ViewBag.documento = documento.ToArray();
            ViewBag.valueDocumento = valueDocumento.ToArray();
            ViewBag.veiculoCount = veiculoCount;

            return View(manutencao);
        }

        // POST: Manutencoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ordem_servico,veiculo,tipo_manutencao,custo_manutencao,status")] Manutencao manutencao)
        {
            if (id != manutencao.ordem_servico)
            {
                return NotFound();
            }
            DateTime date = DateTime.Today;
            CultureInfo culture = new CultureInfo("pt-BR");

            if (ModelState.IsValid)
            {
                try
                {
                    manutencao.data_manutencao = date.ToString("dd/MM/yyyy", culture);
                    _context.Update(manutencao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManutencaoExists(manutencao.ordem_servico))
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
            return View(manutencao);
        }

        // GET: Manutencoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manutencao = await _context.Manutencao
                .FirstOrDefaultAsync(m => m.ordem_servico == id);
            if (manutencao == null)
            {
                return NotFound();
            }

            return View(manutencao);
        }

        // POST: Manutencoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var manutencao = await _context.Manutencao.FirstOrDefaultAsync(m => m.ordem_servico == id);
            manutencao.status = "Cancelada";
            if(await TryUpdateModelAsync<Manutencao>(
                manutencao,
                "",
                m => m.status
                ))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool ManutencaoExists(string id)
        {
            return _context.Manutencao.Any(e => e.ordem_servico == id);
        }
    }
}
