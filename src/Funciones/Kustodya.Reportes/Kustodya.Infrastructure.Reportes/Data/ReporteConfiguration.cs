using Kustodya.Core.Reportes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kustodya.Infrastructure.Reportes.Data
{
    public class ReporteConfiguration : IEntityTypeConfiguration<Reporte>
    {
        public void Configure(EntityTypeBuilder<Reporte> builder)
        {
            // var navigation = builder.Metadata.FindNavigation(nameof(Reporte.Solicitudes));

            // navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(r => r.Solicitudes);
            // , s =>
            // {
            //     s.WithOwner(s => s.Reporte);
            //     s.UsePropertyAccessMode(PropertyAccessMode.Field);
            // });
            builder.OwnsOne(o => o.Horario, h =>
            {
                h.WithOwner();

                h.Property(a => a.FechaInicio)
                    .IsRequired();

                h.Property(a => a.FechaInicio)
                    .IsRequired();
            });
        }
    }
}
