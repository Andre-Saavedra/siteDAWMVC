using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDAWMVC.Models
{
    public class FormacaoExperiencia
    {
        [Key]
        public int FormacaoExperienciaId { get; set; }

        public string Formacao { get; set; }

        public int Experiencia{ get; set; }

        public int DadosPessoaisId { get; set; }
        public DadosPessoais DadosPessoais{ get; set; }
    }
}
