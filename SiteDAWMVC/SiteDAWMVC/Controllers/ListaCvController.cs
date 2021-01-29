using Microsoft.AspNetCore.Mvc;
using SiteDAWMVC.Data;
using SiteDAWMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDAWMVC.Controllers
{
    public class ListaCvController : Controller
    {
        private readonly SiteDbContext _context;

        public ListaCvController(SiteDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            IEnumerable<DadosPessoais> objList = _context.DadosPessoais;
            return View(objList);
        }
    }
}
