using System;
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
                .WithOne(p => p.Person)
                .HasForeignKey(x => x.PersonId);

        }
        public PhonebookContext(DbContextOptions<PhonebookContext> options) : base(options)
        {
        }

        protected PhonebookContext()
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public DbSet<PhoneNumber> Phones { get; set; }
        public DbContextOptions<PhonebookContext> Options { get; }
    }
}