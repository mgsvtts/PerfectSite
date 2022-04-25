using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Manufacturers.CPUManufacturers;
using WebApplication1.Data.Manufacturers.GPUManufacturers;
using WebApplication1.Data.Manufacturers.HDDManufacturers;
using WebApplication1.Data.Manufacturers.MotherboardManufacturers;
using WebApplication1.Data.Manufacturers.PhoneManufacturers;
using WebApplication1.Data.Manufacturers.PowerSupplyManufacturers;
using WebApplication1.Data.Manufacturers.RAMManufacturer;
using WebApplication1.Data.Manufacturers.SSDManufacturers;
using WebApplication1.Data.ManufacturersComputerFrameManufacturers;
using WebApplication1.Data.ManufacturersComputerManufacturers;
using WebApplication1.Data.Products;
using WebApplication1.Models;

namespace WebApplication1
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