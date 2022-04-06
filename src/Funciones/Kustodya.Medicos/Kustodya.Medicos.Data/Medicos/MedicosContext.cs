using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Kustodya.Medicos.Data
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
            modelBuilder.HasDefaultContainer(Environment.GetEnvironmentVariable("CosmosDb:DefaultContainer"));

            modelBuilder.Entity<Medico>(o =>
            {
                o.HasKey(m => m.id);
                o.HasPartitionKey(m => m._partitionKey);
                o.OwnsMany(m => m.Detalles)
                    .HasKey(m => m.id);
                o.OwnsMany(m => m.DatosSso)
                    .HasKey(m => m.id);
                o.OwnsMany(m => m.Sanciones);
                //o.OwnsOne(m => m.Peticion)
                //.HasKey(m => m.Id);
            });
            modelBuilder.Entity<CargueMasivo>(o =>
            {
                o.HasKey(c => c.id);
                o.HasPartitionKey(c => c._partitionKey);
                o.Property(c => c.Estado)
                    .HasConversion(new EnumToStringConverter<Medicos.Estado>());
            });
        }

        public DbSet<Medico> Medicos { get; set; }
        //public DbSet<Peticion> Peticiones { get; set; }
        public DbSet<Detalle> Detalles { get; set; }
        public DbSet<CargueMasivo> MargueMasivos { get; set; }
    }
}
