using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDAWMVC.Models
{
    public class CriaRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}
