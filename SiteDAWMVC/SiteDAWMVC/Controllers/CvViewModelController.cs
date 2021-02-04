using Microsoft.AspNetCore.Mvc;
using SiteDAWMVC.Data;
using SiteDAWMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDAWMVC.Controllers
{
    public class CvViewModelController : Controller
    {
        private readonly SiteDbContext db;

        public CvViewModelController(SiteDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var dadosPessoais = db.DadosPessoais.ToList();
            var competenciasPessoais = db.CompetenciasPessoais.ToList();
            var competenciasDigitais = db.CompetenciasDigitais.ToList();
            var formacao = db.Formacao.ToList();
            var experiencia = db.Experiencia.ToList();
            var foto = db.Fotos.ToList();

            var cvViewModel = new CvViewModel
            {
                Foto = foto,
                DadosPessoais = dadosPessoais,
                CompetenciasPessoais = competenciasPessoais,
                CompetenciasDigitais = competenciasDigitais,
                Formacao = formacao,
                Experiencia = experiencia
            };
            return View(cvViewModel);

        }
    }
}
