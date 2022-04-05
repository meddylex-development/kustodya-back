using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Roojo.CalificacionOrigen
{
    public partial class CalificacionOrigenContext : DbContext
    {
        public CalificacionOrigenContext()
        {
        }

        public CalificacionOrigenContext(DbContextOptions<CalificacionOrigenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Correo> Correos { get; set; }
        public virtual DbSet<Adjunto> Adjuntos { get; set; }
        
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=tcp:serverbrazil2.database.windows.net;Initial Catalog=dbProtektoV1;User ID=braziladminabernal;Password=RoojoS3rv3r1;");
                optionsBuilder.UseSqlServer("Data Source=tcp:serverbrazil2.database.windows.net;Initial Catalog=sql-kustodya-prod;User ID=braziladminabernal;Password=RoojoS3rv3r1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Correo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Correos", "CalificacionOrigen");
                entity.Property(e => e.Id).HasColumnName("Id");
            });

             modelBuilder.Entity<Adjunto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("CorreoAdjuntos", "CalificacionOrigen");
                entity.Property(e => e.Id).HasColumnName("Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
