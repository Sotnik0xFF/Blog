using Microsoft.EntityFrameworkCore;

namespace Blog.Models.DB
{
    public sealed class BlogContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<UserPost> UserPosts => Set<UserPost>();
        public DbSet<Request> Requests => Set<Request>();
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
