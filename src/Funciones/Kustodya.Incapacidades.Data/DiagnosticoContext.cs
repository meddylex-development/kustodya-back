using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Microsoft.EntityFrameworkCore;

namespace Kustodya.Incapacidades.Data
{
    public class DiagnosticoContext : DbContext
    {
        public DiagnosticoContext(DbContextOptions<DiagnosticoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnostico>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("tblCIE10", "Incapacidades");

                entity.Property(e => e.Id).HasColumnName("iIDCIE10");

                entity.Property(e => e.DiasMaxAcumulados).HasColumnName("iDiasMaxAcumulados");

                entity.Property(e => e.DiasMaxConsulta).HasColumnName("iDiasMaxConsulta");

                entity.Property(e => e.Sexo).HasColumnName("iIDSexo");

                entity.Property(e => e.TipoCie).HasColumnName("iIDTipoCie");

                entity.Property(e => e.Capitulo)
                    .IsRequired()
                    .HasColumnName("tCapitulo")
                    .HasMaxLength(50);

                entity.Property(e => e.Caracter)
                    .IsRequired()
                    .HasColumnName("tCaracter")
                    .HasMaxLength(50);

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("tCategoria")
                    .HasMaxLength(50);

                entity.Property(e => e.Cie)
                    .IsRequired()
                    .HasColumnName("tCIE")
                    .HasMaxLength(50);

                entity.Property(e => e.CodigoCie10)
                    .IsRequired()
                    .HasColumnName("tCIE10")
                    .HasMaxLength(50);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.TituloCapitulo)
                    .IsRequired()
                    .HasColumnName("tTituloCapitulo")
                    .HasMaxLength(500);
                    
                entity.Property(e => e.EdadMaxima)
                    .IsRequired()
                    .HasColumnName("EdadSuperior");
                    
                entity.Property(e => e.EdadMinima)
                    .IsRequired()
                    .HasColumnName("EdadInferior");
            });
            
            modelBuilder.Entity<Diagnostico>()
                .Ignore(d => d.EspecialidadMedicaId);
                
            // modelBuilder.Entity<Diagnostico>()
            //     .Ignore(d => d.EspecialidadMedica);
        }


        public DbSet<Diagnostico> Diagnosticos { get; set; }
    }

}
