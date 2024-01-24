﻿// <auto-generated />
using System;
using GameProject.Identity.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameProject.Identity.Migrations
{
    [DbContext(typeof(ApplicationIdentityDbContext))]
    [Migration("20240124103829_FixedOnDeleteBehaviourInUserGamesTable")]
    partial class FixedOnDeleteBehaviourInUserGamesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GameProject.Domain.Models.Business.Games.Common.BaseGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BackgroundImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RawgId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("GameProject.Domain.Models.Shared.UsersAbandonedGames", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AbandonedGameId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "AbandonedGameId");

                    b.HasIndex("AbandonedGameId");

                    b.ToTable("UsersAbandonedGames", (string)null);
                });

            modelBuilder.Entity("GameProject.Domain.Models.Shared.UsersDesiredGames", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DesiredGameId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "DesiredGameId");

                    b.HasIndex("DesiredGameId");

                    b.ToTable("UsersDesiredGames", (string)null);
                });

            modelBuilder.Entity("GameProject.Domain.Models.Shared.UsersFinishedGames", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FinishedGameId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "FinishedGameId");

                    b.HasIndex("FinishedGameId");

                    b.ToTable("UsersFinishedGames", (string)null);
                });

            modelBuilder.Entity("GameProject.Domain.Models.Shared.UsersInProgressGames", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InProgressGameId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "InProgressGameId");

                    b.HasIndex("InProgressGameId");

                    b.ToTable("UsersInProgressGames", (string)null);
                });

            modelBuilder.Entity("GameProject.Domain.Models.Shared.UsersStartedGames", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StartedGameId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "StartedGameId");

                    b.HasIndex("StartedGameId");

                    b.ToTable("UsersStartedGames", (string)null);
                });

            modelBuilder.Entity("GameProject.Identity.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Platforms")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("GameProject.Identity.Models.ProfilePhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ProfilePhotos", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GameProject.Domain.Models.Business.Games.AbandonedGame", b =>
                {
                    b.HasBaseType("GameProject.Domain.Models.Business.Games.Common.BaseGame");

                    b.ToTable("AbandonedGames");
                });

            modelBuilder.Entity("GameProject.Domain.Models.Business.Games.DesiredGame", b =>
                {
                    b.HasBaseType("GameProject.Domain.Models.Business.Games.Common.BaseGame");

                    b.ToTable("DesiredGames");
                });

            modelBuilder.Entity("GameProject.Domain.Models.Business.Games.FinishedGame", b =>
                {
                    b.HasBaseType("GameProject.Domain.Models.Business.Games.Common.BaseGame");

                    b.ToTable("FinishedGames");
                });

            modelBuilder.Entity("GameProject.Domain.Models.Business.Games.InProgressGame", b =>
                {
                    b.HasBaseType("GameProject.Domain.Models.Business.Games.Common.BaseGame");

                    b.ToTable("InProgressGames");
                });

            modelBuilder.Entity("GameProject.Domain.Models.Business.Games.StartedGame", b =>
                {
                    b.HasBaseType("GameProject.Domain.Models.Business.Games.Common.BaseGame");

                    b.ToTable("StartedGames");
                });

            modelBuilder.Entity("GameProject.Domain.Models.Shared.UsersAbandonedGames", b =>
                {
                    b.HasOne("GameProject.Domain.Models.Business.Games.AbandonedGame", "AbandonedGame")
                        .WithMany("UsersAbandonedGames")
                        .HasForeignKey("AbandonedGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameProject.Identity.Models.ApplicationUser", "User")
                        .WithMany("UsersAbandonedGames")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AbandonedGame");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameProject.Domain.Models.Shared.UsersDesiredGames", b =>
                {
                    b.HasOne("GameProject.Domain.Models.Business.Games.DesiredGame", "DesiredGame")
                        .WithMany("UsersDesiredGames")
                        .HasForeignKey("DesiredGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameProject.Identity.Models.ApplicationUser", "User")
                        .WithMany("UsersDesiredGames")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DesiredGame");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameProject.Domain.Models.Shared.UsersFinishedGames", b =>
                {
                    b.HasOne("GameProject.Domain.Models.Business.Games.FinishedGame", "FinishedGame")
                        .WithMany("UsersFinishedGames")
                        .HasForeignKey("FinishedGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameProject.Identity.Models.ApplicationUser", "User")
                        .WithMany("UsersFinishedGames")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinishedGame");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameProject.Domain.Models.Shared.UsersInProgressGames", b =>
                {
                    b.HasOne("GameProject.Domain.Models.Business.Games.InProgressGame", "InProgressGame")
                        .WithMany("UsersInProgressGames")
                        .HasForeignKey("InProgressGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameProject.Identity.Models.ApplicationUser", "User")
                        .WithMany("UsersInProgressGames")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InProgressGame");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameProject.Domain.Models.Shared.UsersStartedGames", b =>
                {
                    b.HasOne("GameProject.Domain.Models.Business.Games.StartedGame", "StartedGame")
                        .WithMany("UsersStartedGames")
                        .HasForeignKey("StartedGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameProject.Identity.Models.ApplicationUser", "User")
                        .WithMany("UsersStartedGames")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StartedGame");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameProject.Identity.Models.ProfilePhoto", b =>
                {
                    b.HasOne("GameProject.Identity.Models.ApplicationUser", "User")
                        .WithOne("ProfilePhoto")
                        .HasForeignKey("GameProject.Identity.Models.ProfilePhoto", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("GameProject.Identity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("GameProject.Identity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameProject.Identity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("GameProject.Identity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameProject.Identity.Models.ApplicationUser", b =>
                {
                    b.Navigation("ProfilePhoto");

                    b.Navigation("UsersAbandonedGames");

                    b.Navigation("UsersDesiredGames");

                    b.Navigation("UsersFinishedGames");

                    b.Navigation("UsersInProgressGames");

                    b.Navigation("UsersStartedGames");
                });

            modelBuilder.Entity("GameProject.Domain.Models.Business.Games.AbandonedGame", b =>
                {
                    b.Navigation("UsersAbandonedGames");
                });

            modelBuilder.Entity("GameProject.Domain.Models.Business.Games.DesiredGame", b =>
                {
                    b.Navigation("UsersDesiredGames");
                });

            modelBuilder.Entity("GameProject.Domain.Models.Business.Games.FinishedGame", b =>
                {
                    b.Navigation("UsersFinishedGames");
                });

            modelBuilder.Entity("GameProject.Domain.Models.Business.Games.InProgressGame", b =>
                {
                    b.Navigation("UsersInProgressGames");
                });

            modelBuilder.Entity("GameProject.Domain.Models.Business.Games.StartedGame", b =>
                {
                    b.Navigation("UsersStartedGames");
                });
#pragma warning restore 612, 618
        }
    }
}
