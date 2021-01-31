using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDAWMVC.Models
{
    public class Utilizadores
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

    }
}
