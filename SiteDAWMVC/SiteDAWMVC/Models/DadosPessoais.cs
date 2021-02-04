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
        public int DadosPessoaisId { get; set; }

        [Required(ErrorMessage = "O campo deve ser preenchido")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "O nome deve ter pelo menos 4 caracteres e não deve exceder os 200 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo deve ser preenchido")]
        [RegularExpression(@"(\d{1,2})(\/|-|\s|\\)(\d{1,2})(\/|-|\s|\\)(\d{4})", ErrorMessage = "Por favor introduza a data de nascimento no formato dd/mm/aaaa")]
        [Display(Name = "Data de Nascimento")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo deve ser preenchido")]
        [RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Telefone Inválido")]
        [Display(Name = "Telemóvel")]
        public int Telemovel { get; set; }

        [Required(ErrorMessage = "O campo deve ser preenchido")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

       
    }
}
