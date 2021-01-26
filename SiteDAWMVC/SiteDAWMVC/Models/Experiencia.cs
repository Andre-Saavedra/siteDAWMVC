using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDAWMVC.Models
{
    public class Experiencia
    {
        [Key]
        public int ExperienciaId { get; set; }

        public string Nome { get; set; }

        public int DadosPessoaisId { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
    }
}
