﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Production.Reprository.Context;

#nullable disable

namespace Production.Reprository.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240605085446_alterPlanningTable")]
    partial class alterPlanningTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Production.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductPlanningId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductPlanningId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Production.Core.Entities.ProductPlanning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Approval")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductionOperationId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StopRecordsId")
                        .HasColumnType("int");

                    b.Property<int?>("TrackingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductionOperationId");

                    b.HasIndex("StopRecordsId");

                    b.HasIndex("TrackingId");

                    b.ToTable("Planning");
                });

            modelBuilder.Entity("Production.Core.Entities.ProductionOperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Approval")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductPlanningId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductPlanningId");

                    b.ToTable("Operation");
                });

            modelBuilder.Entity("Production.Core.Entities.StopRecords", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AffectedOperations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DownTimeDuration")
                        .HasColumnType("int");

                    b.Property<int?>("ProductPlanningId")
                        .HasColumnType("int");

                    b.Property<string>("StopReasons")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductPlanningId");

                    b.ToTable("StopRecords");
                });

            modelBuilder.Entity("Production.Core.Entities.Tracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductPlanningId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityProduced")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductPlanningId");

                    b.ToTable("Tracking");
                });

            modelBuilder.Entity("Production.Core.Entities.Product", b =>
                {
                    b.HasOne("Production.Core.Entities.ProductPlanning", null)
                        .WithMany("Products")
                        .HasForeignKey("ProductPlanningId");
                });

            modelBuilder.Entity("Production.Core.Entities.ProductPlanning", b =>
                {
                    b.HasOne("Production.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Production.Core.Entities.ProductionOperation", null)
                        .WithMany("ProductPlannings")
                        .HasForeignKey("ProductionOperationId");

                    b.HasOne("Production.Core.Entities.StopRecords", null)
                        .WithMany("ProductPlannings")
                        .HasForeignKey("StopRecordsId");

                    b.HasOne("Production.Core.Entities.Tracking", null)
                        .WithMany("ProductPlannings")
                        .HasForeignKey("TrackingId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Production.Core.Entities.ProductionOperation", b =>
                {
                    b.HasOne("Production.Core.Entities.ProductPlanning", "ProductPlanning")
                        .WithMany()
                        .HasForeignKey("ProductPlanningId");

                    b.Navigation("ProductPlanning");
                });

            modelBuilder.Entity("Production.Core.Entities.StopRecords", b =>
                {
                    b.HasOne("Production.Core.Entities.ProductPlanning", "ProductPlanning")
                        .WithMany()
                        .HasForeignKey("ProductPlanningId");

                    b.Navigation("ProductPlanning");
                });

            modelBuilder.Entity("Production.Core.Entities.Tracking", b =>
                {
                    b.HasOne("Production.Core.Entities.ProductPlanning", "ProductPlanning")
                        .WithMany()
                        .HasForeignKey("ProductPlanningId");

                    b.Navigation("ProductPlanning");
                });

            modelBuilder.Entity("Production.Core.Entities.ProductPlanning", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Production.Core.Entities.ProductionOperation", b =>
                {
                    b.Navigation("ProductPlannings");
                });

            modelBuilder.Entity("Production.Core.Entities.StopRecords", b =>
                {
                    b.Navigation("ProductPlannings");
                });

            modelBuilder.Entity("Production.Core.Entities.Tracking", b =>
                {
                    b.Navigation("ProductPlannings");
                });
#pragma warning restore 612, 618
        }
    }
}