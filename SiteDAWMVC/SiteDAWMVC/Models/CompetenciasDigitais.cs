using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDAWMVC.Models
{
    public class CompetenciasDigitais
    {
        [Key]
        public int CompetenciasDigitaisId { get; set; }

        
        public string Linguagem { get; set; }

        [Display(Name ="Nível")]
        public string Nivel { get; set; }

        public int DadosPessoaisId { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
    }
}

