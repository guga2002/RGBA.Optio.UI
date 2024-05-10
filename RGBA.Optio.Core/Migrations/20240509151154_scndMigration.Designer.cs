﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Optio.Core.Data;

#nullable disable

namespace RGBA.Optio.Core.Migrations
{
    [DbContext(typeof(OptioDB))]
    [Migration("20240509151154_scndMigration")]
    partial class scndMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Optio.Core.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("TransactionCategory")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Transaction_Category");

                    b.Property<long>("TransactionTypeID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TransactionCategory")
                        .IsDescending();

                    b.HasIndex("TransactionTypeID");

                    b.ToTable("CategoryOfTransactions");
                });

            modelBuilder.Entity("Optio.Core.Entities.Channels", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ChannelType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Channel_Type");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ChannelType")
                        .IsDescending();

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("Optio.Core.Entities.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Location_Name");

                    b.HasKey("Id");

                    b.HasIndex("LocationName")
                        .IsDescending();

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Optio.Core.Entities.Merchant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsDescending();

                    b.ToTable("Merchants");
                });

            modelBuilder.Entity("Optio.Core.Entities.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Amount");

                    b.Property<decimal>("AmountEquivalent")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Amount_Equivalent");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("ChannelId")
                        .HasColumnType("bigint");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date_Of_Transaction");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("Transaction_Status");

                    b.Property<long>("MerchantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Amount")
                        .IsDescending();

                    b.HasIndex("AmountEquivalent")
                        .IsDescending();

                    b.HasIndex("CategoryId");

                    b.HasIndex("ChannelId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("Date")
                        .IsDescending();

                    b.HasIndex("MerchantId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Optio.Core.Entities.TypeOfTransaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("Status_Of_Transaction_Type");

                    b.Property<string>("TransactionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Transaction_Name");

                    b.HasKey("Id");

                    b.HasIndex("TransactionName")
                        .IsDescending();

                    b.ToTable("TypeOfTransactions");
                });

            modelBuilder.Entity("RGBA.Optio.Core.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Currency_Code");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("Status_Of_Currency");

                    b.Property<string>("NameOfValute")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Name_Of_Valute");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyCode")
                        .IsDescending();

                    b.HasIndex("NameOfValute")
                        .IsDescending();

                    b.ToTable("Curencies");
                });

            modelBuilder.Entity("RGBA.Optio.Core.Entities.LocationToMerchant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("LocatrionId")
                        .HasColumnType("bigint");

                    b.Property<long>("merchantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LocatrionId");

                    b.HasIndex("merchantId");

                    b.ToTable("LocationToMerchants");
                });

            modelBuilder.Entity("RGBA.Optio.Core.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("User_BirthDay");

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("User_Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("Personal_Number");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("User_Surname");

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

                    b.HasIndex("PersonalNumber")
                        .IsUnique()
                        .IsDescending();

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("RGBA.Optio.Core.Entities.ValuteCourse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("CurrencyID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfValuteCourse")
                        .HasColumnType("datetime2")
                        .HasColumnName("Last_Updated");

                    b.Property<decimal>("ExchangeRate")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Exchange_Rate");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("Status_Of_Valute");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyID");

                    b.HasIndex("DateOfValuteCourse")
                        .IsDescending();

                    b.HasIndex("ExchangeRate")
                        .IsDescending();

                    b.ToTable("ValutesCourses");
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
                    b.HasOne("RGBA.Optio.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RGBA.Optio.Core.Entities.User", null)
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

                    b.HasOne("RGBA.Optio.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RGBA.Optio.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Optio.Core.Entities.Category", b =>
                {
                    b.HasOne("Optio.Core.Entities.TypeOfTransaction", "typeOfTransaction")
                        .WithMany("Category")
                        .HasForeignKey("TransactionTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("typeOfTransaction");
                });

            modelBuilder.Entity("Optio.Core.Entities.Transaction", b =>
                {
                    b.HasOne("Optio.Core.Entities.Category", "Category")
                        .WithMany("Transactions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Optio.Core.Entities.Channels", "Channel")
                        .WithMany("Transactions")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RGBA.Optio.Core.Entities.Currency", "Currency")
                        .WithMany("Transactions")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Optio.Core.Entities.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Channel");

                    b.Navigation("Currency");

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("RGBA.Optio.Core.Entities.LocationToMerchant", b =>
                {
                    b.HasOne("Optio.Core.Entities.Location", "location")
                        .WithMany("Merchants")
                        .HasForeignKey("LocatrionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Optio.Core.Entities.Merchant", "merchant")
                        .WithMany("Locations")
                        .HasForeignKey("merchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("location");

                    b.Navigation("merchant");
                });

            modelBuilder.Entity("RGBA.Optio.Core.Entities.ValuteCourse", b =>
                {
                    b.HasOne("RGBA.Optio.Core.Entities.Currency", "Currency")
                        .WithMany("Courses")
                        .HasForeignKey("CurrencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Optio.Core.Entities.Category", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Optio.Core.Entities.Channels", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Optio.Core.Entities.Location", b =>
                {
                    b.Navigation("Merchants");
                });

            modelBuilder.Entity("Optio.Core.Entities.Merchant", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("Optio.Core.Entities.TypeOfTransaction", b =>
                {
                    b.Navigation("Category");
                });

            modelBuilder.Entity("RGBA.Optio.Core.Entities.Currency", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
