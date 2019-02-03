using MediaAds.Core.Models;
using Microsoft.EntityFrameworkCore;
using Type = MediaAds.Core.Models.Type;

namespace MediaAds.Infrastructure.Data
{
    public class MediaDbContext : DbContext
    {
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Type> Types { get; set; }

        public MediaDbContext(DbContextOptions options) : base(options)
        { }
    }
}
