using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calendario> Calendario { get; set; }
        public virtual DbSet<Clase> Clase { get; set; }
        public virtual DbSet<Dominio> Dominio { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<GrupoHorario> GrupoHorario { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }

        // Unable to generate entity type for table 'dbo.Parametro'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-NKKIOBJ\\SQLEXPRESS;Database=Attendance;Trusted_Connection=True; User Id=sa;Password=230488");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Calendario>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("date");
            });

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.HasOne(d => d.IdFechaNavigation)
                    .WithMany(p => p.Clase)
                    .HasForeignKey(d => d.IdFecha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clase_Calendario");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Clase)
                    .HasForeignKey(d => new { d.IdGrupo, d.IdHorario })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clase_GrupoHorario");
            });

            modelBuilder.Entity<Dominio>(entity =>
            {
                entity.HasKey(e => new { e.Dominio1, e.Valor });

                entity.Property(e => e.Dominio1)
                    .HasColumnName("Dominio")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.Property(e => e.NumeroIdentificacionEmpleado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacionEmpleado)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupo_Materia");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => new { d.TipoIdentificacionEmpleado, d.NumeroIdentificacionEmpleado })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupo_Profesor");
            });

            modelBuilder.Entity<GrupoHorario>(entity =>
            {
                entity.HasKey(e => new { e.IdGrupo, e.IdHorario });

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.GrupoHorario)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrupoHorario_Grupo");

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.GrupoHorario)
                    .HasForeignKey(d => d.IdHorario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrupoHorario_Horario");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => new { e.TipoIdentificacion, e.NumeroIdentificacion });

                entity.Property(e => e.TipoIdentificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UrlFoto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => new { e.TipoIdentificacion, e.NumeroIdentificacion });

                entity.Property(e => e.TipoIdentificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.HasOne(d => d.Persona)
                    .WithOne(p => p.Profesor)
                    .HasForeignKey<Profesor>(d => new { d.TipoIdentificacion, d.NumeroIdentificacion })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Profesor_Persona");
            });
        }
    }
}
