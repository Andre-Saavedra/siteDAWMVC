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
    public class ExperienciaController : Controller
    {
        private readonly SiteDbContext _context;

        public ExperienciaController(SiteDbContext context)
        {
            _context = context;
        }

        // GET: Experiencia
        public async Task<IActionResult> Index()
        {
            var siteDbContext = _context.Experiencia.Include(e => e.DadosPessoais);
            return View(await siteDbContext.ToListAsync());
        }

        // GET: Experiencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencia = await _context.Experiencia
                .Include(e => e.DadosPessoais)
                .FirstOrDefaultAsync(m => m.ExperienciaId == id);
            if (experiencia == null)
            {
                return NotFound();
            }

            return View(experiencia);
        }

        // GET: Experiencia/Create
        public IActionResult Create()
        {
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId");
            return View();
        }

        // POST: Experiencia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExperienciaId,Nome,DadosPessoaisId")] Experiencia experiencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experiencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId", experiencia.DadosPessoaisId);
            return View(experiencia);
        }

        // GET: Experiencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencia = await _context.Experiencia.FindAsync(id);
            if (experiencia == null)
            {
                return NotFound();
            }
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId", experiencia.DadosPessoaisId);
            return View(experiencia);
        }

        // POST: Experiencia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExperienciaId,Nome,DadosPessoaisId")] Experiencia experiencia)
        {
            if (id != experiencia.ExperienciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experiencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienciaExists(experiencia.ExperienciaId))
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
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId", experiencia.DadosPessoaisId);
            return View(experiencia);
        }

        // GET: Experiencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencia = await _context.Experiencia
                .Include(e => e.DadosPessoais)
                .FirstOrDefaultAsync(m => m.ExperienciaId == id);
            if (experiencia == null)
            {
                return NotFound();
            }

            return View(experiencia);
        }

        // POST: Experiencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experiencia = await _context.Experiencia.FindAsync(id);
            _context.Experiencia.Remove(experiencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienciaExists(int id)
        {
            return _context.Experiencia.Any(e => e.ExperienciaId == id);
        }
    }
}
