using System;
using Microsoft.EntityFrameworkCore;
using TouristСenterLibrary.Entity;

namespace TouristСenterLibrary
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
        public DbSet<CheckpointRoute> CheckpointRoute { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<CountableEquipment> CountableEquipment { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Hike> Hike { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<InstructorGroup> InstructorGroup { get; set; }
        public DbSet<Participant> Participant { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<RouteHike> RouteHike { get; set; }
        public DbSet<Transport> Transport { get; set; }
        public DbSet<TransportCompany> TransportCompany { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            Database.Migrate();
            new ContextManager(this);
        }
        public static DbContextOptions<ApplicationContext> GetDb()
        {
            return new DbContextOptionsBuilder<ApplicationContext>().UseNpgsql("Host=localhost;Port=5432;Database=tourist_center;Username=postgres;Password=123").Options;
        }
        public static void InitDb()
        {
            new ApplicationContext(GetDb());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Port=5432;Database=tourist_center;Username=postgres;Password=123");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasIndex(s => s.EmployeeTelefonNumber).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(s => s.PassportData).IsUnique();
            modelBuilder.Entity<Instructor>().HasIndex(s => s.InstructorTelefonNumber).IsUnique();
            modelBuilder.Entity<Instructor>().HasIndex(s => s.PassportData).IsUnique();
            modelBuilder.Entity<Transport>().HasIndex(s => s.CarNumber).IsUnique();
            modelBuilder.Entity<TransportCompany>().HasIndex(s => s.CompanyTelefonNumber).IsUnique();

        }
    }

}
