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
    public class CompetenciasPessoaisController : Controller
    {
        private readonly SiteDbContext _context;

        public CompetenciasPessoaisController(SiteDbContext context)
        {
            _context = context;
        }

        // GET: CompetenciasPessoais
        public async Task<IActionResult> Index()
        {
            var siteDbContext = _context.CompetenciasPessoais.Include(c => c.DadosPessoais);
            return View(await siteDbContext.ToListAsync());
        }

        // GET: CompetenciasPessoais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasPessoais = await _context.CompetenciasPessoais
                .Include(c => c.DadosPessoais)
                .FirstOrDefaultAsync(m => m.CompetenciasPessoaisId == id);
            if (competenciasPessoais == null)
            {
                return NotFound();
            }

            return View(competenciasPessoais);
        }

        // GET: CompetenciasPessoais/Create
        public IActionResult Create()
        {
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId");
            return View();
        }

        // POST: CompetenciasPessoais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompetenciasPessoaisId,Comptencia,Observacoes,DadosPessoaisId")] CompetenciasPessoais competenciasPessoais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competenciasPessoais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId", competenciasPessoais.DadosPessoaisId);
            return View(competenciasPessoais);
        }

        // GET: CompetenciasPessoais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasPessoais = await _context.CompetenciasPessoais.FindAsync(id);
            if (competenciasPessoais == null)
            {
                return NotFound();
            }
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId", competenciasPessoais.DadosPessoaisId);
            return View(competenciasPessoais);
        }

        // POST: CompetenciasPessoais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompetenciasPessoaisId,Comptencia,Observacoes,DadosPessoaisId")] CompetenciasPessoais competenciasPessoais)
        {
            if (id != competenciasPessoais.CompetenciasPessoaisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competenciasPessoais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetenciasPessoaisExists(competenciasPessoais.CompetenciasPessoaisId))
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
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId", competenciasPessoais.DadosPessoaisId);
            return View(competenciasPessoais);
        }

        // GET: CompetenciasPessoais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasPessoais = await _context.CompetenciasPessoais
                .Include(c => c.DadosPessoais)
                .FirstOrDefaultAsync(m => m.CompetenciasPessoaisId == id);
            if (competenciasPessoais == null)
            {
                return NotFound();
            }

            return View(competenciasPessoais);
        }

        // POST: CompetenciasPessoais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competenciasPessoais = await _context.CompetenciasPessoais.FindAsync(id);
            _context.CompetenciasPessoais.Remove(competenciasPessoais);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetenciasPessoaisExists(int id)
        {
            return _context.CompetenciasPessoais.Any(e => e.CompetenciasPessoaisId == id);
        }
    }
}
