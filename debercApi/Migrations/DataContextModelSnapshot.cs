﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using debercApi.Data;

#nullable disable

namespace debercApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("debercApi.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Suit")
                        .HasColumnType("int");

                    b.Property<int?>("TrickId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TrickId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("debercApi.Models.Combination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GameRoundId")
                        .HasColumnType("int");

                    b.Property<int?>("OwnerTeamId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameRoundId");

                    b.HasIndex("OwnerTeamId");

                    b.ToTable("Combinations");
                });

            modelBuilder.Entity("debercApi.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DealerId")
                        .HasColumnType("int");

                    b.Property<int?>("FirstTeamId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("OpenPoints")
                        .HasColumnType("int");

                    b.Property<int?>("SecondTeamId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DealerId");

                    b.HasIndex("FirstTeamId");

                    b.HasIndex("SecondTeamId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("debercApi.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("debercApi.Models.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BargainRound")
                        .HasColumnType("int");

                    b.Property<int?>("DisplayedCardId")
                        .HasColumnType("int");

                    b.Property<int?>("DutyPlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderPlayerId")
                        .HasColumnType("int");

                    b.Property<int>("OrderSuit")
                        .HasColumnType("int");

                    b.Property<int?>("OwnerGameId")
                        .HasColumnType("int");

                    b.Property<int?>("VotePlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DisplayedCardId");

                    b.HasIndex("DutyPlayerId");

                    b.HasIndex("OrderPlayerId");

                    b.HasIndex("OwnerGameId");

                    b.HasIndex("VotePlayerId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("debercApi.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FirstPlayerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("SecondPlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstPlayerId");

                    b.HasIndex("SecondPlayerId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("debercApi.Models.Trick", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("OwnerRoundId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("StarterPlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerTeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerRoundId");

                    b.HasIndex("StarterPlayerId");

                    b.HasIndex("WinnerTeamId");

                    b.ToTable("Tricks");
                });

            modelBuilder.Entity("debercApi.Models.Card", b =>
                {
                    b.HasOne("debercApi.Models.Player", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("debercApi.Models.Trick", null)
                        .WithMany("Cards")
                        .HasForeignKey("TrickId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("debercApi.Models.Combination", b =>
                {
                    b.HasOne("debercApi.Models.Round", "GameRound")
                        .WithMany("Combinations")
                        .HasForeignKey("GameRoundId");

                    b.HasOne("debercApi.Models.Team", "OwnerTeam")
                        .WithMany()
                        .HasForeignKey("OwnerTeamId");

                    b.Navigation("GameRound");

                    b.Navigation("OwnerTeam");
                });

            modelBuilder.Entity("debercApi.Models.Game", b =>
                {
                    b.HasOne("debercApi.Models.Player", "Dealer")
                        .WithMany()
                        .HasForeignKey("DealerId");

                    b.HasOne("debercApi.Models.Team", "FirstTeam")
                        .WithMany()
                        .HasForeignKey("FirstTeamId");

                    b.HasOne("debercApi.Models.Team", "SecondTeam")
                        .WithMany()
                        .HasForeignKey("SecondTeamId");

                    b.Navigation("Dealer");

                    b.Navigation("FirstTeam");

                    b.Navigation("SecondTeam");
                });

            modelBuilder.Entity("debercApi.Models.Round", b =>
                {
                    b.HasOne("debercApi.Models.Card", "DisplayedCard")
                        .WithMany()
                        .HasForeignKey("DisplayedCardId");

                    b.HasOne("debercApi.Models.Player", "DutyPlayer")
                        .WithMany()
                        .HasForeignKey("DutyPlayerId");

                    b.HasOne("debercApi.Models.Player", "OrderPlayer")
                        .WithMany()
                        .HasForeignKey("OrderPlayerId");

                    b.HasOne("debercApi.Models.Game", "OwnerGame")
                        .WithMany("Rounds")
                        .HasForeignKey("OwnerGameId");

                    b.HasOne("debercApi.Models.Player", "VotePlayer")
                        .WithMany()
                        .HasForeignKey("VotePlayerId");

                    b.Navigation("DisplayedCard");

                    b.Navigation("DutyPlayer");

                    b.Navigation("OrderPlayer");

                    b.Navigation("OwnerGame");

                    b.Navigation("VotePlayer");
                });

            modelBuilder.Entity("debercApi.Models.Team", b =>
                {
                    b.HasOne("debercApi.Models.Player", "FirstPlayer")
                        .WithMany()
                        .HasForeignKey("FirstPlayerId");

                    b.HasOne("debercApi.Models.Player", "SecondPlayer")
                        .WithMany()
                        .HasForeignKey("SecondPlayerId");

                    b.Navigation("FirstPlayer");

                    b.Navigation("SecondPlayer");
                });

            modelBuilder.Entity("debercApi.Models.Trick", b =>
                {
                    b.HasOne("debercApi.Models.Round", "OwnerRound")
                        .WithMany("Tricks")
                        .HasForeignKey("OwnerRoundId");

                    b.HasOne("debercApi.Models.Player", "StarterPlayer")
                        .WithMany()
                        .HasForeignKey("StarterPlayerId");

                    b.HasOne("debercApi.Models.Team", "WinnerTeam")
                        .WithMany()
                        .HasForeignKey("WinnerTeamId");

                    b.Navigation("OwnerRound");

                    b.Navigation("StarterPlayer");

                    b.Navigation("WinnerTeam");
                });

            modelBuilder.Entity("debercApi.Models.Game", b =>
                {
                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("debercApi.Models.Round", b =>
                {
                    b.Navigation("Combinations");

                    b.Navigation("Tricks");
                });

            modelBuilder.Entity("debercApi.Models.Trick", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
