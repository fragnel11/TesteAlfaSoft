using Microsoft.EntityFrameworkCore;
using TesteALFASOFT.Models;

namespace TesteALFASOFT.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        { }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contact>().HasKey(c => c.ID);
            modelBuilder.Entity<Contact>().Property(c => c.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Contact>().Property(c => c.ContactNumber).HasMaxLength(9).IsRequired();
            modelBuilder.Entity<Contact>().Property(c => c.EmailAddress).HasMaxLength(100).IsRequired();
        }
    }
}

