﻿// <auto-generated />
using Fantasia.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fantasia.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230527163508_Seeding")]
    partial class Seeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fantasia.Shared.Boj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AktZ")
                        .HasColumnType("int");

                    b.Property<int>("AktZNep")
                        .HasColumnType("int");

                    b.Property<int>("MaxZ")
                        .HasColumnType("int");

                    b.Property<int>("MaxZNep")
                        .HasColumnType("int");

                    b.Property<int>("Obtiaznost")
                        .HasColumnType("int");

                    b.Property<int>("RandSilaUtok")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Boj");
                });

            modelBuilder.Entity("Fantasia.Shared.FyzUtoky", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FyzImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazovFunkcie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazovFyzUtoku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FyzUtoky");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FyzImageUrl = "/Client/wwwroot/images/FlyingKick60.png",
                            NazovFunkcie = "flyingkick(this.src)",
                            NazovFyzUtoku = "FlyingKick"
                        },
                        new
                        {
                            Id = 2,
                            FyzImageUrl = "/Client/wwwroot/images/BodySlam60.png",
                            NazovFunkcie = "bodyslam(this.src)",
                            NazovFyzUtoku = "BodySlam"
                        },
                        new
                        {
                            Id = 3,
                            FyzImageUrl = "/Client/wwwroot/images/PunchGataling60.png",
                            NazovFunkcie = "punchgataling(this.src)",
                            NazovFyzUtoku = "PunchGataling"
                        });
                });

            modelBuilder.Entity("Fantasia.Shared.Hrac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PostavaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostavaId");

                    b.ToTable("Hrac");
                });

            modelBuilder.Entity("Fantasia.Shared.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostavaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostavaId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Fantasia.Shared.MagUtoky", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MagImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazovFunkcie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazovMagUtoku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MagUtoky");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MagImageUrl = "/Client/wwwroot/images/fireBall60.png",
                            NazovFunkcie = "fireball(this.src)",
                            NazovMagUtoku = "FireBall"
                        },
                        new
                        {
                            Id = 2,
                            MagImageUrl = "/Client/wwwroot/images/frostNova60.png",
                            NazovFunkcie = "frostnova(this.src)",
                            NazovMagUtoku = "FrostNova"
                        },
                        new
                        {
                            Id = 3,
                            MagImageUrl = "/Client/wwwroot/images/windSlash60.png",
                            NazovFunkcie = "windslash(this.src)",
                            NazovMagUtoku = "WindSlash"
                        });
                });

            modelBuilder.Entity("Fantasia.Shared.Postava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FyzUtokyId")
                        .HasColumnType("int");

                    b.Property<int>("FyzickaSila")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MagUtokyId")
                        .HasColumnType("int");

                    b.Property<int>("MagickaSila")
                        .HasColumnType("int");

                    b.Property<int>("Stamina")
                        .HasColumnType("int");

                    b.Property<int>("Stastie")
                        .HasColumnType("int");

                    b.Property<int>("VieUtokyId")
                        .HasColumnType("int");

                    b.Property<int>("Viera")
                        .HasColumnType("int");

                    b.Property<int>("Vitalita")
                        .HasColumnType("int");

                    b.Property<int>("VolneStaty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FyzUtokyId");

                    b.HasIndex("MagUtokyId");

                    b.HasIndex("VieUtokyId");

                    b.ToTable("Postava");
                });

            modelBuilder.Entity("Fantasia.Shared.VieUtoky", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NazovFunkcie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazovVieUtoku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VieImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VieUtoky");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NazovFunkcie = "heal(this.src)",
                            NazovVieUtoku = "Heal",
                            VieImageUrl = "/Client/wwwroot/images/heal60.png"
                        },
                        new
                        {
                            Id = 2,
                            NazovFunkcie = "bonusDef(this.src)",
                            NazovVieUtoku = "DefBonus",
                            VieImageUrl = "/Client/wwwroot/images/defBonus60.png"
                        },
                        new
                        {
                            Id = 3,
                            NazovFunkcie = "bonusUtok(this.src)",
                            NazovVieUtoku = "AttakeBonus",
                            VieImageUrl = "/Client/wwwroot/images/AttakeBonus60.png"
                        });
                });

            modelBuilder.Entity("Fantasia.Shared.Hrac", b =>
                {
                    b.HasOne("Fantasia.Shared.Postava", "Postava")
                        .WithMany()
                        .HasForeignKey("PostavaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Postava");
                });

            modelBuilder.Entity("Fantasia.Shared.Image", b =>
                {
                    b.HasOne("Fantasia.Shared.Postava", "Postava")
                        .WithMany()
                        .HasForeignKey("PostavaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Postava");
                });

            modelBuilder.Entity("Fantasia.Shared.Postava", b =>
                {
                    b.HasOne("Fantasia.Shared.FyzUtoky", "FyzUtoky")
                        .WithMany()
                        .HasForeignKey("FyzUtokyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fantasia.Shared.MagUtoky", "MagUtoky")
                        .WithMany()
                        .HasForeignKey("MagUtokyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fantasia.Shared.VieUtoky", "VieUtoky")
                        .WithMany()
                        .HasForeignKey("VieUtokyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FyzUtoky");

                    b.Navigation("MagUtoky");

                    b.Navigation("VieUtoky");
                });
#pragma warning restore 612, 618
        }
    }
}
