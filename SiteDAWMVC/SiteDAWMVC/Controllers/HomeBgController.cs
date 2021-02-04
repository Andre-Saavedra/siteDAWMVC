using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SiteDAWMVC.Data;
using SiteDAWMVC.Migrations;
using SiteDAWMVC.Models;

namespace SiteDAWMVC.Controllers
{
    public class HomeBgController : Controller
    {
        private readonly SiteDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeBgController(SiteDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this._webHostEnvironment = webHostEnvironment;
        }

        // GET: HomeBg
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeBg.ToListAsync());
        }

        // GET: HomeBg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeBg = await _context.HomeBg
                .FirstOrDefaultAsync(m => m.HomeBgId == id);
            if (homeBg == null)
            {
                return NotFound();
            }

            return View(homeBg);
        }

        // GET: HomeBg/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeBg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HomeBgId,Titulo,HomeBgFicheiro")] HomeBg homeBg)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string nomeFicheiro = Path.GetFileNameWithoutExtension(homeBg.HomeBgFicheiro.FileName);
                string extension = Path.GetExtension(homeBg.HomeBgFicheiro.FileName);
                homeBg.HomeBgNome = nomeFicheiro = nomeFicheiro + DateTime.Now.ToString("yymmddss") + extension;
                string path = Path.Combine(wwwRootPath + "/img", nomeFicheiro);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await homeBg.HomeBgFicheiro.CopyToAsync(fileStream);
                }


                _context.Add(homeBg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeBg);
        }

        // GET: HomeBg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeBg = await _context.HomeBg.FindAsync(id);
            if (homeBg == null)
            {
                return NotFound();
            }
            return View(homeBg);
        }

        // POST: HomeBg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HomeBgId,Titulo,HomeBgNome")] HomeBg homeBg)
        {
            if (id != homeBg.HomeBgId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeBg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeBgExists(homeBg.HomeBgId))
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
            return View(homeBg);
        }

        // GET: HomeBg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeBg = await _context.HomeBg
                .FirstOrDefaultAsync(m => m.HomeBgId == id);
            if (homeBg == null)
            {
                return NotFound();
            }

            return View(homeBg);
        }

        // POST: HomeBg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homeBg = await _context.HomeBg.FindAsync(id);

            var fotoPath = Path.Combine(_webHostEnvironment.WebRootPath, "img", homeBg.HomeBgNome);
            if (System.IO.File.Exists(fotoPath))
            {
                System.IO.File.Delete(fotoPath);
            }

            _context.HomeBg.Remove(homeBg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeBgExists(int id)
        {
            return _context.HomeBg.Any(e => e.HomeBgId == id);
        }
    }
}
