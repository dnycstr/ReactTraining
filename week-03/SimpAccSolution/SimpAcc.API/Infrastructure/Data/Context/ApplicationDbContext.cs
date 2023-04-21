using Microsoft.EntityFrameworkCore;
using SimpAcc.API.Infrastructure.Data.Configuration;
using SimpAcc.API.Domain.Models;

namespace SimpAcc.API.Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ContactModelConfiguration().Configure(modelBuilder.Entity<Contact>());
        }
    }
}
