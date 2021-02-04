﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiteDAWMVC.Data;

namespace SiteDAWMVC.Migrations
{
    [DbContext(typeof(SiteDbContext))]
    [Migration("20210204145614_noimgg")]
    partial class noimgg
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("SiteDAWMVC.Models.CompetenciasDigitais", b =>
                {
                    b.Property<int>("CompetenciasDigitaisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DadosPessoaisId")
                        .HasColumnType("int");

                    b.Property<string>("Linguagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nivel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompetenciasDigitaisId");

                    b.HasIndex("DadosPessoaisId");

                    b.ToTable("CompetenciasDigitais");
                });

            modelBuilder.Entity("SiteDAWMVC.Models.CompetenciasPessoais", b =>
                {
                    b.Property<int>("CompetenciasPessoaisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Comptencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DadosPessoaisId")
                        .HasColumnType("int");

                    b.Property<string>("Observacoes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompetenciasPessoaisId");

                    b.HasIndex("DadosPessoaisId");

                    b.ToTable("CompetenciasPessoais");
                });

            modelBuilder.Entity("SiteDAWMVC.Models.DadosPessoais", b =>
                {
                    b.Property<int>("DadosPessoaisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Telemovel")
                        .HasColumnType("int");

                    b.HasKey("DadosPessoaisId");

                    b.ToTable("DadosPessoais");
                });

            modelBuilder.Entity("SiteDAWMVC.Models.Experiencia", b =>
                {
                    b.Property<int>("ExperienciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DadosPessoaisId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExperienciaId");

                    b.HasIndex("DadosPessoaisId");

                    b.ToTable("Experiencia");
                });

            modelBuilder.Entity("SiteDAWMVC.Models.Formacao", b =>
                {
                    b.Property<int>("FormacaoExperienciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DadosPessoaisId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FormacaoExperienciaId");

                    b.HasIndex("DadosPessoaisId");

                    b.ToTable("Formacao");
                });

            modelBuilder.Entity("SiteDAWMVC.Models.Foto", b =>
                {
                    b.Property<int>("FotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FotoNome")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FotoId");

                    b.ToTable("Fotos");
                });

            modelBuilder.Entity("SiteDAWMVC.Models.CompetenciasDigitais", b =>
                {
                    b.HasOne("SiteDAWMVC.Models.DadosPessoais", "DadosPessoais")
                        .WithMany()
                        .HasForeignKey("DadosPessoaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DadosPessoais");
                });

            modelBuilder.Entity("SiteDAWMVC.Models.CompetenciasPessoais", b =>
                {
                    b.HasOne("SiteDAWMVC.Models.DadosPessoais", "DadosPessoais")
                        .WithMany()
                        .HasForeignKey("DadosPessoaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DadosPessoais");
                });

            modelBuilder.Entity("SiteDAWMVC.Models.Experiencia", b =>
                {
                    b.HasOne("SiteDAWMVC.Models.DadosPessoais", "DadosPessoais")
                        .WithMany()
                        .HasForeignKey("DadosPessoaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DadosPessoais");
                });

            modelBuilder.Entity("SiteDAWMVC.Models.Formacao", b =>
                {
                    b.HasOne("SiteDAWMVC.Models.DadosPessoais", "DadosPessoais")
                        .WithMany()
                        .HasForeignKey("DadosPessoaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DadosPessoais");
                });
#pragma warning restore 612, 618
        }
    }
}
