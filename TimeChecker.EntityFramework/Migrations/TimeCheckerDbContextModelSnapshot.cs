﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeChecker.EntityFramework;

namespace TimeChecker.EntityFramework.Migrations
{
    [DbContext(typeof(TimeCheckerDbContext))]
    partial class TimeCheckerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TimeChecker.Domain.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountUserID")
                        .HasColumnType("int");

                    b.Property<bool>("isCheckedIn")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("AccountUserID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("TimeChecker.Domain.Models.TimeEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountID");

                    b.ToTable("TimeEntries");
                });

            modelBuilder.Entity("TimeChecker.Domain.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TimeChecker.Domain.Models.Account", b =>
                {
                    b.HasOne("TimeChecker.Domain.Models.User", "AccountUser")
                        .WithMany()
                        .HasForeignKey("AccountUserID");

                    b.Navigation("AccountUser");
                });

            modelBuilder.Entity("TimeChecker.Domain.Models.TimeEntry", b =>
                {
                    b.HasOne("TimeChecker.Domain.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID");

                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
