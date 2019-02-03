using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaAds.Core.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Type = MediaAds.Core.Models.Type;

namespace MediaAds.Infrastructure.Data
{
    public class MediaDbContextSeed
    {
        public static async Task SeedAsync(MediaDbContext context)
        {
            if (!context.Platforms.Any())
            {
                context.Platforms.AddRange(GetPlatforms());
                await context.SaveChangesAsync();
            }

            if (!context.Types.Any())
            {
                context.Types.AddRange(GetTypes());
                await context.SaveChangesAsync();
            }

            if (!context.Channels.Any())
            {
                context.Channels.AddRange(GetChannels());
                await context.SaveChangesAsync();
            }
        }

        static IEnumerable<Platform> GetPlatforms()
        {
            return new List<Platform>
            {
                new Platform {Name = "Test", Description = "Test", Users = 100}
            };
        }

        static IEnumerable<Type> GetTypes()
        {
            return new List<Type>
            {
                new Type {Name = "Test"}
            };
        }

        static IEnumerable<Channel> GetChannels()
        {
            return new List<Channel>
            {
                new Channel { Name = "Test", Views = 100, Subscribers = 100, PlatformId = 1, TypeId = 1 }
            };
        }
    }
}
