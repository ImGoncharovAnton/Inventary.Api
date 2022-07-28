﻿// <auto-generated />
using System;
using Inventary.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventary.Repositories.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Inventary.Domain.Entities.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileSize")
                        .HasColumnType("int");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Attachments", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommentDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Defect", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DefectDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Defects", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.DefectPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DefectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OrigUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DefectId");

                    b.ToTable("DefectPhotos", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CurrentCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("QRcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SetupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UserDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CurrentCategoryId");

                    b.HasIndex("RoomId");

                    b.HasIndex("SetupId");

                    b.HasIndex("UserId");

                    b.ToTable("Items", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.ItemPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OrigUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemPhotos", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Rooms", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Setup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SetupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Setups", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CurrentSetupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("urlCrop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("urlOrig")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentSetupId")
                        .IsUnique()
                        .HasFilter("[CurrentSetupId] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Attachment", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Item", "Item")
                        .WithMany("Attachments")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Comment", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Item", null)
                        .WithMany("Comments")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Defect", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Item", null)
                        .WithMany("Defects")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Inventary.Domain.Entities.DefectPhoto", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Defect", "Defect")
                        .WithMany("DefectPhotos")
                        .HasForeignKey("DefectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Defect");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Item", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CurrentCategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Inventary.Domain.Entities.Room", null)
                        .WithMany("Items")
                        .HasForeignKey("RoomId");

                    b.HasOne("Inventary.Domain.Entities.Setup", "Setup")
                        .WithMany("Items")
                        .HasForeignKey("SetupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Inventary.Domain.Entities.User", null)
                        .WithMany("Items")
                        .HasForeignKey("UserId");

                    b.Navigation("Category");

                    b.Navigation("Setup");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.ItemPhoto", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Item", "Item")
                        .WithMany("ItemPhotos")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.User", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Setup", "Setup")
                        .WithOne("User")
                        .HasForeignKey("Inventary.Domain.Entities.User", "CurrentSetupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Setup");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Defect", b =>
                {
                    b.Navigation("DefectPhotos");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Item", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Comments");

                    b.Navigation("Defects");

                    b.Navigation("ItemPhotos");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Room", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Setup", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.User", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
