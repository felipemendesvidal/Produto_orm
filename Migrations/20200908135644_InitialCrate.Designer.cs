﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senai_Aula6.Context;

namespace Senai_Aula6.Migrations
{
    [DbContext(typeof(PedidoContext))]
    [Migration("20200908135644_InitialCrate")]
    partial class InitialCrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Senai_Aula6.Domains.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderData")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Senai_Aula6.Domains.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Preco")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Senai_Aula6.Domains.ProdutoItem", b =>
                {
                    b.Property<Guid>("IdProdutoItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPedido")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProduto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PedidosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProdutosId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdProdutoItem");

                    b.HasIndex("PedidosId");

                    b.HasIndex("ProdutosId");

                    b.ToTable("ProdutoItem");
                });

            modelBuilder.Entity("Senai_Aula6.Domains.ProdutoItem", b =>
                {
                    b.HasOne("Senai_Aula6.Domains.Pedido", "Pedidos")
                        .WithMany()
                        .HasForeignKey("PedidosId");

                    b.HasOne("Senai_Aula6.Domains.Produto", "Produtos")
                        .WithMany()
                        .HasForeignKey("ProdutosId");
                });
#pragma warning restore 612, 618
        }
    }
}