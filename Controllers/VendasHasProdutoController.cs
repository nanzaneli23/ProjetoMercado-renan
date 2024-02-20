using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMercado.Models;

namespace ProjetoMercado.Controllers
{
    public class VendasHasProdutoController : Controller
    {
        private readonly Contexto _context;

        public VendasHasProdutoController(Contexto context)
        {
            _context = context;
        }

        // GET: VendasHasProduto
        public async Task<IActionResult> Index()
        {
            var contexto = _context.VendaHasProduto.Include(v => v.Produto).Include(v => v.Venda);
            return View(await contexto.ToListAsync());
        }

        // GET: VendasHasProduto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VendaHasProduto == null)
            {
                return NotFound();
            }

            var vendasHasProduto = await _context.VendaHasProduto
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .FirstOrDefaultAsync(m => m.VendasHasProdutoId == id);
            if (vendasHasProduto == null)
            {
                return NotFound();
            }

            return View(vendasHasProduto);
        }

        // GET: VendasHasProduto/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "NomeProduto");
            ViewData["VendaId"] = new SelectList(_context.Venda, "VendaId", "ValorTotal");
            return View();
        }

        // POST: VendasHasProduto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendasHasProdutoId,VendaId,ProdutoId,QuantidadeVendaHas")] VendasHasProduto vendasHasProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendasHasProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "NomeProduto", vendasHasProduto.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Venda, "VendaId", "ValorTotal", vendasHasProduto.VendaId);
            return View(vendasHasProduto);
        }

        // GET: VendasHasProduto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VendaHasProduto == null)
            {
                return NotFound();
            }

            var vendasHasProduto = await _context.VendaHasProduto.FindAsync(id);
            if (vendasHasProduto == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "NomeProduto", vendasHasProduto.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Venda, "VendaId", "ValorTotal", vendasHasProduto.VendaId);
            return View(vendasHasProduto);
        }

        // POST: VendasHasProduto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendasHasProdutoId,VendaId,ProdutoId,QuantidadeVendaHas")] VendasHasProduto vendasHasProduto)
        {
            if (id != vendasHasProduto.VendasHasProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendasHasProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendasHasProdutoExists(vendasHasProduto.VendasHasProdutoId))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "NomeProduto", vendasHasProduto.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Venda, "VendaId", "ValorTotal", vendasHasProduto.VendaId);
            return View(vendasHasProduto);
        }

        // GET: VendasHasProduto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VendaHasProduto == null)
            {
                return NotFound();
            }

            var vendasHasProduto = await _context.VendaHasProduto
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .FirstOrDefaultAsync(m => m.VendasHasProdutoId == id);
            if (vendasHasProduto == null)
            {
                return NotFound();
            }

            return View(vendasHasProduto);
        }

        // POST: VendasHasProduto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VendaHasProduto == null)
            {
                return Problem("Entity set 'Contexto.VendaHasProduto'  is null.");
            }
            var vendasHasProduto = await _context.VendaHasProduto.FindAsync(id);
            if (vendasHasProduto != null)
            {
                _context.VendaHasProduto.Remove(vendasHasProduto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendasHasProdutoExists(int id)
        {
          return (_context.VendaHasProduto?.Any(e => e.VendasHasProdutoId == id)).GetValueOrDefault();
        }
    }
}
