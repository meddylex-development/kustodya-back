using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Cosmos;

namespace Kustodya.Incapacidades.Data
{
    public class IncapacidadContext : DbContext
    {
        public IncapacidadContext(DbContextOptions<IncapacidadContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("incapacidades");

            modelBuilder.Entity<Incapacidad>(entity =>
            {
                entity.OwnsOne(i => i.Validacion);
                entity.OwnsOne(i => i.Afiliado);
                entity.OwnsOne(i => i.Ips);
                entity.OwnsOne(i => i.Diagnostico)
                    .Ignore(d => d.GrupoDiagnosticos);
                entity.Ignore(i => i.EspecialidadMedica);
            });
        }


        public DbSet<Incapacidad> Incapacidades { get; set; }
        public DbSet<Afiliado> Afiliados { get; set; }
        public DbSet<Ips> IPSs { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        // public DbSet<Cie10Correlacion> Cie10Correlaciones { get; set; }
    }
}
