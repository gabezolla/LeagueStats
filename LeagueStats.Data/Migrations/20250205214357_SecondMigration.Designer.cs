﻿// <auto-generated />
using LeagueStats.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeagueStats.Data.Migrations
{
    [DbContext(typeof(LeagueStatsDbContext))]
    [Migration("20250205214357_SecondMigration")]
    partial class SecondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("LeagueStats.Domain.Entities.Stats", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Champion")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<double>("DamageDealt")
                        .HasColumnType("double");

                    b.Property<double>("DamagePerMinute")
                        .HasColumnType("double");

                    b.Property<double>("DamageTaken")
                        .HasColumnType("double");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Kda")
                        .HasColumnType("double");

                    b.Property<string>("Lane")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MatchId")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PlayerId")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("SkillshotsDodged")
                        .HasColumnType("int");

                    b.Property<int>("SkillshotsHit")
                        .HasColumnType("int");

                    b.Property<int>("StealthWardsPlaced")
                        .HasColumnType("int");

                    b.Property<double>("TeamDamagePercentage")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("LeagueStats.Domain.Entities.Summoner", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Tagline")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Summoners");
                });
#pragma warning restore 612, 618
        }
    }
}
