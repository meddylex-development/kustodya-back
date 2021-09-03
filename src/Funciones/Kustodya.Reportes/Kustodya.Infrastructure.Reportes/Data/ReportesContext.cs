using System.Reflection;
using Kustodya.Core.Reportes.Entities;
using Kustodya.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Kustodya.Infrastructure.Reportes.Data
{
    public class ReportesContext : DbContext
    {
        public ReportesContext()
        {

        }
        public ReportesContext(DbContextOptions<ReportesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.HasDefaultSchema("Reportes");
        }

        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
    }
}
