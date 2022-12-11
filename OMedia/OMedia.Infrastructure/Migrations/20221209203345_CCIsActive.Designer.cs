﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OMedia.Infrastructure.Data;

#nullable disable

namespace OMedia.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221209203345_CCIsActive")]
    partial class CCIsActive
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a7d5245a-41fc-48ed-ac60-362242b11423",
                            Email = "agent@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "agent@mail.com",
                            NormalizedUserName = "agent@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEOLXCewcXsvaTIWJV7rvyrd7frue/DbLX55wfujjNGJbYE5db2hshv/sN3loLUSEtQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "00466ee4-9809-4401-9bbc-f5ed0da00cf3",
                            TwoFactorEnabled = false,
                            UserName = "agent@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d3ace41b-75dd-46b9-a4cf-ef890f7913db",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@mail.com",
                            NormalizedUserName = "guest@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEP/lXbI8tGkMQRT941MTKCRBFQJKGKGw0hMXPDTmROG/j6LwXsdRoCJ7xsGYnemu9w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6164a7e9-e183-4d33-9efd-bcabf99c50de",
                            TwoFactorEnabled = false,
                            UserName = "guest@mail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.AgeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AgeGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 10,
                            Gender = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Age = 12,
                            Gender = "Male"
                        },
                        new
                        {
                            Id = 3,
                            Age = 14,
                            Gender = "Male"
                        },
                        new
                        {
                            Id = 4,
                            Age = 16,
                            Gender = "Male"
                        },
                        new
                        {
                            Id = 5,
                            Age = 18,
                            Gender = "Male"
                        },
                        new
                        {
                            Id = 24,
                            Age = 21,
                            Gender = "Male"
                        },
                        new
                        {
                            Id = 6,
                            Age = 35,
                            Gender = "Male"
                        },
                        new
                        {
                            Id = 7,
                            Age = 45,
                            Gender = "Male"
                        },
                        new
                        {
                            Id = 8,
                            Age = 55,
                            Gender = "Male"
                        },
                        new
                        {
                            Id = 9,
                            Age = 60,
                            Gender = "Male"
                        },
                        new
                        {
                            Id = 10,
                            Age = 65,
                            Gender = "Male"
                        },
                        new
                        {
                            Id = 11,
                            Age = 70,
                            Gender = "Male"
                        },
                        new
                        {
                            Id = 12,
                            Age = 10,
                            Gender = "Female"
                        },
                        new
                        {
                            Id = 13,
                            Age = 12,
                            Gender = "Female"
                        },
                        new
                        {
                            Id = 14,
                            Age = 14,
                            Gender = "Female"
                        },
                        new
                        {
                            Id = 15,
                            Age = 16,
                            Gender = "Female"
                        },
                        new
                        {
                            Id = 16,
                            Age = 18,
                            Gender = "Female"
                        },
                        new
                        {
                            Id = 17,
                            Age = 21,
                            Gender = "Female"
                        },
                        new
                        {
                            Id = 18,
                            Age = 35,
                            Gender = "Female"
                        },
                        new
                        {
                            Id = 19,
                            Age = 45,
                            Gender = "Female"
                        },
                        new
                        {
                            Id = 20,
                            Age = 55,
                            Gender = "Female"
                        },
                        new
                        {
                            Id = 21,
                            Age = 60,
                            Gender = "Female"
                        },
                        new
                        {
                            Id = 22,
                            Age = 65,
                            Gender = "Female"
                        },
                        new
                        {
                            Id = 23,
                            Age = 70,
                            Gender = "Female"
                        });
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.AgeGroupsCompetitions", b =>
                {
                    b.Property<int>("AgeGroupId")
                        .HasColumnType("int");

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.HasKey("AgeGroupId", "CompetitionId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("AgeGroupsCompetitions");
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsChanged")
                        .HasColumnType("bit");

                    b.Property<int?>("NewsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("NewsId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsChanged")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Competitions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2022, 12, 9, 22, 33, 43, 835, DateTimeKind.Local).AddTicks(5078),
                            Details = "Details Details Details Details Details Details Details Details Details Details Details Details Details Details Details Details Details Details ",
                            IsActive = false,
                            IsChanged = false,
                            Location = "CoolPlace",
                            Name = "CoolRace"
                        });
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.CompetitionsCompetitors", b =>
                {
                    b.Property<int>("CompetitorId")
                        .HasColumnType("int");

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompetitorId", "CompetitionId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("CompetitionsCompetitors");

                    b.HasData(
                        new
                        {
                            CompetitorId = 1,
                            CompetitionId = 1,
                            IsActive = true,
                            Role = "Participant"
                        });
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.Competitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgeGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AgeGroupId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("Competitors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgeGroupId = 1,
                            Name = "CoolName",
                            TeamId = 1,
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        });
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.DistanceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DistanceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeName = "Sprint"
                        },
                        new
                        {
                            Id = 2,
                            TypeName = "Middle"
                        },
                        new
                        {
                            Id = 3,
                            TypeName = "Long"
                        },
                        new
                        {
                            Id = 4,
                            TypeName = "Relay"
                        },
                        new
                        {
                            Id = 5,
                            TypeName = "Sky"
                        },
                        new
                        {
                            Id = 6,
                            TypeName = "O-Bike"
                        });
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsChanged")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("WriterId")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WriterId");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Content Content Content Content Content Content Content Content Content Content Content Content Content",
                            Date = new DateTime(2022, 12, 9, 22, 33, 43, 800, DateTimeKind.Local).AddTicks(67),
                            IsActive = false,
                            IsChanged = false,
                            Title = "Title",
                            WriterId = 1
                        });
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CoolTeam"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.AgeGroupsCompetitions", b =>
                {
                    b.HasOne("OMedia.Infrastructure.Data.AgeGroup", "AgeGroup")
                        .WithMany()
                        .HasForeignKey("AgeGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OMedia.Infrastructure.Data.Competition", "Competition")
                        .WithMany("AgeGroups")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgeGroup");

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.Comment", b =>
                {
                    b.HasOne("OMedia.Infrastructure.Data.Competitor", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OMedia.Infrastructure.Data.News", null)
                        .WithMany("Comments")
                        .HasForeignKey("NewsId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.CompetitionsCompetitors", b =>
                {
                    b.HasOne("OMedia.Infrastructure.Data.Competition", "Competition")
                        .WithMany("Competitors")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OMedia.Infrastructure.Data.Competitor", "Competitor")
                        .WithMany("Competitions")
                        .HasForeignKey("CompetitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("Competitor");
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.Competitor", b =>
                {
                    b.HasOne("OMedia.Infrastructure.Data.AgeGroup", "AgeGroup")
                        .WithMany()
                        .HasForeignKey("AgeGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OMedia.Infrastructure.Data.Team", "Team")
                        .WithMany("Competitors")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgeGroup");

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.News", b =>
                {
                    b.HasOne("OMedia.Infrastructure.Data.Competitor", "Writer")
                        .WithMany()
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.Competition", b =>
                {
                    b.Navigation("AgeGroups");

                    b.Navigation("Competitors");
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.Competitor", b =>
                {
                    b.Navigation("Competitions");
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.News", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("OMedia.Infrastructure.Data.Team", b =>
                {
                    b.Navigation("Competitors");
                });
#pragma warning restore 612, 618
        }
    }
}
