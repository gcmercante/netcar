using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using net_car_ASPNETCORE.Models;
using CryptSharp;

namespace net_car_ASPNETCORE.Controllers
{
    public class ClientesController : Controller
    {
        private readonly net_car_ASPNETCOREContext _context;

        public ClientesController(net_car_ASPNETCOREContext context)
        {
            _context = context;
        }


        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.cnpj == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cnpj,nome,segmento,email,user,senha,status")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.status = "Ativo";
                cliente.senha = Util.Codifica(cliente.senha);
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("cnpj,nome,segmento,email,user,senha,status")] Cliente cliente)
        {
            if (id != cliente.cnpj)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cliente.senha = Util.Codifica(cliente.senha);
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.cnpj))
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
            return View(cliente);
        }
        //GET
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.cnpj == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, [Bind("cnpj,nome,segmento,email,user,senha,status")] Cliente cliente)
        {
            cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.cnpj == id);
            cliente.status = "Inativo";
            if (await TryUpdateModelAsync<Cliente>(
                cliente,
                "",
                c => c.status
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

        private bool ClienteExists(string id)
        {
            return _context.Cliente.Any(e => e.cnpj == id);
        }
    }
}
