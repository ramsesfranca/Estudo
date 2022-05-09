﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RF.Estudo.Infrastructure.Contexts;

namespace RF.Estudo.Infrastructure.Migrations
{
    [DbContext(typeof(EstudoContext))]
    [Migration("20220509180246_Criar_Tabela_Chale_Item")]
    partial class Criar_Tabela_Chale_Item
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChaleItem", b =>
                {
                    b.Property<Guid>("ChalesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ItensNome")
                        .HasColumnType("varchar(80)");

                    b.HasKey("ChalesId", "ItensNome");

                    b.HasIndex("ItensNome");

                    b.ToTable("ChaleItem");
                });

            modelBuilder.Entity("RF.Estudo.Domain.Entities.Chale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataHoraModificado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<decimal>("ValorAltaEstacao")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorBaixaEstacao")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Chales");
                });

            modelBuilder.Entity("RF.Estudo.Domain.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataHoraModificado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RF.Estudo.Domain.Entities.Item", b =>
                {
                    b.Property<string>("Nome")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Nome");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("RF.Estudo.Domain.Entities.Servico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataHoraModificado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<decimal>("Valor")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("RF.Estudo.Domain.Entities.Telefone", b =>
                {
                    b.Property<string>("Numero")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TipoTelefone")
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.HasKey("Numero");

                    b.HasIndex("ClienteId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("ChaleItem", b =>
                {
                    b.HasOne("RF.Estudo.Domain.Entities.Chale", null)
                        .WithMany()
                        .HasForeignKey("ChalesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RF.Estudo.Domain.Entities.Item", null)
                        .WithMany()
                        .HasForeignKey("ItensNome")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RF.Estudo.Domain.Entities.Cliente", b =>
                {
                    b.OwnsOne("RF.Estudo.Domain.ValueObjects.Localizacao", "Localizacao", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasMaxLength(250)
                                .IsUnicode(false)
                                .HasColumnType("varchar(250)")
                                .HasColumnName("Bairro");

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasMaxLength(10)
                                .IsUnicode(false)
                                .HasColumnType("varchar(10)")
                                .HasColumnName("Cep");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasMaxLength(250)
                                .IsUnicode(false)
                                .HasColumnType("varchar(250)")
                                .HasColumnName("Cidade");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasMaxLength(250)
                                .IsUnicode(false)
                                .HasColumnType("varchar(250)")
                                .HasColumnName("Endereco");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.Navigation("Localizacao");
                });

            modelBuilder.Entity("RF.Estudo.Domain.Entities.Telefone", b =>
                {
                    b.HasOne("RF.Estudo.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Telefones")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("RF.Estudo.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
