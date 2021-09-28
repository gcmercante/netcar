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
    public class ViagemsController : Controller
    {
        private readonly net_car_ASPNETCOREContext _context;

        public ViagemsController(net_car_ASPNETCOREContext context)
        {
            _context = context;
        }

        // GET: Viagems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Viagem.ToListAsync());
        }

        // GET: Viagems/Create
        public IActionResult Create()
        {
            var clienteQuery = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome });
            var clienteCount = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome }).Count();

            var motoristaQuery = _context.Motorista.Select(motorista => new { motorista.cnh, motorista.nome });
            var motoristaCount = _context.Motorista.Select(motorista => new { motorista.cnh, motorista.nome }).Count();

            var veiculoQuery = _context.Veiculo.Select(veiculo => new { veiculo.documento_veiculo, veiculo.modelo, veiculo.placa });
            var veiculoCount = _context.Veiculo.Select(veiculo => new { veiculo.documento_veiculo, veiculo.modelo }).Count();

            List<string> cnpj = new List<string>();
            List<string> valueCnpj = new List<string>();

            List<string> cnh = new List<string>();
            List<string> valueCnh = new List<string>();

            List<string> documento = new List<string>();
            List<string> valueDocumento = new List<string>();

            foreach (var item in clienteQuery)
            {
                cnpj.Add(item.nome + " - " + Util.formatCnpj(item.cnpj));
                valueCnpj.Add(item.cnpj);
            }

            foreach (var item in motoristaQuery)
            {
                cnh.Add(item.nome + " - " + item.cnh);
                valueCnh.Add(item.cnh);
            }

            foreach (var item in veiculoQuery)
            {
                documento.Add(item.modelo + " - " + Util.formatPlaca(item.placa));
                valueDocumento.Add(item.documento_veiculo);
            }

            ViewBag.cnpj = cnpj.ToArray();
            ViewBag.valueCnpj = valueCnpj.ToArray();
            ViewBag.clienteCount = clienteCount;

            ViewBag.cnh = cnh.ToArray();
            ViewBag.valueCnh = valueCnh.ToArray();
            ViewBag.motoristaCount = motoristaCount;

            ViewBag.documento = documento.ToArray();
            ViewBag.valueDocumento = valueDocumento.ToArray();
            ViewBag.veiculoCount = veiculoCount;

            return View();
        }

        // POST: Viagems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("numero_chamado,cnh_motorista,cnpj_cliente,documento_veiculo,status,destino,distancia,abastecimento,multa,estacionamento,data_viagem")] Viagem viagem)
        {
            DateTime date = DateTime.Today;
            CultureInfo culture = new CultureInfo("pt-BR");
            if (ModelState.IsValid)
            {
                viagem.data_viagem = date.ToString("dd/MM/yyyy", culture);
                viagem.status = "Em andamento";
                _context.Add(viagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viagem);
        }

        // GET: Viagems/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem.FindAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }

            var clienteQuery = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome });
            var clienteCount = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome }).Count();

            var motoristaQuery = _context.Motorista.Select(motorista => new { motorista.cnh, motorista.nome });
            var motoristaCount = _context.Motorista.Select(motorista => new { motorista.cnh, motorista.nome }).Count();

            var veiculoQuery = _context.Veiculo.Select(veiculo => new { veiculo.documento_veiculo, veiculo.modelo, veiculo.placa });
            var veiculoCount = _context.Veiculo.Select(veiculo => new { veiculo.documento_veiculo, veiculo.modelo }).Count();

            List<string> cnpj = new List<string>();
            List<string> valueCnpj = new List<string>();
            List<string> cnh = new List<string>();
            List<string> valueCnh = new List<string>();
            List<string> documento = new List<string>();
            List<string> valueDocumento = new List<string>();

            foreach (var item in clienteQuery)
            {
                cnpj.Add(item.nome + " - " + Util.formatCnpj(item.cnpj));
                valueCnpj.Add(item.cnpj);
            }

            foreach (var item in motoristaQuery)
            {
                cnh.Add(item.nome + " - " + item.cnh);
                valueCnh.Add(item.cnh);
            }

            foreach (var item in veiculoQuery)
            {
                documento.Add(item.modelo + " - " + Util.formatPlaca(item.placa));
                valueDocumento.Add(item.documento_veiculo);
            }

            ViewBag.cnpj = cnpj.ToArray();
            ViewBag.valueCnpj = valueCnpj.ToArray();
            ViewBag.clienteCount = clienteCount;

            ViewBag.cnh = cnh.ToArray();
            ViewBag.valueCnh = valueCnh.ToArray();
            ViewBag.motoristaCount = motoristaCount;

            ViewBag.documento = documento.ToArray();
            ViewBag.valueDocumento = valueDocumento.ToArray();
            ViewBag.veiculoCount = veiculoCount;

            return View(viagem);
        }

        // POST: Viagems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("numero_chamado,cnh_motorista,cnpj_cliente,documento_veiculo,status,destino,distancia,abastecimento,multa,estacionamento,data_viagem")] Viagem viagem)
        {
            if (id != viagem.numero_chamado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    DateTime date = DateTime.Today;
                    CultureInfo culture = new CultureInfo("pt-BR");
                    viagem.data_viagem = date.ToString("dd/MM/yyyy", culture);

                    _context.Update(viagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViagemExists(viagem.numero_chamado))
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
            return View(viagem);
        }

        // GET: Viagems/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem
                .FirstOrDefaultAsync(m => m.numero_chamado == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // POST: Viagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var viagem = await _context.Viagem.FirstOrDefaultAsync(v => v.numero_chamado == id);
            viagem.status = "Cancelada";
            if(await TryUpdateModelAsync<Viagem> (
                viagem,
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

        private bool ViagemExists(string id)
        {
            return _context.Viagem.Any(e => e.numero_chamado == id);
        }
    }
}
