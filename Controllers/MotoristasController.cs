using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using net_car_ASPNETCORE.Models;
using System.Text.RegularExpressions;


namespace net_car_ASPNETCORE.Controllers
{
    public class MotoristasController : Controller
    {
        private readonly net_car_ASPNETCOREContext _context;

        public MotoristasController(net_car_ASPNETCOREContext context)
        {
            _context = context;
        }

        // GET: Motoristas
        public async Task<IActionResult> Index()
        {
            var query = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome });
            List<string> cnpj = new List<string>();
            foreach (var item in query)
            {
                cnpj.Add(item.nome + " - " + Util.formatCnpj(item.cnpj));
            }
            ViewBag.cnpj = cnpj.ToArray();

            return View(await _context.Motorista.ToListAsync());
        }

        // GET: Motoristas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motorista
                .FirstOrDefaultAsync(m => m.cnh == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // GET: Motoristas/Create
        public IActionResult Create()
        {
            var query = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome });
            var count = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome }).Count();

            List<string> cnpj = new List<string>();
            List<string> valueCnpj = new List<string>();

            foreach (var item in query)
            {
                cnpj.Add(item.nome + " - " + Util.formatCnpj(item.cnpj));
                valueCnpj.Add(item.cnpj);
            }
            ViewBag.cnpj = cnpj.ToArray();
            ViewBag.valueCnpj = valueCnpj.ToArray();
            
            ViewBag.count = count;
            
            return View();
        }

        // POST: Motoristas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cnh,nome,cpf,cnpj_cliente,status")] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                motorista.status = "Ativo";
                _context.Add(motorista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motorista);
        }

        // GET: Motoristas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motorista.FindAsync(id);
            if (motorista == null)
            {
                return NotFound();
            }
            var query = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome });
            var count = _context.Cliente.Select(cliente => new { cliente.cnpj, cliente.nome }).Count();

            List<string> cnpj = new List<string>();
            List<string> valueCnpj = new List<string>();

            foreach (var item in query)
            {
                cnpj.Add(item.nome + " - " + Util.formatCnpj(item.cnpj));
                valueCnpj.Add(item.cnpj);
            }
            ViewBag.cnpj = cnpj.ToArray();
            ViewBag.valueCnpj = valueCnpj.ToArray();

            ViewBag.count = count;
            return View(motorista);
        }

        // POST: Motoristas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("cnh,nome,cpf,cnpj_cliente,status")] Motorista motorista)
        {
            if (id != motorista.cnh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoristaExists(motorista.cnh))
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
            return View(motorista);
        }

        // GET: Motoristas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motorista
                .FirstOrDefaultAsync(m => m.cnh == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // POST: Motoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            
            var motorista = await _context.Motorista.FirstOrDefaultAsync(m => m.cnh == id);
            motorista.status = "Inativo";
            if (await TryUpdateModelAsync<Motorista>(
                motorista,
                "",
                m => m.status
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

        private bool MotoristaExists(string id)
        {
            return _context.Motorista.Any(e => e.cnh == id);
        }
    }
}
