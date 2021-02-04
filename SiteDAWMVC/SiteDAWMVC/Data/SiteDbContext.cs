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
        public SiteDbContext()
        {
        }

        public SiteDbContext(DbContextOptions<SiteDbContext> options) : base (options)
        {

        }


        public DbSet<DadosPessoais> DadosPessoais { get; set; }
        public DbSet<Formacao> FormacaoExperiencia { get; set; }
        public DbSet<CompetenciasPessoais> CompetenciasPessoais { get; set; }
        public DbSet<CompetenciasDigitais> CompetenciasDigitais { get; set; }
        public DbSet<Experiencia> Experiencia { get; set; }
        public DbSet<Formacao> Formacao { get; set; }
        public DbSet<Foto> Fotos { get; set; }

    }
}
