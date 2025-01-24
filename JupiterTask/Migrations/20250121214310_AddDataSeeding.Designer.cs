﻿// <auto-generated />
using JupiterTask.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JupiterTask.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20250121214310_AddDataSeeding")]
    partial class AddDataSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JupiterTask.Entites.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Web development competition",
                            ImageUrl = "https://example.com/web-image.jpg",
                            Name = "Web"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Flutter development competition",
                            ImageUrl = "https://example.com/flutter-image.jpg",
                            Name = "Flutter"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Sumo robot competition",
                            ImageUrl = "https://example.com/sumo-image.jpg",
                            Name = "Sumo"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Line follower robot competition",
                            ImageUrl = "https://example.com/linefollower-image.jpg",
                            Name = "LineFollower"
                        });
                });

            modelBuilder.Entity("JupiterTask.Entites.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Scores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TeamId = 1,
                            Value = 85
                        },
                        new
                        {
                            Id = 2,
                            TeamId = 2,
                            Value = 90
                        },
                        new
                        {
                            Id = 3,
                            TeamId = 3,
                            Value = 75
                        });
                });

            modelBuilder.Entity("JupiterTask.Entites.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Team Alpha"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Name = "Team Beta"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Name = "Team Gamma"
                        });
                });

            modelBuilder.Entity("JupiterTask.Entites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "johndoe@example.com",
                            FirstName = "John",
                            IsAdmin = false,
                            LastName = "Doe",
                            Password = "Password123",
                            PhoneNumber = "123456789"
                        },
                        new
                        {
                            Id = 2,
                            Email = "janedoe@example.com",
                            FirstName = "Jane",
                            IsAdmin = false,
                            LastName = "Doe",
                            Password = "Password456",
                            PhoneNumber = "987654321"
                        });
                });

            modelBuilder.Entity("JupiterTask.Entites.Score", b =>
                {
                    b.HasOne("JupiterTask.Entites.Team", "Team")
                        .WithMany("Scores")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("JupiterTask.Entites.Team", b =>
                {
                    b.HasOne("JupiterTask.Entites.Category", "Category")
                        .WithMany("Teams")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("JupiterTask.Entites.Category", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("JupiterTask.Entites.Team", b =>
                {
                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}