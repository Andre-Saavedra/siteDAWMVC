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

        
        public int Linguagem { get; set; }

        public int Nivel { get; set; }

        public int DadosPessoaisId { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
    }
}
