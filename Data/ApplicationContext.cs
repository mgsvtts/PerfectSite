using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplication1
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<ComputerFrame> ComputerFrames { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<HDD> HDDs { get; set; }
        public DbSet<SSD> SSDs { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<PowerSupply> PowerSupplies { get; set; }
        public DbSet<RAM> RAMs { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Phone>().Property(p => p.Price).HasDefaultValue(0);
            modelBuilder.Entity<Computer>().Property(p => p.Price).HasDefaultValue(0);
            modelBuilder.Entity<ComputerFrame>().Property(p => p.Price).HasDefaultValue(0);
            modelBuilder.Entity<CPU>().Property(p => p.Price).HasDefaultValue(0);
            modelBuilder.Entity<GPU>().Property(p => p.Price).HasDefaultValue(0);
            modelBuilder.Entity<HDD>().Property(p => p.Price).HasDefaultValue(0);
            modelBuilder.Entity<SSD>().Property(p => p.Price).HasDefaultValue(0);
            modelBuilder.Entity<Motherboard>().Property(p => p.Price).HasDefaultValue(0);
            modelBuilder.Entity<PowerSupply>().Property(p => p.Price).HasDefaultValue(0);
            modelBuilder.Entity<RAM>().Property(p => p.Price).HasDefaultValue(0);

        }
    }
}
