﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiteDAWMVC.Data;

namespace SiteDAWMVC.Migrations
{
    [DbContext(typeof(SiteDbContext))]
    partial class SiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Linguagem")
                        .HasColumnType("int");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

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

                    b.Property<int>("DadosPessoaisId")
                        .HasColumnType("int");

                    b.Property<string>("LinguaMaterna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.Property<int>("OutrasLinguas")
                        .HasColumnType("int");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telemovel")
                        .HasColumnType("int");

                    b.HasKey("DadosPessoaisId");

                    b.ToTable("DadosPessoais");
                });

            modelBuilder.Entity("SiteDAWMVC.Models.FormacaoExperiencia", b =>
                {
                    b.Property<int>("FormacaoExperienciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DadosPessoaisId")
                        .HasColumnType("int");

                    b.Property<int>("Experiencia")
                        .HasColumnType("int");

                    b.Property<string>("Formacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FormacaoExperienciaId");

                    b.HasIndex("DadosPessoaisId");

                    b.ToTable("FormacaoExperiencia");
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

            modelBuilder.Entity("SiteDAWMVC.Models.FormacaoExperiencia", b =>
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
