﻿// <auto-generated />
using System;
using CoffeeMachine.DAL.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoffeeMachine.DAL.Migrations
{
    [DbContext(typeof(CoffeeMachineDbContext))]
    partial class CoffeeMachineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoffeeMachine.Models.Command", b =>
                {
                    b.Property<int>("CommandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommandIdentifier")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CommandTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("MoneyInserted")
                        .HasColumnType("real");

                    b.Property<float>("MoneyReturned")
                        .HasColumnType("real");

                    b.Property<int>("RequestedDrinkId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SugarQuantity")
                        .HasColumnType("int");

                    b.Property<bool?>("UseOwnMug")
                        .HasColumnType("bit");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommandId");

                    b.HasIndex("CommandIdentifier")
                        .IsUnique()
                        .HasFilter("[CommandIdentifier] IS NOT NULL");

                    b.HasIndex("RequestedDrinkId");

                    b.HasIndex("UserId");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("CoffeeMachine.Models.Drink", b =>
                {
                    b.Property<int>("DrinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ContainsSugar")
                        .HasColumnType("bit");

                    b.Property<string>("DrinkName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("DrinkId");

                    b.HasIndex("DrinkName")
                        .IsUnique()
                        .HasFilter("[DrinkName] IS NOT NULL");

                    b.ToTable("Drinks");

                    b.HasData(
                        new
                        {
                            DrinkId = 1,
                            ContainsSugar = true,
                            DrinkName = "Coffee",
                            Price = 0.25f
                        },
                        new
                        {
                            DrinkId = 2,
                            ContainsSugar = true,
                            DrinkName = "Tea",
                            Price = 0.75f
                        },
                        new
                        {
                            DrinkId = 3,
                            ContainsSugar = true,
                            DrinkName = "Choclate",
                            Price = 1f
                        });
                });

            modelBuilder.Entity("CoffeeMachine.Models.MachineUser", b =>
                {
                    b.Property<int>("MachineUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AccountCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identifier")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MachineUserId");

                    b.HasIndex("Identifier")
                        .IsUnique()
                        .HasFilter("[Identifier] IS NOT NULL");

                    b.ToTable("MachineUsers");

                    b.HasData(
                        new
                        {
                            MachineUserId = 1,
                            AccountCreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Identifier = "first-user"
                        });
                });

            modelBuilder.Entity("CoffeeMachine.Models.Command", b =>
                {
                    b.HasOne("CoffeeMachine.Models.Drink", "RequestedDrink")
                        .WithMany()
                        .HasForeignKey("RequestedDrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeeMachine.Models.MachineUser", "User")
                        .WithMany("Commands")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
