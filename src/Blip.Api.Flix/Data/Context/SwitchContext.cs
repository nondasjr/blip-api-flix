using System;
using Blip.Api.Flix.Models;
using Microsoft.EntityFrameworkCore;

namespace Blip.Api.Flix.Data.Context
{
    public class SwitchContext : DbContext
    {
        
        public SwitchContext(DbContextOptions<SwitchContext> options)
            : base(options)
        {
        }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Movie> Movies { get; set; }

    }
}
