using Microsoft.EntityFrameworkCore;
using BankAPI.Models;

namespace BankAPI.Database
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }

        public ApplicationDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
