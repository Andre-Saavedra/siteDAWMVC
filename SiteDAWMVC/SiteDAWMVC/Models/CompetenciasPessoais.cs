﻿using System;
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

        public string Comptencia { get; set; }

        public int Observacoes { get; set; }

        public int DadosPessoaisId { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
    }
}
