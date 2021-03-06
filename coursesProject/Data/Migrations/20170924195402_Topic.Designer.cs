﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using coursesProject.Data;

namespace coursesProject.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170924195402_Topic")]
    partial class Topic
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("coursesProject.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("coursesProject.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("coursesProject.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorEmail");

                    b.Property<int?>("AuthorID");

                    b.Property<string>("Context");

                    b.Property<DateTime>("DateCreate");

                    b.Property<int>("ProjectID");

                    b.HasKey("Id");

                    b.HasIndex("AuthorID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("coursesProject.Models.Goal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NeedMoney");

                    b.Property<int>("ProjectID");

                    b.Property<string>("Text");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Goal");
                });

            modelBuilder.Entity("coursesProject.Models.Medal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MedalRelationID");

                    b.Property<string>("Text");

                    b.HasKey("ID");

                    b.HasIndex("MedalRelationID");

                    b.ToTable("Medal");
                });

            modelBuilder.Entity("coursesProject.Models.MedalRelation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("MedalRelation");
                });

            modelBuilder.Entity("coursesProject.Models.New", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectID");

                    b.Property<string>("Text");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("coursesProject.Models.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AthorEmail");

                    b.Property<int>("AthorID");

                    b.Property<byte[]>("Avatar");

                    b.Property<string>("Category");

                    b.Property<int>("CollectMoney");

                    b.Property<DateTime>("DateOfRigister");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("NameProject");

                    b.Property<int>("NeedMoney");

                    b.Property<double>("Raiting");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Status");

                    b.HasKey("ID");

                    b.HasIndex("AthorID");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("coursesProject.Models.Rating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProjectID");

                    b.Property<int?>("UserID");

                    b.Property<int>("rating");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("UserID");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("coursesProject.Models.Statistic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DonateCount");

                    b.Property<int>("MoneyDonate");

                    b.Property<int>("SuccesProject");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Statistic");
                });

            modelBuilder.Entity("coursesProject.Models.Subscriber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectID");

                    b.Property<int?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("UserID");

                    b.ToTable("Subscriber");
                });

            modelBuilder.Entity("coursesProject.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("ProjectID");

                    b.HasKey("Id");

                    b.HasIndex("ProjectID");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("coursesProject.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Avatar");

                    b.Property<string>("CommentForVerified");

                    b.Property<string>("Email");

                    b.Property<string>("IdentityUserId")
                        .IsRequired();

                    b.Property<bool>("IsBan");

                    b.Property<DateTime>("LastLoginDate");

                    b.Property<byte[]>("PasportScan");

                    b.Property<string>("PersonalInfoForVerified");

                    b.Property<int>("ProjectCount");

                    b.Property<int>("Rating");

                    b.Property<string>("Region");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("Status");

                    b.HasKey("ID");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("coursesProject.Models.Comment", b =>
                {
                    b.HasOne("coursesProject.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID");

                    b.HasOne("coursesProject.Models.Project", "Project")
                        .WithMany("Comment")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coursesProject.Models.Goal", b =>
                {
                    b.HasOne("coursesProject.Models.Project", "Project")
                        .WithMany("Goals")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coursesProject.Models.Medal", b =>
                {
                    b.HasOne("coursesProject.Models.MedalRelation")
                        .WithMany("Medals")
                        .HasForeignKey("MedalRelationID");
                });

            modelBuilder.Entity("coursesProject.Models.MedalRelation", b =>
                {
                    b.HasOne("coursesProject.Models.User", "User")
                        .WithMany("Medal")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("coursesProject.Models.New", b =>
                {
                    b.HasOne("coursesProject.Models.Project", "Project")
                        .WithMany("News")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coursesProject.Models.Project", b =>
                {
                    b.HasOne("coursesProject.Models.User", "Athor")
                        .WithMany()
                        .HasForeignKey("AthorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coursesProject.Models.Rating", b =>
                {
                    b.HasOne("coursesProject.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID");

                    b.HasOne("coursesProject.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("coursesProject.Models.Statistic", b =>
                {
                    b.HasOne("coursesProject.Models.User", "User")
                        .WithMany("Stats")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coursesProject.Models.Subscriber", b =>
                {
                    b.HasOne("coursesProject.Models.Project", "Project")
                        .WithMany("Subscriber")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("coursesProject.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("coursesProject.Models.Tag", b =>
                {
                    b.HasOne("coursesProject.Models.Project", "Project")
                        .WithMany("Tags")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coursesProject.Models.User", b =>
                {
                    b.HasOne("coursesProject.Models.ApplicationUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("coursesProject.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("coursesProject.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("coursesProject.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
