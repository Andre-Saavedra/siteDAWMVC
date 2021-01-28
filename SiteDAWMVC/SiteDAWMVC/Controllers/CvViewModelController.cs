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
                Nome = "UpSkill"
            };

            CvViewModel cvViewModel = new CvViewModel()
            {
                DadosPessoais = dadosPessoais,
                Formacao = formacao
            };

            return View(cvViewModel);
        }
    }
}
