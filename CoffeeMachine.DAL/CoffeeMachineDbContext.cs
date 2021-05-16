using CoffeeMachine.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMachine.DAL.Implementations
{
    public class CoffeeMachineDbContext : DbContext
    {
        public CoffeeMachineDbContext()
        {

        }
        public CoffeeMachineDbContext(DbContextOptions<CoffeeMachineDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>().ToTable("Drinks")
                .Property(d => d.DrinkId).UseIdentityColumn();
            modelBuilder.Entity<Drink>().ToTable("Drinks")
                .HasIndex(d => d.DrinkName).IsUnique();
            modelBuilder.Entity<MachineUser>().ToTable("MachineUsers")
                .Property(u => u.MachineUserId).UseIdentityColumn();
            modelBuilder.Entity<MachineUser>().ToTable("MachineUsers")
                .HasIndex(u => u.Identifier).IsUnique();
            modelBuilder.Entity<Command>().ToTable("Commands")
                .HasIndex(c => c.CommandIdentifier).IsUnique();

            modelBuilder.Entity<Command>()
            .HasOne(c => c.User)
            .WithMany(cm => cm.Commands);

            modelBuilder.Entity<Drink>().HasData(
                new Drink
                {
                    DrinkId = 1,
                    DrinkName = "Coffee",
                    ContainsSugar = true,
                    Price = 0.25f
                },
                new Drink
                {
                    DrinkId = 2,
                    DrinkName = "Tea",
                    ContainsSugar = true,
                    Price = 0.75f
                }, new Drink
                {
                    DrinkId = 3,
                    DrinkName = "Choclate",
                    ContainsSugar = true,
                    Price = 1f
                }
                );

            modelBuilder.Entity<MachineUser>().HasData(
                new MachineUser()
                {
                    MachineUserId = 1,
                    Identifier = "first-user"
                }
                );

        }

        public virtual DbSet<MachineUser> MachineUsers { get; set; }
        public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<Command> Commands { get; set; }
    }

}
