﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema_de_Inventario_ASP.Datos;

#nullable disable

namespace Sistema_de_Inventario_ASP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230811211614_Actualizacion_Base")]
    partial class Actualizacion_Base
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sistema_de_Inventario_ASP.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Sistema_de_Inventario_ASP.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("Sistema_de_Inventario_ASP.Models.Producto", b =>
                {
                    b.Property<int>("IDCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDCodigo"));

                    b.Property<int>("CantidadActual")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaID")
                        .HasColumnType("int");

                    b.Property<float>("Costo")
                        .HasColumnType("real");

                    b.Property<float>("Descuento")
                        .HasColumnType("real");

                    b.Property<int>("EstadoID")
                        .HasColumnType("int");

                    b.Property<float>("Impuesto")
                        .HasColumnType("real");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PrecioVenta")
                        .HasColumnType("real");

                    b.Property<float>("Utilidad")
                        .HasColumnType("real");

                    b.HasKey("IDCodigo");

                    b.HasIndex("CategoriaID");

                    b.HasIndex("EstadoID");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Sistema_de_Inventario_ASP.Models.Producto", b =>
                {
                    b.HasOne("Sistema_de_Inventario_ASP.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_de_Inventario_ASP.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Estado");
                });
#pragma warning restore 612, 618
        }
    }
}
