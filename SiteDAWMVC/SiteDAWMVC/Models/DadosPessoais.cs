using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDAWMVC.Models
{
    
    public class DadosPessoais
    {
        [Key]
        public int DadosPessoaisId{ get; set; }

        public string Nome { get; set; }

        public string DataNascimento { get; set; }

        public int Telemovel { get; set; }

        public string Email { get; set; }

    }
}
