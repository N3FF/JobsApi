﻿// <auto-generated />
using System;
using JobsApi.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobsApi.Migrations
{
    [DbContext(typeof(JobsContext))]
    partial class JobsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiLibrary.ImageUriDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("JobListingDTOId")
                        .HasColumnType("int");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobListingDTOId");

                    b.ToTable("ImageUris");
                });

            modelBuilder.Entity("ApiLibrary.JobListingDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Categories")
                        .HasColumnType("int");

                    b.Property<string>("ContactInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ListingDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("ListingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("JobListings");
                });

            modelBuilder.Entity("ApiLibrary.ImageUriDTO", b =>
                {
                    b.HasOne("ApiLibrary.JobListingDTO", null)
                        .WithMany("ImageUris")
                        .HasForeignKey("JobListingDTOId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApiLibrary.JobListingDTO", b =>
                {
                    b.Navigation("ImageUris");
                });
#pragma warning restore 612, 618
        }
    }
}
