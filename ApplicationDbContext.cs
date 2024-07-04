using BlogManagement.Models;
using System.Data.Entity;

    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        public DbSet<Blog> Blogs { get; set; }
    }