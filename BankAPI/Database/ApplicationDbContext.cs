using Microsoft.EntityFrameworkCore;
using BankAPI.Models;

namespace BankAPI.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(accEnt =>
            {
                accEnt
                    .HasOne<User>(u => u.User).WithMany(u=>u.Accounts);
                accEnt
                    .HasKey(a => a.AccountId);
            });
            modelBuilder.Entity<User>(userEnt =>
            {
                userEnt
                    .HasKey(u => u.Id);
            });
        }
    }
}