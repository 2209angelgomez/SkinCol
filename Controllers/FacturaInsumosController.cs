using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkinCol.Data;
using SkinCol.Models;

namespace SkinCol.Controllers
{
    public class FacturaInsumosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturaInsumosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FacturaInsumos
        public async Task<IActionResult> Index()
        {
            var lista = _context.FacturaInsumos.Include(p => p.Proveedor).Include(m => m.Material);
            return View(await lista.ToListAsync());
        }

        // GET: FacturaInsumos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaInsumos = await _context.FacturaInsumos.Include(p => p.Proveedor).Include(m => m.Material)
                .FirstOrDefaultAsync(m => m.FacturaInsumosID == id);
            if (facturaInsumos == null)
            {
                return NotFound();
            }

            return View(facturaInsumos);
        }

        // GET: FacturaInsumos/Create
        public IActionResult Create()
        {
            ViewData["ProveedorID"] = new SelectList(_context.Proveedor, "ProveedorID", "Nombre");
            ViewData["MaterialID"] = new SelectList(_context.Material, "MaterialID", "Nombre");
            return View();
        }

        // POST: FacturaInsumos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacturaInsumosID,ProveedorID,MaterialID,Cantidad,Costo")] FacturaInsumos facturaInsumos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturaInsumos);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facturaInsumos);
        }

        // GET: FacturaInsumos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaInsumos = await _context.FacturaInsumos.FindAsync(id);
            ViewData["ProveedorID"] = new SelectList(_context.Proveedor, "ProveedorID", "Nombre", facturaInsumos.Proveedor);
            ViewData["MaterialID"] = new SelectList(_context.Material, "MaterialID", "Nombre", facturaInsumos.Material);
            if (facturaInsumos == null)
            {
                return NotFound();
            }
            return View(facturaInsumos);
        }

        // POST: FacturaInsumos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacturaInsumosID,ProveedorID,MaterialID,Cantidad,Costo")] FacturaInsumos facturaInsumos)
        {
            if (id != facturaInsumos.FacturaInsumosID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturaInsumos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaInsumosExists(facturaInsumos.FacturaInsumosID))
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
            return View(facturaInsumos);
        }

        // GET: FacturaInsumos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaInsumos = await _context.FacturaInsumos
                .FirstOrDefaultAsync(m => m.FacturaInsumosID == id);
            if (facturaInsumos == null)
            {
                return NotFound();
            }

            return View(facturaInsumos);
        }

        // POST: FacturaInsumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaInsumos = await _context.FacturaInsumos.FindAsync(id);
            _context.FacturaInsumos.Remove(facturaInsumos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaInsumosExists(int id)
        {
            return _context.FacturaInsumos.Any(e => e.FacturaInsumosID == id);
        }
    }
}
