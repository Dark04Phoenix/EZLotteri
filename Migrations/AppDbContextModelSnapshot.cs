﻿// <auto-generated />
using EZLotteri.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EZLotteri.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EZLotteri.Models.Barn", b =>
                {
                    b.Property<int>("BarnID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BarnID"), 1L, 1);

                    b.Property<int>("AntalModtagneLodsedler")
                        .HasColumnType("int");

                    b.Property<int>("AntalSolgteKontanter")
                        .HasColumnType("int");

                    b.Property<int>("AntalSolgteMobilePay")
                        .HasColumnType("int");

                    b.Property<int>("BørnegruppeID")
                        .HasColumnType("int");

                    b.Property<int>("LederID")
                        .HasColumnType("int");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BarnID");

                    b.HasIndex("BørnegruppeID");

                    b.HasIndex("LederID");

                    b.ToTable("Barn", "dbo");
                });

            modelBuilder.Entity("EZLotteri.Models.Bruger", b =>
                {
                    b.Property<int>("BrugerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrugerID"), 1L, 1);

                    b.HasKey("BrugerID");

                    b.ToTable("Bruger", "dbo");
                });

            modelBuilder.Entity("EZLotteri.Models.BørneGruppe", b =>
                {
                    b.Property<int>("BørnegruppeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BørnegruppeID"), 1L, 1);

                    b.Property<int>("AntalReturneredeLodsedler")
                        .HasColumnType("int");

                    b.Property<int>("AntalUdstedteLodsedler")
                        .HasColumnType("int");

                    b.Property<int>("LederID")
                        .HasColumnType("int");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BørnegruppeID");

                    b.HasIndex("LederID");

                    b.ToTable("BørneGruppe", "dbo");
                });

            modelBuilder.Entity("EZLotteri.Models.Leder", b =>
                {
                    b.Property<int>("LederID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LederID"), 1L, 1);

                    b.Property<int>("BrugerID")
                        .HasColumnType("int");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LederID");

                    b.HasIndex("BrugerID");

                    b.ToTable("Leder", "dbo");
                });

            modelBuilder.Entity("EZLotteri.Models.Barn", b =>
                {
                    b.HasOne("EZLotteri.Models.BørneGruppe", "Børnegruppe")
                        .WithMany("Børn")
                        .HasForeignKey("BørnegruppeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EZLotteri.Models.Leder", "Leder")
                        .WithMany()
                        .HasForeignKey("LederID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Børnegruppe");

                    b.Navigation("Leder");
                });

            modelBuilder.Entity("EZLotteri.Models.BørneGruppe", b =>
                {
                    b.HasOne("EZLotteri.Models.Leder", "Leder")
                        .WithMany("Børnegruppe")
                        .HasForeignKey("LederID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leder");
                });

            modelBuilder.Entity("EZLotteri.Models.Leder", b =>
                {
                    b.HasOne("EZLotteri.Models.Bruger", "Bruger")
                        .WithMany()
                        .HasForeignKey("BrugerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bruger");
                });

            modelBuilder.Entity("EZLotteri.Models.BørneGruppe", b =>
                {
                    b.Navigation("Børn");
                });

            modelBuilder.Entity("EZLotteri.Models.Leder", b =>
                {
                    b.Navigation("Børnegruppe");
                });
#pragma warning restore 612, 618
        }
    }
}
