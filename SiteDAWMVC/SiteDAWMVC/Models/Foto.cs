using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDAWMVC.Models
{
    public class Foto
    {
        [Key]
        public int FotoId { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Nome")]
        public string FotoNome { get; set; }

        [NotMapped]
        [DisplayName("Upload")]
        public IFormFile FotoFicheiro { get; set; }
    }
}
