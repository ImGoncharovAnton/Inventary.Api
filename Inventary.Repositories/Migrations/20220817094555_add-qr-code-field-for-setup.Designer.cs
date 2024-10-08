﻿// <auto-generated />
using System;
using Inventary.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Inventary.Repositories.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220817094555_add-qr-code-field-for-setup")]
    partial class addqrcodefieldforsetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Inventary.Domain.Entities.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("file_name");

                    b.Property<int>("FileSize")
                        .HasColumnType("integer")
                        .HasColumnName("file_size");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("file_type");

                    b.Property<string>("FileUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("file_url");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid")
                        .HasColumnName("item_id");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.HasKey("Id")
                        .HasName("pk_attachments");

                    b.HasIndex("ItemId")
                        .HasDatabaseName("ix_attachments_item_id");

                    b.ToTable("attachments", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("category_name");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CommentDescription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("comment_description");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsEdit")
                        .HasColumnType("boolean")
                        .HasColumnName("is_edit");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid")
                        .HasColumnName("item_id");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<DateTime>("UserDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("user_date");

                    b.HasKey("Id")
                        .HasName("pk_comments");

                    b.HasIndex("ItemId")
                        .HasDatabaseName("ix_comments_item_id");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Defect", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("DefectDescription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("defect_description");

                    b.Property<string>("DefectName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("defect_name");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid")
                        .HasColumnName("item_id");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.HasKey("Id")
                        .HasName("pk_defects");

                    b.HasIndex("ItemId")
                        .HasDatabaseName("ix_defects_item_id");

                    b.ToTable("defects", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.DefectPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<Guid>("DefectId")
                        .HasColumnType("uuid")
                        .HasColumnName("defect_id");

                    b.Property<string>("OrigUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("orig_url");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.HasKey("Id")
                        .HasName("pk_defect_photos");

                    b.HasIndex("DefectId")
                        .HasDatabaseName("ix_defect_photos_defect_id");

                    b.ToTable("defect_photos", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<Guid?>("CurrentCategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("current_category_id");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("item_name");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<string>("QRcode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("q_rcode");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uuid")
                        .HasColumnName("room_id");

                    b.Property<Guid?>("SetupId")
                        .HasColumnType("uuid")
                        .HasColumnName("setup_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<DateTime>("UserDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("user_date");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_items");

                    b.HasIndex("CurrentCategoryId")
                        .HasDatabaseName("ix_items_current_category_id");

                    b.HasIndex("RoomId")
                        .HasDatabaseName("ix_items_room_id");

                    b.HasIndex("SetupId")
                        .HasDatabaseName("ix_items_setup_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_items_user_id");

                    b.ToTable("items", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.ItemPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid")
                        .HasColumnName("item_id");

                    b.Property<string>("OrigUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("orig_url");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.HasKey("Id")
                        .HasName("pk_item_photos");

                    b.HasIndex("ItemId")
                        .HasDatabaseName("ix_item_photos_item_id");

                    b.ToTable("item_photos", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("room_name");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.HasKey("Id")
                        .HasName("pk_rooms");

                    b.ToTable("rooms", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Setup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("QrCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("qr_code");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uuid")
                        .HasColumnName("room_id");

                    b.Property<string>("SetupName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("setup_name");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_setups");

                    b.HasIndex("RoomId")
                        .HasDatabaseName("ix_setups_room_id");

                    b.ToTable("setups", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<Guid?>("CurrentSetupId")
                        .HasColumnType("uuid")
                        .HasColumnName("current_setup_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<string>("urlCrop")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url_crop");

                    b.Property<string>("urlOrig")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url_orig");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("CurrentSetupId")
                        .IsUnique()
                        .HasDatabaseName("ix_users_current_setup_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Attachment", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Item", "Item")
                        .WithMany("Attachments")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_attachments_items_item_id");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Comment", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Item", null)
                        .WithMany("Comments")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_comments_items_item_id");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Defect", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Item", null)
                        .WithMany("Defects")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_defects_items_item_id");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.DefectPhoto", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Defect", "Defect")
                        .WithMany("DefectPhotos")
                        .HasForeignKey("DefectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_defect_photos_defects_defect_id");

                    b.Navigation("Defect");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Item", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CurrentCategoryId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_items_categories_category_id");

                    b.HasOne("Inventary.Domain.Entities.Room", "Room")
                        .WithMany("Items")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("fk_items_rooms_room_id");

                    b.HasOne("Inventary.Domain.Entities.Setup", "Setup")
                        .WithMany("Items")
                        .HasForeignKey("SetupId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_items_setups_setup_id");

                    b.HasOne("Inventary.Domain.Entities.User", null)
                        .WithMany("Items")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_items_users_user_id");

                    b.Navigation("Category");

                    b.Navigation("Room");

                    b.Navigation("Setup");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.ItemPhoto", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Item", "Item")
                        .WithMany("ItemPhotos")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_item_photos_items_item_id");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.Setup", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Room", null)
                        .WithMany("Setups")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("fk_setups_rooms_room_id");
                });

            modelBuilder.Entity("Inventary.Domain.Entities.User", b =>
                {
                    b.HasOne("Inventary.Domain.Entities.Setup", "Setup")
                        .WithOne("User")
                        .HasForeignKey("Inventary.Domain.Entities.User", "CurrentSetupId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_users_setups_current_setup_id");

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

                    b.Navigation("Setups");
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
