using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SiteDAWMVC.Models
{
    public class CvViewModel
    {
        public DadosPessoais DadosPessoais { get; set; }
        public CompetenciasDigitais CompetenciasDigitais { get; set; }
        public CompetenciasPessoais CompetenciasPessoais { get; set; }
        public Formacao Formacao { get; set; }
        public Experiencia Experiencia { get; set; }
    }
}
