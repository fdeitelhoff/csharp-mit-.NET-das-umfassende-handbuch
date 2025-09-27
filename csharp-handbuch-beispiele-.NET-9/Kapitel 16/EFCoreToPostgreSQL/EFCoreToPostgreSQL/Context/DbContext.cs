using EFCoreToPostgreSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreToPostgreSQL.Context
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=blogdb;Username=postgres;Password=root");
        }
    }
}
