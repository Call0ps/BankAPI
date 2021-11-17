using Microsoft.EntityFrameworkCore;
using BankAPI.Models;
using System.Configuration;

namespace BankAPI.Database
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().Property(prop => prop.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired();
        }
    }
}
