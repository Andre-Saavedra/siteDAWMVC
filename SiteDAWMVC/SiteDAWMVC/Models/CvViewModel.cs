using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SiteDAWMVC.Models
{
    //public class CvViewModel
    //{
    //    public DadosPessoais DadosPessoais { get; set; }
    //    public CompetenciasDigitais CompetenciasDigitais { get; set; }
    //    public CompetenciasPessoais CompetenciasPessoais { get; set; }
    //    public Formacao Formacao { get; set; }
    //    public Experiencia Experiencia { get; set; }
    //}

    public class CvViewModel
    {
        public List<DadosPessoais> DadosPessoais{ get; set; }
        public List<CompetenciasDigitais> CompetenciasDigitais { get; set; }
        public List<CompetenciasPessoais> CompetenciasPessoais { get; set; }
        public List<Formacao> Formacao { get; set; }
        public List<Experiencia> Experiencia { get; set; }
    }
}
