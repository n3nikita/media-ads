﻿using MediaAds.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaAds.Infrastructure.Data
{
    public class MediaDbContext : DbContext
    {
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MediaDbContext(DbContextOptions options) : base(options)
        { }
    }
}
