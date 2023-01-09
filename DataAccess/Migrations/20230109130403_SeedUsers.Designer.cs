﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20230109130403_SeedUsers")]
    partial class SeedUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            Name = "SuperAdmin"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            Name = "PowerUser"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            Name = "RegularUser"
                        });
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nickname")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            BirthDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2023, 1, 9, 15, 4, 2, 872, DateTimeKind.Local).AddTicks(7604),
                            Email = "admin@email.com",
                            IsActive = true,
                            Nickname = "Super Admin",
                            PasswordHash = new byte[] { 38, 193, 252, 145, 238, 40, 69, 186, 117, 153, 128, 19, 179, 253, 59, 90, 247, 64, 1, 213, 194, 147, 157, 24, 132, 105, 205, 97, 254, 255, 180, 20, 110, 4, 24, 191, 94, 104, 181, 16, 110, 29, 242, 193, 26, 143, 77, 114, 153, 65, 120, 205, 18, 204, 84, 11, 255, 54, 205, 254, 40, 43, 77, 236 },
                            PasswordSalt = new byte[] { 54, 42, 212, 167, 13, 67, 124, 231, 135, 199, 225, 163, 171, 25, 230, 168, 191, 160, 225, 185, 63, 231, 0, 171, 204, 138, 86, 94, 181, 164, 70, 43, 98, 234, 253, 94, 242, 144, 220, 41, 186, 80, 38, 91, 1, 215, 163, 166, 46, 123, 236, 13, 137, 173, 148, 127, 134, 134, 56, 214, 71, 141, 189, 170, 75, 201, 49, 211, 24, 188, 94, 212, 127, 120, 55, 81, 79, 24, 13, 125, 242, 154, 28, 36, 105, 11, 195, 204, 90, 129, 191, 201, 81, 170, 226, 36, 87, 9, 7, 160, 170, 133, 239, 171, 201, 2, 193, 131, 215, 244, 0, 25, 205, 238, 239, 112, 17, 204, 9, 181, 115, 54, 82, 65, 183, 193, 190, 123 },
                            RoleId = new Guid("00000000-0000-0000-0000-000000000001")
                        });
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.HasOne("Core.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Core.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}