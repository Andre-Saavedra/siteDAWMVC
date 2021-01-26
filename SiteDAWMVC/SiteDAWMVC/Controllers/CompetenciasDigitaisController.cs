using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteDAWMVC.Data;
using SiteDAWMVC.Models;

namespace SiteDAWMVC.Controllers
{
    public class CompetenciasDigitaisController : Controller
    {
        private readonly SiteDbContext _context;

        public CompetenciasDigitaisController(SiteDbContext context)
        {
            _context = context;
        }

        // GET: CompetenciasDigitais
        public async Task<IActionResult> Index()
        {
            var siteDbContext = _context.CompetenciasDigitais.Include(c => c.DadosPessoais);
            return View(await siteDbContext.ToListAsync());
        }

        // GET: CompetenciasDigitais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasDigitais = await _context.CompetenciasDigitais
                .Include(c => c.DadosPessoais)
                .FirstOrDefaultAsync(m => m.CompetenciasDigitaisId == id);
            if (competenciasDigitais == null)
            {
                return NotFound();
            }

            return View(competenciasDigitais);
        }

        // GET: CompetenciasDigitais/Create
        public IActionResult Create()
        {
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId");
            return View();
        }

        // POST: CompetenciasDigitais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompetenciasDigitaisId,Linguagem,Nivel,DadosPessoaisId")] CompetenciasDigitais competenciasDigitais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competenciasDigitais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId", competenciasDigitais.DadosPessoaisId);
            return View(competenciasDigitais);
        }

        // GET: CompetenciasDigitais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasDigitais = await _context.CompetenciasDigitais.FindAsync(id);
            if (competenciasDigitais == null)
            {
                return NotFound();
            }
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId", competenciasDigitais.DadosPessoaisId);
            return View(competenciasDigitais);
        }

        // POST: CompetenciasDigitais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompetenciasDigitaisId,Linguagem,Nivel,DadosPessoaisId")] CompetenciasDigitais competenciasDigitais)
        {
            if (id != competenciasDigitais.CompetenciasDigitaisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competenciasDigitais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetenciasDigitaisExists(competenciasDigitais.CompetenciasDigitaisId))
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
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId", competenciasDigitais.DadosPessoaisId);
            return View(competenciasDigitais);
        }

        // GET: CompetenciasDigitais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasDigitais = await _context.CompetenciasDigitais
                .Include(c => c.DadosPessoais)
                .FirstOrDefaultAsync(m => m.CompetenciasDigitaisId == id);
            if (competenciasDigitais == null)
            {
                return NotFound();
            }

            return View(competenciasDigitais);
        }

        // POST: CompetenciasDigitais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competenciasDigitais = await _context.CompetenciasDigitais.FindAsync(id);
            _context.CompetenciasDigitais.Remove(competenciasDigitais);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetenciasDigitaisExists(int id)
        {
            return _context.CompetenciasDigitais.Any(e => e.CompetenciasDigitaisId == id);
        }
    }
}
