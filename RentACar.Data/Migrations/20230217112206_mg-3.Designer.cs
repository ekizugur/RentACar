﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentACar.Data.Context;

#nullable disable

namespace RentACar.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230217112206_mg-3")]
    partial class mg3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RentACar.Entity.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.HasData(
                        new
                        {
                            Id = new Guid("c98c470b-8494-45e0-8c5a-acd32784f9cc"),
                            ConcurrencyStamp = "29d8936b-e75c-4fd2-94ce-4d7419d6d9e2",
                            Name = "Superadmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = new Guid("39feab6c-464e-40dd-961b-2b3e5a382594"),
                            ConcurrencyStamp = "34276ba7-aafd-4ec1-a792-ccfd1c7013f7",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("c1cf57d5-3495-44ee-93db-b4be21c9d3e7"),
                            ConcurrencyStamp = "90cf02d5-ed1e-46ae-99a9-8650b216b5d8",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("RentACar.Entity.Entities.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("RentACar.Entity.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasIndex("ImageId");

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
                            Id = new Guid("36c170aa-3cb6-45dc-89e8-2b7f86758a19"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d759faf2-e36f-4c27-9a19-7f02cf61cd25",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Ahmet",
                            ImageId = new Guid("ce347ebf-815c-4a92-9bd4-12d5c50c378e"),
                            LastName = "Ekiz",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEA0miThFNtm3G1KBnhmq8VhQ6UtOZWGAUcnhUwiZvbRGrv5vIZ4aqtRWzhWUiXh1Zg==",
                            PhoneNumber = "+905555555555",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "73a145f9-fe2f-44a5-accc-75d19684ae8b",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("6286c136-92fa-4d66-b8d8-0b3ab4bbe33d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fe5f0d3d-4ee0-456d-b3a8-7a90de670fad",
                            Email = "superadmin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Uğur",
                            ImageId = new Guid("cfafabcd-8c44-408b-90a4-d9d892007780"),
                            LastName = "Ekiz",
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                            NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEIbKao1JRTBnm16xdyc2XfCiV9WHqrzTVSF+IX8fX+9CccOoBeo36Gr8zUr+8KzvNQ==",
                            PhoneNumber = "+905555555555",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "c5d09d4f-368b-45ce-a512-7302ae0c11c0",
                            TwoFactorEnabled = false,
                            UserName = "superadmin@gmail.com"
                        });
                });

            modelBuilder.Entity("RentACar.Entity.Entities.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("RentACar.Entity.Entities.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("RentACar.Entity.Entities.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("6286c136-92fa-4d66-b8d8-0b3ab4bbe33d"),
                            RoleId = new Guid("c98c470b-8494-45e0-8c5a-acd32784f9cc")
                        },
                        new
                        {
                            UserId = new Guid("36c170aa-3cb6-45dc-89e8-2b7f86758a19"),
                            RoleId = new Guid("39feab6c-464e-40dd-961b-2b3e5a382594")
                        });
                });

            modelBuilder.Entity("RentACar.Entity.Entities.AppUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RentACar.Entity.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("IsDeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("76f3368d-44f7-4377-ba91-b394b00737d4"),
                            CreatedBy = "Admin Deneme",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6261), new TimeSpan(0, 3, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "Mercedes"
                        },
                        new
                        {
                            Id = new Guid("e37eb9b9-181b-4ca4-ad97-646f2b9d338b"),
                            CreatedBy = "Admin Deneme",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6272), new TimeSpan(0, 3, 0, 0, 0)),
                            IsDeleted = false,
                            Name = "Audi"
                        });
                });

            modelBuilder.Entity("RentACar.Entity.Entities.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("IsDeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kilometer")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.Property<int>("RentCount")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6510a532-f18e-438b-84ff-44a465610235"),
                            BrandId = new Guid("76f3368d-44f7-4377-ba91-b394b00737d4"),
                            CategoryId = new Guid("eeabec77-1ef1-46e1-a5e9-3b0ceffbb6a4"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6496), new TimeSpan(0, 3, 0, 0, 0)),
                            Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                            FuelType = "Dizel",
                            IsDeleted = false,
                            Kilometer = 50545,
                            Model = "E250",
                            Price = 600.0,
                            ProductionYear = 2015,
                            RentCount = 10
                        },
                        new
                        {
                            Id = new Guid("15acb035-ce1d-40f2-b523-bade8c7c6fb9"),
                            BrandId = new Guid("e37eb9b9-181b-4ca4-ad97-646f2b9d338b"),
                            CategoryId = new Guid("8d0e6f75-280c-4b1b-a703-336ae28020ef"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6505), new TimeSpan(0, 3, 0, 0, 0)),
                            Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                            FuelType = "Benzin",
                            IsDeleted = false,
                            Kilometer = 62511,
                            Model = "A3",
                            Price = 850.0,
                            ProductionYear = 2018,
                            RentCount = 3
                        });
                });

            modelBuilder.Entity("RentACar.Entity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("IsDeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d0e6f75-280c-4b1b-a703-336ae28020ef"),
                            CategoryName = "Spor",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6627), new TimeSpan(0, 3, 0, 0, 0)),
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("eeabec77-1ef1-46e1-a5e9-3b0ceffbb6a4"),
                            CategoryName = "Sedan",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6632), new TimeSpan(0, 3, 0, 0, 0)),
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("RentACar.Entity.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("IsDeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("RentACar.Entity.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("IsDeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cfafabcd-8c44-408b-90a4-d9d892007780"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6732), new TimeSpan(0, 3, 0, 0, 0)),
                            FileName = "images/testimage",
                            FileType = "jpg",
                            ImageType = 0,
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("ce347ebf-815c-4a92-9bd4-12d5c50c378e"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 2, 17, 14, 22, 5, 873, DateTimeKind.Unspecified).AddTicks(6737), new TimeSpan(0, 3, 0, 0, 0)),
                            FileName = "images/vstest",
                            FileType = "png",
                            ImageType = 0,
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("RentACar.Entity.Entities.Rental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("IsDeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("RentACar.Entity.Entities.AppRoleClaim", b =>
                {
                    b.HasOne("RentACar.Entity.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentACar.Entity.Entities.AppUser", b =>
                {
                    b.HasOne("RentACar.Entity.Entities.Image", "Image")
                        .WithMany("Users")
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("RentACar.Entity.Entities.AppUserClaim", b =>
                {
                    b.HasOne("RentACar.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentACar.Entity.Entities.AppUserLogin", b =>
                {
                    b.HasOne("RentACar.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentACar.Entity.Entities.AppUserRole", b =>
                {
                    b.HasOne("RentACar.Entity.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentACar.Entity.Entities.AppUserToken", b =>
                {
                    b.HasOne("RentACar.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentACar.Entity.Entities.Car", b =>
                {
                    b.HasOne("RentACar.Entity.Entities.AppUser", null)
                        .WithMany("Cars")
                        .HasForeignKey("AppUserId");

                    b.HasOne("RentACar.Entity.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.Entity.Entities.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.Entity.Entities.Image", "Image")
                        .WithMany("Cars")
                        .HasForeignKey("ImageId");

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("RentACar.Entity.Entities.Comment", b =>
                {
                    b.HasOne("RentACar.Entity.Entities.Car", "Car")
                        .WithMany("Comments")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.Entity.Entities.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentACar.Entity.Entities.Rental", b =>
                {
                    b.HasOne("RentACar.Entity.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("RentACar.Entity.Entities.AppUser", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RentACar.Entity.Entities.Car", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("RentACar.Entity.Entities.Category", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RentACar.Entity.Entities.Image", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}