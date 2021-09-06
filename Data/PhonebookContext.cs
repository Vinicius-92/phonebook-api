using Microsoft.EntityFrameworkCore;
using PhonebookAPI.Models;

namespace PhonebookAPI.Data
{
    public class PhonebookContext : DbContext
    {
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Phones)
                .WithOne(p => p.Person);
        }
        public PhonebookContext(DbContextOptions<PhonebookContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<PhoneNumber> Phones { get; set; }

    }
}