using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteDAWMVC.Data;
using SiteDAWMVC.Models;

namespace SiteDAWMVC.Controllers
{
    public class FotoController : Controller
    {
        private readonly SiteDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FotoController(SiteDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Foto
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fotos.ToListAsync());
        }

        // GET: Foto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foto = await _context.Fotos
                .FirstOrDefaultAsync(m => m.FotoId == id);
            if (foto == null)
            {
                return NotFound();
            }

            return View(foto);
        }

        // GET: Foto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FotoId,Titulo,FotoFicheiro")] Foto foto)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string nomeFicheiro = Path.GetFileNameWithoutExtension(foto.FotoFicheiro.FileName);
                string extension = Path.GetExtension(foto.FotoFicheiro.FileName);
                foto.FotoNome = nomeFicheiro = nomeFicheiro + DateTime.Now.ToString("yymmddss") + extension;
                string path = Path.Combine(wwwRootPath + "/img", nomeFicheiro);
                using(var fileStream = new FileStream(path, FileMode.Create))
                {
                    await foto.FotoFicheiro.CopyToAsync(fileStream);
                }


                _context.Add(foto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foto);
        }

        // GET: Foto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foto = await _context.Fotos.FindAsync(id);
            if (foto == null)
            {
                return NotFound();
            }
            return View(foto);
        }

        // POST: Foto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FotoId,Titulo,FotoNome")] Foto foto)
        {
            if (id != foto.FotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotoExists(foto.FotoId))
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
            return View(foto);
        }

        // GET: Foto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foto = await _context.Fotos
                .FirstOrDefaultAsync(m => m.FotoId == id);
            if (foto == null)
            {
                return NotFound();
            }

            return View(foto);
        }

        // POST: Foto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foto = await _context.Fotos.FindAsync(id);

            var fotoPath = Path.Combine(_hostEnvironment.WebRootPath, "img", foto.FotoNome);
            if(System.IO.File.Exists(fotoPath))
            {
                System.IO.File.Delete(fotoPath);
            }

            _context.Fotos.Remove(foto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotoExists(int id)
        {
            return _context.Fotos.Any(e => e.FotoId == id);
        }
    }
}
