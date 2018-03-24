using Microsoft.EntityFrameworkCore;
using B_MALL.Core.Models;
namespace B_MALL.EntityFramework
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
             
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User").HasKey(c => new {c.Id});
        }

    }
}