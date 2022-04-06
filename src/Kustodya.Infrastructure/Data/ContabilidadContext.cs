using System;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kustodya.Infrastructure.Data.Contabilidades
{
    public partial class ContabilidadContext : DbContext
    {
        public ContabilidadContext()
        {
        }

        public ContabilidadContext(DbContextOptions<ContabilidadContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Contabilidad");

            modelBuilder.Entity<Segmento>()
                .HasIndex(u => u.Codigo)
                .IsUnique();
            modelBuilder.Entity<Regional>()
                .HasIndex(u => u.Codigo)
                .IsUnique();
            modelBuilder.Entity<CentroCosto>()
                .HasIndex(u => new { u.Codigo, u.ContabilidadId })
                .IsUnique();

            modelBuilder.Entity<Plantilla>(o =>
            {
                o.HasKey(p => p.Id);
            });

            modelBuilder.Entity<CentroCosto>(o =>
            {
                o.HasKey(p => p.Id);
            });
            modelBuilder.Entity<Segmento>(o =>
            {
                o.HasKey(p => p.Id);
            });
            modelBuilder.Entity<Regional>(o =>
            {
                o.HasKey(p => p.Id);
            });
            modelBuilder.Entity<Puc>(o =>
            {
                o.HasKey(p => p.Id);
            });
            modelBuilder.Entity<DepuracionFolio>(o =>
            {
                o.HasKey(p => p.Id);
                o.HasOne(c => c.Folio)
                    .WithOne()
                    .HasForeignKey<DepuracionFolio>(c => c.FolioId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Entidad>(o =>
            {
                o.HasKey(p => p.Id);
                o.ToTable("Entidades", "dbo");
            });

            modelBuilder.Entity<Tercero>(o =>
            {
                o.HasKey(c => c.Id);
                o.HasIndex(c => new { c.TipoId, c.NumeroId, c.EntidadId }).IsUnique();
            });

            modelBuilder.Entity<Contabilidad>(o =>
            {
                o.HasKey(c => c.Id);
                o.HasIndex(c => new { c.EntidadId, c.Codigo }).IsUnique();
                o.HasOne(c => c.PucCreditoPorDefecto)
                    .WithOne()
                    .HasForeignKey<Contabilidad>(c => c.CodigoPucCreditoMovimientoPorDefecto)
                    .OnDelete(DeleteBehavior.NoAction);
                o.HasOne(c => c.PucDebitoPorDefecto)
                    .WithOne()
                    .HasForeignKey<Contabilidad>(c => c.CodigoPucDebitoMovimientoPorDefecto)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction);
                o.HasMany(c => c.Pucs)
                    .WithOne(p => p.Contabilidad)
                    .HasForeignKey(p => p.ContabilidadId);
                o.HasOne(c => c.ClaseDocumentoPorDefecto)
                   .WithOne()
                   .HasForeignKey<Contabilidad>(c => c.ClaseDocumentoPorDefectoId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.NoAction);
                o.HasOne(c => c.TipoAjustePorDefecto)
                   .WithOne()
                   .HasForeignKey<Contabilidad>(c => c.TipoAjustePorDefectoId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.NoAction);
                // o.HasOne(c => c.ListadoDePuc)
                // .WithOne()
                // .HasForeignKey<Contabilidad>(c => c.ListadoDePucId);
            });

            modelBuilder.Entity<DepuracionContable>()
                .HasMany(d => d.Movimientos)
                .WithOne(m => m.DepuracionContable)
                .HasForeignKey(m => m.DepuracionContableId);

            modelBuilder.Entity<DepuracionContable>()
                .HasMany(d => d.DepuracionesFolios)
                .WithOne(m => m.DepuracionContable)
                .HasForeignKey(m => m.DepuracionId);

            modelBuilder.Entity<DepuracionContable>(o =>
            {
                o.Property(p => p.NumeroFichaTecnica)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<DepuracionContable>().Property(u => u.NumeroFichaTecnica).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            // .HasOne(d => d.Segmento)
            // .WithMany()
            // .HasForeignKey(s => s.SegmentoId)
            ;

            modelBuilder.Entity<DepuracionContable>()
                .HasOne(d => d.Contabilidad)
                .WithMany(c => c.DepuracionesContables)
                .HasForeignKey(d => d.ContabilidadId);

            modelBuilder.Entity<DepuracionContable>()
                .HasOne(d => d.ClaseDocumento)
                .WithMany()
                .HasForeignKey(d => d.ClaseDocumentoId);

            modelBuilder.Entity<Movimiento>()
                .HasOne(d => d.TipoAjuste)
                .WithMany()
                .HasForeignKey(d => d.TipoAjusteId);

            modelBuilder.Entity<ClaseDocumento>()
                 .HasOne(d => d.Contabilidad)
                .WithMany()
                .HasForeignKey(d => d.ContabilidadId);

            modelBuilder.Entity<TipoAjuste>()
                 .HasOne(d => d.Contabilidad)
                .WithMany()
                .HasForeignKey(d => d.ContabilidadId);

        }

        public DbSet<Contabilidad> Contabilidades { get; set; }
        public DbSet<Puc> Pucs { get; set; }
        // public DbSet<ListadoPuc> ListadosPuc { get; set; }
        public DbSet<DepuracionContable> DepuracionesContables { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<ClaseDocumento> ClasesDocumento { get; set; }
        public DbSet<TipoAjuste> TiposAjuste { get; set; }
        public DbSet<CentroCosto> CentrosCosto { get; set; }
        public DbSet<Segmento> Segmentos { get; set; }
        public DbSet<Regional> Regionales { get; set; }
        public DbSet<Plantilla> Plantillas { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Folio> Folios { get; set; }
    }
}