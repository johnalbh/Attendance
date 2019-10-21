﻿// <auto-generated />
using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20191020203057_Prueba-Nuevo-Vacio-2")]
    partial class PruebaNuevoVacio2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Calendario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<int>("NumeroDia");

                    b.HasKey("Id");

                    b.ToTable("Calendario");
                });

            modelBuilder.Entity("Entities.Models.Clase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdFecha");

                    b.Property<int>("IdGrupo");

                    b.Property<int>("IdHorario");

                    b.HasKey("Id");

                    b.HasIndex("IdFecha");

                    b.HasIndex("IdGrupo", "IdHorario");

                    b.ToTable("Clase");
                });

            modelBuilder.Entity("Entities.Models.Dominio", b =>
                {
                    b.Property<string>("Dominio1")
                        .HasColumnName("Dominio")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Valor")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool>("Activo");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("Ordern");

                    b.HasKey("Dominio1", "Valor");

                    b.ToTable("Dominio");
                });

            modelBuilder.Entity("Entities.Models.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdMateria");

                    b.Property<int>("NumGrupo");

                    b.Property<string>("NumeroIdentificacionEmpleado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("TipoIdentificacionEmpleado")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("IdMateria");

                    b.HasIndex("TipoIdentificacionEmpleado", "NumeroIdentificacionEmpleado");

                    b.ToTable("Grupo");
                });

            modelBuilder.Entity("Entities.Models.GrupoHorario", b =>
                {
                    b.Property<int>("IdGrupo");

                    b.Property<int>("IdHorario");

                    b.Property<bool>("Asistencia");

                    b.HasKey("IdGrupo", "IdHorario");

                    b.HasIndex("IdHorario");

                    b.ToTable("GrupoHorario");
                });

            modelBuilder.Entity("Entities.Models.Horario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Dia");

                    b.Property<TimeSpan>("HoraFin");

                    b.Property<TimeSpan>("HoraInicio");

                    b.HasKey("Id");

                    b.ToTable("Horario");
                });

            modelBuilder.Entity("Entities.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("Entities.Models.Persona", b =>
                {
                    b.Property<string>("TipoIdentificacion")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("NumeroIdentificacion")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("SegundoApellido")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("SegundoNombre")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("UrlFoto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("TipoIdentificacion", "NumeroIdentificacion");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("Entities.Models.Profesor", b =>
                {
                    b.Property<string>("TipoIdentificacion")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("NumeroIdentificacion")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("date");

                    b.HasKey("TipoIdentificacion", "NumeroIdentificacion");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Entities.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(50)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Entities.Models.Clase", b =>
                {
                    b.HasOne("Entities.Models.Calendario", "IdFechaNavigation")
                        .WithMany("Clase")
                        .HasForeignKey("IdFecha")
                        .HasConstraintName("FK_Clase_Calendario");

                    b.HasOne("Entities.Models.GrupoHorario", "IdNavigation")
                        .WithMany("Clase")
                        .HasForeignKey("IdGrupo", "IdHorario")
                        .HasConstraintName("FK_Clase_GrupoHorario");
                });

            modelBuilder.Entity("Entities.Models.Grupo", b =>
                {
                    b.HasOne("Entities.Models.Materia", "IdMateriaNavigation")
                        .WithMany("Grupo")
                        .HasForeignKey("IdMateria")
                        .HasConstraintName("FK_Grupo_Materia");

                    b.HasOne("Entities.Models.Profesor", "Profesor")
                        .WithMany("Grupo")
                        .HasForeignKey("TipoIdentificacionEmpleado", "NumeroIdentificacionEmpleado")
                        .HasConstraintName("FK_Grupo_Profesor");
                });

            modelBuilder.Entity("Entities.Models.GrupoHorario", b =>
                {
                    b.HasOne("Entities.Models.Grupo", "IdGrupoNavigation")
                        .WithMany("GrupoHorario")
                        .HasForeignKey("IdGrupo")
                        .HasConstraintName("FK_GrupoHorario_Grupo");

                    b.HasOne("Entities.Models.Horario", "IdHorarioNavigation")
                        .WithMany("GrupoHorario")
                        .HasForeignKey("IdHorario")
                        .HasConstraintName("FK_GrupoHorario_Horario");
                });

            modelBuilder.Entity("Entities.Models.Profesor", b =>
                {
                    b.HasOne("Entities.Models.Persona", "Persona")
                        .WithOne("Profesor")
                        .HasForeignKey("Entities.Models.Profesor", "TipoIdentificacion", "NumeroIdentificacion")
                        .HasConstraintName("FK_Profesor_Persona");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}