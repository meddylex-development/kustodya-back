using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Roojo.Rethus
{
    public partial class RethusContext : DbContext
    {
        public RethusContext()
        {
        }

        public RethusContext(DbContextOptions<RethusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DatoSso> DatosSSO { get; set; }
        public virtual DbSet<DatoAcademico> DatosAcademicos { get; set; }
        public virtual DbSet<Dato> Datos { get; set; }
        public virtual DbSet<Sancion> Sanciones { get; set; }
        // public virtual DbSet<TipoIdentificacion> TiposIdentificacion { get; set; }
        public virtual DbSet<Consulta> Consultas { get; set; }
        public virtual DbSet<Tarea> Tareas { get; set; }
        public virtual DbSet<Robot> Robots { get; set; }
        // public virtual DbSet<TipoBusqueda> TiposBusqueda { get; set; }
        // public virtual DbSet<Estados> Estados { get; set; }
        // public virtual DbSet<TipoTarea> Tipostarea { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=tcp:serverbrazil2.database.windows.net;Initial Catalog=dbProtektoV1;User ID=braziladminabernal;Password=RoojoS3rv3r1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatoAcademico>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("tblRethusData_Academic", "rethus");

                entity.Property(e => e.Id).HasColumnName("iIDAcademicData");

                entity.Property(e => e.FechaInicioEjercerActoAdmin)
                    .HasColumnName("tFechaInicioEjercerActoAdmin");

                entity.Property(e => e.ConsultaId).HasColumnName("iIDRethusQuery");

                entity.Property(e => e.ActoAdministrativo)
                    .HasColumnName("tActoAdministrativo")
                    .HasMaxLength(500);

                entity.Property(e => e.EntidadReportadora)
                    .HasColumnName("tEntidadReportadora")
                    .HasMaxLength(500);

                entity.Property(e => e.OrigenObtencionTitulo)
                    .HasColumnName("tOrigenObtencionTitulo")
                    .HasMaxLength(500);

                entity.Property(e => e.ProfesionOcupacion)
                    .HasColumnName("tProfesionOcupacion")
                    .HasMaxLength(500);

                entity.Property(e => e.TipoPrograma)
                    .HasColumnName("tTipoPrograma")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Dato>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_tbl.RethusData_Main");

                entity.ToTable("tblRethusData_Main", "rethus");

                entity.Property(e => e.Id).HasColumnName("iIDMainData");

                entity.Property(e => e.ConsultaId).HasColumnName("iIDRethusQuery");

                entity.Property(e => e.EstadoIdentificacion)
                    .HasColumnName("tEstadoIdentificacion")
                    .HasMaxLength(20);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasColumnName("tNrodentificacion")
                    .HasMaxLength(100);

                entity.Property(e => e.PrimerApellido)
                    .HasColumnName("tPrimerApellido")
                    .HasMaxLength(100);

                entity.Property(e => e.PrimerNombre)
                    .HasColumnName("tPrimerNombre")
                    .HasMaxLength(100);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("tSegundoApellido")
                    .HasMaxLength(100);

                entity.Property(e => e.SegundoNombre)
                    .HasColumnName("tSegundoNombre")
                    .HasMaxLength(100);

                entity.Property(e => e.TipoIdentificacion)
                    .HasColumnName("tTipoIdentificacion")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Consulta)
                    .WithMany(p => p.Datos)
                    .HasForeignKey(d => d.ConsultaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRethusData_Main_tblRethusQuerys");
            });

            modelBuilder.Entity<Sancion>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("tblRethusData_Sanctions", "rethus");

                entity.Property(e => e.Id).HasColumnName("iIDSanctionData");

                entity.Property(e => e.FechaEjecucion)
                    .HasColumnName("tFechaEjecucion");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("tFechaInicio");

                entity.Property(e => e.FehaFin)
                    .HasColumnName("tFehaFin");

                entity.Property(e => e.ConsultaId).HasColumnName("iIDRethusQuery");

                entity.Property(e => e.CodigoTipoSancion)
                    .HasColumnName("tCodTipoSancion")
                    .HasMaxLength(100);

                entity.Property(e => e.InstanciaEmiteFallo)
                    .HasColumnName("tInstanciaEmiteFallo")
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("tblRethusQuerys", "rethus");

                entity.Property(e => e.Id).HasColumnName("iIDRethusQuerys")
                    .ValueGeneratedOnAdd();

                // entity.Ignore(e => e.id);

                entity.Property(e => e.EstaEnRethus).HasColumnName("bIsInRethus");

                // entity.Property(e => e.EstadoId).HasColumnName("iIDQueryState");

                entity.Property(e => e.TipoIdentificacion).HasColumnName("iIDRethusIdentificationType");

                entity.Property(e => e.TipoBusqueda).HasColumnName("iIDSearchType");

                entity.Property(e => e.TareaId).HasColumnName("iIDTask");

                entity.Property(e => e.Nombre)
                    .HasColumnName("tFirstName")
                    .HasMaxLength(100);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasColumnName("tIdentificationNumber")
                    .HasMaxLength(100);

                entity.Property(e => e.Apellido)
                    .HasColumnName("tLastName")
                    .HasMaxLength(100);

                entity.Property(e => e.Estado)
                    .HasColumnName("iIDQueryState");


            });

             modelBuilder.Entity<Consulta>()
                .HasMany(d => d.Datos)
                .WithOne(m => m.Consulta)
                .HasForeignKey(m => m.ConsultaId);

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("tblRethusTasks", "rethus");

                entity.Property(e => e.Id).HasColumnName("iIDTask")
                    .ValueGeneratedOnAdd();

                // entity.Ignore(e => e.id);

                entity.Property(e => e.FechaAsignacion)
                    .HasColumnName("dtAllocatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaFinalizacion)
                    .HasColumnName("dtEndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("dtInitalDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuarioAsignadorId).HasColumnName("iIDAllocatorUser");

                entity.Property(e => e.RobotAsignadoId).HasColumnName("iIDAssignedRobot");

                entity.Property(e => e.Estado).HasColumnName("iIDTaskState");

                entity.Property(e => e.Prioridad).HasColumnName("iIDPriority");

                entity.Property(e => e.TipoTarea).HasColumnName("iIDTaskType");

                entity.HasOne(d => d.RobotAsignado)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.RobotAsignadoId)
                    .HasConstraintName("FK_tblRethusTasks_tblRobots");


                entity.HasMany(d => d.Consultas);
            });

            modelBuilder.Entity<Robot>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("tblRobots", "rethus");

                entity.Property(e => e.Id).HasColumnName("iIDRobot");

                entity.Property(e => e.CodigoInterno)
                    .HasColumnName("tRobotInternalCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ubicacion)
                    .HasColumnName("tRobotLocation")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .HasColumnName("tRobotName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DatoSso>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("tblRethusData_SSO", "rethus");

                entity.Property(e => e.Id).HasColumnName("iIDSSOData");

                entity.Property(e => e.ConsultaId)
                    .HasColumnName("iIDRethusQuery")
                    .HasMaxLength(50);

                entity.Property(e => e.TipoPrestacion)
                    .HasColumnName("tTipoPrestacion")
                    .HasMaxLength(100);

                entity.Property(e => e.LugarPrestacion)
                    .HasColumnName("tLugarPrestacion")
                    .HasMaxLength(100);

                entity.Property(e => e.TipoLugarPrestacion)
                    .HasColumnName("tTipoLugarPrestacion")
                    .HasMaxLength(100);

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("tFechaInicio")
                    .HasMaxLength(50);

                entity.Property(e => e.FechaFin)
                    .HasColumnName("tFechaFin")
                    .HasMaxLength(50);
                    
                entity.Property(e => e.ModalidadPrestacion)
                    .HasColumnName("tModalidadPrestacion")
                    .HasMaxLength(100);
                    
                entity.Property(e => e.ProgramaPrestacion)
                    .HasColumnName("tProgramaPrestacion")
                    .HasMaxLength(100);
                    
                entity.Property(e => e.EntidadReportadora)
                    .HasColumnName("tEntidadReportadora")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
