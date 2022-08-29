﻿// <auto-generated />
using System;
using HogarGestor.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HogarGestor.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HogarGestor.App.Dominio.AsignarMedico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("JovenId")
                        .HasColumnType("int");

                    b.Property<int?>("MedicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JovenId");

                    b.HasIndex("MedicoId");

                    b.ToTable("AsignarMedicos");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Abreviatura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.Historia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Diagnostico")
                        .HasColumnType("int");

                    b.Property<string>("Entorno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Historias");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.PatronesCrecimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("JovenId")
                        .HasColumnType("int");

                    b.Property<int>("Medicion")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("JovenId");

                    b.ToTable("PatronesCrecimiento");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.SugerenciaCuidado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("HistoriaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HistoriaId");

                    b.ToTable("Sugerencias");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Abreviatura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoDocumentos");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.Familiar", b =>
                {
                    b.HasBaseType("HogarGestor.App.Dominio.Persona");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parentesco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Familiar");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.Joven", b =>
                {
                    b.HasBaseType("HogarGestor.App.Dominio.Persona");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FamiliarId")
                        .HasColumnType("int");

                    b.Property<int>("HistoriaId")
                        .HasColumnType("int");

                    b.Property<float>("Latitud")
                        .HasColumnType("real");

                    b.Property<float>("longitud")
                        .HasColumnType("real");

                    b.HasIndex("FamiliarId");

                    b.HasIndex("HistoriaId");

                    b.HasDiscriminator().HasValue("Joven");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.Medico", b =>
                {
                    b.HasBaseType("HogarGestor.App.Dominio.Persona");

                    b.Property<int>("Especialidad")
                        .HasColumnType("int");

                    b.Property<string>("Rethus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TarjetaProfesional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Medico");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.AsignarMedico", b =>
                {
                    b.HasOne("HogarGestor.App.Dominio.Joven", null)
                        .WithMany("AsignarMedicos")
                        .HasForeignKey("JovenId");

                    b.HasOne("HogarGestor.App.Dominio.Medico", null)
                        .WithMany("AsignarMedicos")
                        .HasForeignKey("MedicoId");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.PatronesCrecimiento", b =>
                {
                    b.HasOne("HogarGestor.App.Dominio.Joven", null)
                        .WithMany("PatronesCrecimiento")
                        .HasForeignKey("JovenId");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.Persona", b =>
                {
                    b.HasOne("HogarGestor.App.Dominio.Genero", "Genero")
                        .WithMany("Persona")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HogarGestor.App.Dominio.TipoDocumento", "TipoDocumento")
                        .WithMany("Persona")
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.SugerenciaCuidado", b =>
                {
                    b.HasOne("HogarGestor.App.Dominio.Historia", "Historia")
                        .WithMany("SugerenciaCuidado")
                        .HasForeignKey("HistoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Historia");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.Joven", b =>
                {
                    b.HasOne("HogarGestor.App.Dominio.Familiar", "Familiar")
                        .WithMany()
                        .HasForeignKey("FamiliarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HogarGestor.App.Dominio.Historia", "Historia")
                        .WithMany()
                        .HasForeignKey("HistoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Familiar");

                    b.Navigation("Historia");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.Genero", b =>
                {
                    b.Navigation("Persona");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.Historia", b =>
                {
                    b.Navigation("SugerenciaCuidado");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.TipoDocumento", b =>
                {
                    b.Navigation("Persona");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.Joven", b =>
                {
                    b.Navigation("AsignarMedicos");

                    b.Navigation("PatronesCrecimiento");
                });

            modelBuilder.Entity("HogarGestor.App.Dominio.Medico", b =>
                {
                    b.Navigation("AsignarMedicos");
                });
#pragma warning restore 612, 618
        }
    }
}
