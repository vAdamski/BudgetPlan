﻿// <auto-generated />
using System;
using BudgetPlan.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BudgetPlan.Persistence.Migrations
{
    [DbContext(typeof(BudgetPlanDbContext))]
    [Migration("20230805001551_AddedNewConnectionBetweenEntities")]
    partial class AddedNewConnectionBetweenEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BudgetPlan.Domain.Entities.BudgetPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

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

                    b.ToTable("BudgetPlans");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.BudgetPlanDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BudgetPlanId")
                        .HasColumnType("int");

                    b.Property<int>("BudgetPlanType")
                        .HasColumnType("int");

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

                    b.Property<int?>("TransactionCategoryId")
                        .HasColumnType("int");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BudgetPlanId");

                    b.HasIndex("TransactionCategoryId");

                    b.ToTable("BudgetPlanDetails");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.TransactionCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<int?>("OverTransactionCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OverTransactionCategoryId");

                    b.ToTable("TransactionCategories");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.TransactionDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BudgetPlanDetailsId")
                        .HasColumnType("int");

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

                    b.Property<int>("TransactionCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BudgetPlanDetailsId");

                    b.HasIndex("TransactionCategoryId");

                    b.ToTable("TransactionDetails");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.BudgetPlanDetails", b =>
                {
                    b.HasOne("BudgetPlan.Domain.Entities.BudgetPlan", "BudgetPlan")
                        .WithMany("BudgetPlanDetailsList")
                        .HasForeignKey("BudgetPlanId");

                    b.HasOne("BudgetPlan.Domain.Entities.TransactionCategory", "TransactionCategory")
                        .WithMany("BudgetPlanDetails")
                        .HasForeignKey("TransactionCategoryId");

                    b.Navigation("BudgetPlan");

                    b.Navigation("TransactionCategory");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.TransactionCategory", b =>
                {
                    b.HasOne("BudgetPlan.Domain.Entities.TransactionCategory", "OverTransactionCategory")
                        .WithMany()
                        .HasForeignKey("OverTransactionCategoryId");

                    b.Navigation("OverTransactionCategory");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.TransactionDetail", b =>
                {
                    b.HasOne("BudgetPlan.Domain.Entities.BudgetPlanDetails", "BudgetPlanDetails")
                        .WithMany("TransactionDetails")
                        .HasForeignKey("BudgetPlanDetailsId");

                    b.HasOne("BudgetPlan.Domain.Entities.TransactionCategory", "TransactionCategory")
                        .WithMany("TransactionDetails")
                        .HasForeignKey("TransactionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BudgetPlanDetails");

                    b.Navigation("TransactionCategory");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.BudgetPlan", b =>
                {
                    b.Navigation("BudgetPlanDetailsList");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.BudgetPlanDetails", b =>
                {
                    b.Navigation("TransactionDetails");
                });

            modelBuilder.Entity("BudgetPlan.Domain.Entities.TransactionCategory", b =>
                {
                    b.Navigation("BudgetPlanDetails");

                    b.Navigation("TransactionDetails");
                });
#pragma warning restore 612, 618
        }
    }
}