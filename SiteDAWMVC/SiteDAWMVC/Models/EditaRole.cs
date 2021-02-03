using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDAWMVC.Models
{
    public class EditaRole
    {
        public EditaRole()
        {
            Utilizadores = new List<string>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display (Name ="Função")]
        public string RoleName { get; set; }

        public List<string> Utilizadores {get;set;}
    }
}
