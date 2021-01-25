using Microsoft.EntityFrameworkCore;
using SiteDAWMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDAWMVC.Data
{
    public class SiteDbContext : DbContext
    {
        public SiteDbContext(DbContextOptions<SiteDbContext> options) : base (options)
        {

        }

        public DbSet<DadosPessoais> DadosPessoais { get; set; }

    }
}
