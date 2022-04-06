using Kustodya.ApplicationCore.Entities.Medicos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.Infrastructure.Data
{
    public class MedicosContext : DbContext
    {
        public MedicosContext()
        {

        }

        public MedicosContext(DbContextOptions<MedicosContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("incapacidades");

            modelBuilder.Entity<Medico>().OwnsMany(
                o => o.Detalles);
        }

        public DbSet<Medico> Medicos { get; set; }
    }
}
