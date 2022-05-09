using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PerfectSite.Data.Manufacturers.CPUManufacturers;
using PerfectSite.Data.Manufacturers.GPUManufacturers;
using PerfectSite.Data.Manufacturers.HDDManufacturers;
using PerfectSite.Data.Manufacturers.MotherboardManufacturers;
using PerfectSite.Data.Manufacturers.PhoneManufacturers;
using PerfectSite.Data.Manufacturers.PowerSupplyManufacturers;
using PerfectSite.Data.Manufacturers.RAMManufacturer;
using PerfectSite.Data.Manufacturers.SSDManufacturers;
using PerfectSite.Data.ManufacturersComputerFrameManufacturers;
using PerfectSite.Data.ManufacturersComputerManufacturers;
using PerfectSite.Data.Products;
using PerfectSite.Models;

namespace PerfectSite
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CPUManufacturer> CPUManufacturers { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneManufacturer> PhoneManufacturers { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<ComputerManufacturer> ComputerManufacturers { get; set; }
        public DbSet<ComputerFrame> ComputerFrames { get; set; }
        public DbSet<ComputerFrameManufacturer> ComputerFrameManufacturers { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<GPUManufacturer> GPUManufacturers { get; set; }
        public DbSet<HDD> HDDs { get; set; }
        public DbSet<HDDManufacturer> HDDManufacturers { get; set; }
        public DbSet<SSD> SSDs { get; set; }
        public DbSet<SSDManufacturer> SSDManufacturers { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<MotherboardManufacturer> MotherboardManufacturers { get; set; }
        public DbSet<PowerSupply> PowerSupplies { get; set; }
        public DbSet<PowerSupplyManufacturer> PowerSupplyManufacturers { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        public DbSet<RAMManufacturer> RAMManufacturers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CPU>().HasOne(cpu => cpu.Manufacturer).WithMany(c => c.Products).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<CPU>().Property(p => p.ModelName).HasDefaultValue("Unknown");
            modelBuilder.Entity<Phone>().Property(p => p.ModelName).HasDefaultValue("Unknown");
            modelBuilder.Entity<Computer>().Property(p => p.ModelName).HasDefaultValue("Unknown");
            modelBuilder.Entity<ComputerFrame>().Property(p => p.ModelName).HasDefaultValue("Unknown");
            modelBuilder.Entity<CPU>().Property(p => p.ModelName).HasDefaultValue("Unknown");
            modelBuilder.Entity<GPU>().Property(p => p.ModelName).HasDefaultValue("Unknown");
            modelBuilder.Entity<HDD>().Property(p => p.ModelName).HasDefaultValue("Unknown");
            modelBuilder.Entity<SSD>().Property(p => p.ModelName).HasDefaultValue("Unknown");
            modelBuilder.Entity<Motherboard>().Property(p => p.ModelName).HasDefaultValue("Unknown");
            modelBuilder.Entity<PowerSupply>().Property(p => p.ModelName).HasDefaultValue("Unknown");
            modelBuilder.Entity<RAM>().Property(p => p.ModelName).HasDefaultValue("Unknown");
            modelBuilder.Entity<CPU>().Property(p => p.Amount).HasDefaultValue(0);
            modelBuilder.Entity<Phone>().Property(p => p.Amount).HasDefaultValue(0);
            modelBuilder.Entity<Computer>().Property(p => p.Amount).HasDefaultValue(0);
            modelBuilder.Entity<ComputerFrame>().Property(p => p.Amount).HasDefaultValue(0);
            modelBuilder.Entity<CPU>().Property(p => p.Amount).HasDefaultValue(0);
            modelBuilder.Entity<GPU>().Property(p => p.Amount).HasDefaultValue(0);
            modelBuilder.Entity<HDD>().Property(p => p.Amount).HasDefaultValue(0);
            modelBuilder.Entity<SSD>().Property(p => p.Amount).HasDefaultValue(0);
            modelBuilder.Entity<Motherboard>().Property(p => p.Amount).HasDefaultValue(0);
            modelBuilder.Entity<PowerSupply>().Property(p => p.Amount).HasDefaultValue(0);
            modelBuilder.Entity<RAM>().Property(p => p.Amount).HasDefaultValue(0);
            modelBuilder.Entity<Order>().Property(p => p.Quantity).HasDefaultValue(1);
        }
    }
}