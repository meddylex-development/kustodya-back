using Kustodya.Core.Reportes.Entities;
using Kustodya.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Kustodya.Infrastructure.Reportes.Data
{
    public class ReportesCosmosContext : DbContext
    {
        private string _contenedor;

        public ReportesCosmosContext()
        {

        }

        public ReportesCosmosContext(DbContextOptions<ReportesContext> options, IOptionsMonitor<OpcionesCosmosDB> opcionesCosmos)
            : base(options)
        {
            _contenedor = opcionesCosmos.CurrentValue.DefaultContainer;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer(_contenedor);

            modelBuilder.Entity<Reporte>(o =>
            {
                o.HasMany(r => r.Solicitudes);
                o.OwnsOne(r => r.Horario);
                o.HasKey(r => r.Id);
            });

            modelBuilder.Entity<Solicitud>(o =>
            {
                o.HasKey(r => r.Id);
            });
        }

        public DbSet<Solicitud> UsosReporte { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
    }

}
