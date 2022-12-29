﻿// <auto-generated />
using System;
using GCScript_Automate_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GCScript_Automate_API.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GCScript_Automate_API.Models.CategoryModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("Registered")
                        .HasPrecision(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Registered");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Code" }, "IX_Category_Code")
                        .IsUnique();

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("49e252cd-68c3-4a93-9672-c4f868411c13"),
                            Code = "acompanhamentos",
                            Name = "Acompanhamentos",
                            Registered = new DateTime(2022, 12, 29, 13, 19, 41, 748, DateTimeKind.Utc).AddTicks(2057)
                        },
                        new
                        {
                            Id = new Guid("bba09c0b-2e5f-427c-9fd9-08e363901334"),
                            Code = "compromissos",
                            Name = "Compromissos",
                            Registered = new DateTime(2022, 12, 29, 13, 19, 41, 748, DateTimeKind.Utc).AddTicks(2072)
                        });
                });

            modelBuilder.Entity("GCScript_Automate_API.Models.SubtypeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("Registered")
                        .HasPrecision(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Registered");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex(new[] { "Code", "TypeId" }, "IX_Subtype_Code_TypeId")
                        .IsUnique();

                    b.ToTable("Subtype", (string)null);
                });

            modelBuilder.Entity("GCScript_Automate_API.Models.TypeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)")
                        .HasColumnName("CategoryId");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("Registered")
                        .HasPrecision(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Registered");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex(new[] { "Code", "CategoryId" }, "IX_Type_Code_CategoryId")
                        .IsUnique();

                    b.ToTable("Type", (string)null);
                });

            modelBuilder.Entity("GCScript_Automate_API.Models.SubtypeModel", b =>
                {
                    b.HasOne("GCScript_Automate_API.Models.TypeModel", "Type")
                        .WithMany("Subtypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("GCScript_Automate_API.Models.TypeModel", b =>
                {
                    b.HasOne("GCScript_Automate_API.Models.CategoryModel", "Category")
                        .WithMany("Types")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GCScript_Automate_API.Models.CategoryModel", b =>
                {
                    b.Navigation("Types");
                });

            modelBuilder.Entity("GCScript_Automate_API.Models.TypeModel", b =>
                {
                    b.Navigation("Subtypes");
                });
#pragma warning restore 612, 618
        }
    }
}
