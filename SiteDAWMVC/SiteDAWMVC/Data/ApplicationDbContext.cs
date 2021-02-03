using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiteDAWMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteDAWMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Utilizadores> Utilizadores { get; set; }
    }
}
