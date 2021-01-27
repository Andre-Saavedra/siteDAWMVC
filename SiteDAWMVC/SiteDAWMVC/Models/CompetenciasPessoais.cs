using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDAWMVC.Models
{
    public class CompetenciasPessoais
    {
        [Key]
        public int CompetenciasPessoaisId { get; set; }

        [Display(Name ="Competência")]
        public string Comptencia { get; set; }

        [Display(Name ="Observações")]
        public string Observacoes { get; set; }

        public int DadosPessoaisId { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
    }
}
