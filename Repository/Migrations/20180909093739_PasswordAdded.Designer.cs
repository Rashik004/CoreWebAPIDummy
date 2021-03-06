﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Models;

namespace Repository.Migrations
{
    [DbContext(typeof(EnvironmentContext))]
    [Migration("20180909093739_PasswordAdded")]
    partial class PasswordAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repository.Models.Environment", b =>
                {
                    b.Property<int>("EnvironmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnvironmentName");

                    b.Property<int?>("UserId");

                    b.HasKey("EnvironmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Environments");
                });

            modelBuilder.Entity("Repository.Models.EnvironmentUser", b =>
                {
                    b.Property<int>("EnvironmentUserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnvironmentId");

                    b.Property<int>("UserId");

                    b.HasKey("EnvironmentUserId");

                    b.HasIndex("EnvironmentId");

                    b.HasIndex("UserId");

                    b.ToTable("EnvironmentUsers");
                });

            modelBuilder.Entity("Repository.Models.EnvironmentUsingStatus", b =>
                {
                    b.Property<int>("EnvironmentUsingStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnvironmentUsingStatusName");

                    b.HasKey("EnvironmentUsingStatusId");

                    b.ToTable("EnvironmentUsEnvironmentUsingStatuses");
                });

            modelBuilder.Entity("Repository.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mail");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Repository.Models.Environment", b =>
                {
                    b.HasOne("Repository.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Repository.Models.EnvironmentUser", b =>
                {
                    b.HasOne("Repository.Models.Environment", "Environment")
                        .WithMany()
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Repository.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
