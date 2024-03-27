﻿// <auto-generated />
using System;
using BudgetPlan.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BudgetPlan.Persistence.Migrations
{
    [DbContext(typeof(BudgetPlanDbContext))]
    partial class BudgetPlanDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BudgetPlan.Domain.Entities.Access", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Accesses");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.AccessedPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccessId");

                    b.ToTable("AccessedPersons");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.BudgetPlanBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BudgetPlanEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateFrom")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateTo")
                        .HasColumnType("date");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccessId");

                    b.HasIndex("BudgetPlanEntityId");

                    b.ToTable("BudgetPlanBases");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.BudgetPlanDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BudgetPlanBaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BudgetPlanType")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ExpectedAmount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<Guid?>("TransactionCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccessId");

                    b.HasIndex("BudgetPlanBaseId");

                    b.HasIndex("TransactionCategoryId");

                    b.ToTable("BudgetPlanDetails");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.BudgetPlanEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccessId");

                    b.ToTable("BudgetPlanEntities");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.TransactionCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OverTransactionCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccessId");

                    b.HasIndex("OverTransactionCategoryId");

                    b.ToTable("TransactionCategories");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.TransactionDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Inactivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("InactivatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<Guid>("TransactionCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AccessId");

                    b.HasIndex("TransactionCategoryId");

                    b.ToTable("TransactionDetails");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.AccessedPerson", b =>
                {
                    b.HasOne("BudgetPlan.Domain.Entities.Access", "Access")
                        .WithMany("AccessedPersons")
                        .HasForeignKey("AccessId");

                    b.Navigation("Access");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.BudgetPlanBase", b =>
                {
                    b.HasOne("BudgetPlan.Domain.Entities.Access", "Access")
                        .WithMany("BudgetPlanBases")
                        .HasForeignKey("AccessId");

                    b.HasOne("BudgetPlan.Domain.Entities.BudgetPlanEntity", "BudgetPlanEntity")
                        .WithMany("BudgetPlanBases")
                        .HasForeignKey("BudgetPlanEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Access");

                    b.Navigation("BudgetPlanEntity");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.BudgetPlanDetails", b =>
                {
                    b.HasOne("BudgetPlan.Domain.Entities.Access", "Access")
                        .WithMany("BudgetPlanDetails")
                        .HasForeignKey("AccessId");

                    b.HasOne("BudgetPlan.Domain.Entities.BudgetPlanBase", "BudgetPlanBase")
                        .WithMany("BudgetPlanDetailsList")
                        .HasForeignKey("BudgetPlanBaseId");

                    b.HasOne("BudgetPlan.Domain.Entities.TransactionCategory", "TransactionCategory")
                        .WithMany("BudgetPlanDetails")
                        .HasForeignKey("TransactionCategoryId");

                    b.Navigation("Access");

                    b.Navigation("BudgetPlanBase");

                    b.Navigation("TransactionCategory");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.BudgetPlanEntity", b =>
                {
                    b.HasOne("BudgetPlan.Domain.Entities.Access", "Access")
                        .WithMany("BudgetPlanEntities")
                        .HasForeignKey("AccessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Access");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.TransactionCategory", b =>
                {
                    b.HasOne("BudgetPlan.Domain.Entities.Access", "Access")
                        .WithMany("TransactionCategories")
                        .HasForeignKey("AccessId");

                    b.HasOne("BudgetPlan.Domain.Entities.TransactionCategory", "OverTransactionCategory")
                        .WithMany("SubTransactionCategories")
                        .HasForeignKey("OverTransactionCategoryId");

                    b.Navigation("Access");

                    b.Navigation("OverTransactionCategory");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.TransactionDetail", b =>
                {
                    b.HasOne("BudgetPlan.Domain.Entities.Access", "Access")
                        .WithMany("TransactionDetails")
                        .HasForeignKey("AccessId");

                    b.HasOne("BudgetPlan.Domain.Entities.TransactionCategory", "TransactionCategory")
                        .WithMany("TransactionDetails")
                        .HasForeignKey("TransactionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Access");

                    b.Navigation("TransactionCategory");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.Access", b =>
                {
                    b.Navigation("AccessedPersons");

                    b.Navigation("BudgetPlanBases");

                    b.Navigation("BudgetPlanDetails");

                    b.Navigation("BudgetPlanEntities");

                    b.Navigation("TransactionCategories");

                    b.Navigation("TransactionDetails");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.BudgetPlanBase", b =>
                {
                    b.Navigation("BudgetPlanDetailsList");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.BudgetPlanEntity", b =>
                {
                    b.Navigation("BudgetPlanBases");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.TransactionCategory", b =>
                {
                    b.Navigation("BudgetPlanDetails");

                    b.Navigation("SubTransactionCategories");

                    b.Navigation("TransactionDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
