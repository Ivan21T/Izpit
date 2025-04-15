using Microsoft.EntityFrameworkCore;
using BusinessLayer;
using System.Collections.Generic;
namespace DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=DESKTOP-QCB7HDD;Database=Izpit_Test_Database;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Interest> Interests { get; set; }
    }
}