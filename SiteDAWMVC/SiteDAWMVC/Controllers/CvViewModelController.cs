using Microsoft.AspNetCore.Mvc;
using SiteDAWMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDAWMVC.Controllers
{
    public class CvViewModelController : Controller
    {
        public IActionResult Index()
        {
            DadosPessoais dadosPessoais = new DadosPessoais()
            {
                DadosPessoaisId = 99,
                Nome = "André",
                DataNascimento = "99/99/1989",
                Email = "andre@saavedra.com"
            };

            Formacao formacao = new Formacao()
            {
                Nome = "Formação"
            };

            Experiencia experiencia = new Experiencia() 
            { 
                Nome = "Experiencia"
            };

            CompetenciasPessoais competenciasPessoais = new CompetenciasPessoais()
            {
                Comptencia = "Competência",
                Observacoes = "Obs"
            };

            CompetenciasDigitais competenciasDigitais = new CompetenciasDigitais()
            { 
                Linguagem = "Linguagem",
                Nivel = "Nível"
            };

            CvViewModel cvViewModel = new CvViewModel()
            {
                DadosPessoais = dadosPessoais,
                Formacao = formacao,
                Experiencia = experiencia,
                CompetenciasPessoais = competenciasPessoais,
                CompetenciasDigitais = competenciasDigitais
            };

            return View(cvViewModel);
        }
    }
}
