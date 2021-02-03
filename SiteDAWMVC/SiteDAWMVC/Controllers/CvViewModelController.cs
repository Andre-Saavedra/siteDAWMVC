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

        //private readonly SiteDbContext _context;

        //public CvViewModelController(SiteDbContext context)
        //{
        //    _context = context;
        //}

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

            var cvViewModel = new CvViewModel
            {
                DadosPessoais = dadosPessoais,
                CompetenciasPessoais = competenciasPessoais,
                CompetenciasDigitais = competenciasDigitais,
                Formacao = formacao,
                Experiencia = experiencia
            };
            return View(cvViewModel);


            //    DadosPessoais dadosPessoais = new DadosPessoais()
            //    {
            //        //DadosPessoaisId = 99,
            //        //Nome = "André",
            //        //DataNascimento = "99/99/1989",
            //        //Email = "andre@saavedra.com"
            //    };

            //    Formacao formacao = new Formacao()
            //    {
            //        //Nome = "Formação"
            //    };

            //    Experiencia experiencia = new Experiencia()
            //    {
            //        //Nome = "Experiencia"
            //    };

            //    CompetenciasPessoais competenciasPessoais = new CompetenciasPessoais()
            //    {
            //        //Comptencia = "Competência",
            //        //Observacoes = "Obs"
            //    };

            //    CompetenciasDigitais competenciasDigitais = new CompetenciasDigitais()
            //    {
            //        //Linguagem = "Linguagem",
            //        //Nivel = "Nível"
            //    };

            //    CvViewModel cvViewModel = new CvViewModel()
            //    {
            //        DadosPessoais = dadosPessoais,
            //        Formacao = formacao,
            //        Experiencia = experiencia,
            //        CompetenciasPessoais = competenciasPessoais,
            //        CompetenciasDigitais = competenciasDigitais
            //    };

            //    return View(cvViewModel);
        }
    }
}
