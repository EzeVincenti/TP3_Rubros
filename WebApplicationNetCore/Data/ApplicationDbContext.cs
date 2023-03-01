using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationNetCore.Models;

namespace WebApplicationNetCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplicationNetCore.Models.Rubro> Rubro { get; set; }
        public DbSet<WebApplicationNetCore.Models.Subrubro> Subrubro { get; set; }
        public DbSet<WebApplicationNetCore.Models.Articulo> Articulo { get; set; }
    }
}
