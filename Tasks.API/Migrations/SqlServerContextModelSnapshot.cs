﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tasks.API.Data;

namespace Tasks.API.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    partial class SqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tasks.API.Data.Model.Tb_usuario", b =>
                {
                    b.Property<int>("Pk_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Dh_alteracao")
                        .HasColumnType("Datetime");

                    b.Property<DateTime>("Dh_expirationrefreshtoken")
                        .HasColumnType("Datetime");

                    b.Property<DateTime>("Dh_inclusao")
                        .HasColumnType("Datetime");

                    b.Property<string>("Ds_email")
                        .HasColumnType("Varchar(200)");

                    b.Property<string>("Ds_usuario")
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Hx_password")
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Hx_refreshtoken")
                        .HasColumnType("Varchar(150)");

                    b.Property<bool>("Tg_inativo")
                        .HasColumnType("bit");

                    b.HasKey("Pk_id");

                    b.ToTable("Tb_usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
