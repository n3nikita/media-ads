using System;
using System.Collections.Generic;
using System.Text;
using MediaAds.Core.Database.Models;
using Microsoft.EntityFrameworkCore;
using Type = MediaAds.Core.Database.Models.Type;

namespace MediaAds.Core.Database
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
