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
    public class VendaController : Controller
    {
        private readonly Contexto _context;

        public VendaController(Contexto context)
        {
            _context = context;
        }

        // GET: Venda
        public async Task<IActionResult> Index()
        {
              return _context.Venda != null ? 
                          View(await _context.Venda.ToListAsync()) :
                          Problem("Entity set 'Contexto.Venda'  is null.");
        }

        // GET: Venda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Cliente)
                 .Include(v => v.Pagamento)
                  .Include(v => v.Vendedor)
             .FirstOrDefaultAsync(m => m.VendaId == id);

            venda.ProdutosList = await _context.VendaHasProduto
            .Include(v => v.Produto)
            .Include(v => v.Venda)
            .Where(v => v.VendaId == id).ToListAsync();

            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Venda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Venda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendaId,ValorTotal,DataVenda,Id_Cliente,Id_Vendedor,Id_Pagamento")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }

        // GET: Venda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            return View(venda);
        }

        // POST: Venda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendaId,ValorTotal,DataVenda,Id_Cliente,Id_Vendedor,Id_Pagamento")] Venda venda)
        {
            if (id != venda.VendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.VendaId))
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
            return View(venda);
        }

        // GET: Venda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Venda == null)
            {
                return Problem("Entity set 'Contexto.Venda'  is null.");
            }
            var venda = await _context.Venda.FindAsync(id);
            if (venda != null)
            {
                _context.Venda.Remove(venda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
          return (_context.Venda?.Any(e => e.VendaId == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> ImpressaoMercado(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Cliente)
                 .Include(v => v.Pagamento)
                  .Include(v => v.Vendedor)
             .FirstOrDefaultAsync(m => m.VendaId == id);

            venda.ProdutosList = await _context.VendaHasProduto
                 .Include(v => v.Produto)
                  .Where(v => v.VendaId == id)
                  .GroupBy(x => new { x.ProdutoId })
                  .Select(vp => vp.OrderByDescending(x => x.ProdutoId).First())
                           .ToListAsync();

            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }
    }
}
