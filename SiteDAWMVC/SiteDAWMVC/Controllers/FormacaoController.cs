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
    public class FormacaoController : Controller
    {
        private readonly SiteDbContext _context;

        public FormacaoController(SiteDbContext context)
        {
            _context = context;
        }

        // GET: Formacaos
        public async Task<IActionResult> Index()
        {
            var siteDbContext = _context.FormacaoExperiencia.Include(f => f.DadosPessoais);
            return View(await siteDbContext.ToListAsync());
        }

        // GET: Formacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacao = await _context.FormacaoExperiencia
                .Include(f => f.DadosPessoais)
                .FirstOrDefaultAsync(m => m.FormacaoExperienciaId == id);
            if (formacao == null)
            {
                return NotFound();
            }

            return View(formacao);
        }

        // GET: Formacaos/Create
        public IActionResult Create()
        {
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId");
            return View();
        }

        // POST: Formacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormacaoExperienciaId,Nome,DadosPessoaisId")] Formacao formacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId", formacao.DadosPessoaisId);
            return View(formacao);
        }

        // GET: Formacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacao = await _context.FormacaoExperiencia.FindAsync(id);
            if (formacao == null)
            {
                return NotFound();
            }
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId", formacao.DadosPessoaisId);
            return View(formacao);
        }

        // POST: Formacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormacaoExperienciaId,Nome,DadosPessoaisId")] Formacao formacao)
        {
            if (id != formacao.FormacaoExperienciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormacaoExists(formacao.FormacaoExperienciaId))
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
            ViewData["DadosPessoaisId"] = new SelectList(_context.DadosPessoais, "DadosPessoaisId", "DadosPessoaisId", formacao.DadosPessoaisId);
            return View(formacao);
        }

        // GET: Formacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacao = await _context.FormacaoExperiencia
                .Include(f => f.DadosPessoais)
                .FirstOrDefaultAsync(m => m.FormacaoExperienciaId == id);
            if (formacao == null)
            {
                return NotFound();
            }

            return View(formacao);
        }

        // POST: Formacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formacao = await _context.FormacaoExperiencia.FindAsync(id);
            _context.FormacaoExperiencia.Remove(formacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormacaoExists(int id)
        {
            return _context.FormacaoExperiencia.Any(e => e.FormacaoExperienciaId == id);
        }
    }
}
