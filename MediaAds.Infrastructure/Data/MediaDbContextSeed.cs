using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaAds.Core.Models;
using Microsoft.EntityFrameworkCore.Internal;

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

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(GetCategories());
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
                new Platform { Name = "Instagram", Users = 100 },
                new Platform { Name = "Telegram", Users = 200 },
                new Platform { Name = "VK", Users = 1300 },
                new Platform { Name = "YouTube", Users = 200 }
            };
        }

        static IEnumerable<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category {
                    Name = "Auto",
                    Icon = "https://cdn4.iconfinder.com/data/icons/car-silhouettes/1000/SUV-512.png"
                },
                new Category {
                    Name = "Music",
                    Icon = "https://cdn4.iconfinder.com/data/icons/car-silhouettes/1000/SUV-512.png"
                },
                new Category {
                    Name = "IT",
                    Icon = "https://cdn4.iconfinder.com/data/icons/car-silhouettes/1000/SUV-512.png"
                },
                new Category {
                    Name = "Business",
                    Icon = "https://cdn4.iconfinder.com/data/icons/car-silhouettes/1000/SUV-512.png"
                },
                new Category {
                    Name = "Education",
                    Icon = "https://cdn4.iconfinder.com/data/icons/car-silhouettes/1000/SUV-512.png"
                },
                new Category {
                    Name = "News",
                    Icon = "https://cdn4.iconfinder.com/data/icons/car-silhouettes/1000/SUV-512.png"
                },
            };
        }

        static IEnumerable<Channel> GetChannels()
        {
            return new List<Channel>
            {
                new Channel
                {
                    Name = "WebDEV",
                    Views = 10900,
                    Subscribers = 15000,
                    PlatformId = 2,
                    CategoryId = 3,
                    Link = "@webb_dev",
                    Image = "https://images.pexels.com/photos/160107/pexels-photo-160107.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
                },
                new Channel
                {
                    Name = "GameDEV",
                    Views = 1500,
                    Subscribers = 1600,
                    PlatformId = 2,
                    CategoryId = 3,
                    Link = "@gamee_dev",
                    Image = "https://images.pexels.com/photos/160107/pexels-photo-160107.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
                },
                new Channel
                {
                    Name = "Говнокод",
                    Views = 20000,
                    Subscribers = 16100,
                    PlatformId = 2,
                    CategoryId = 5,
                    Link = "@g_code",
                    Image = "https://images.pexels.com/photos/160107/pexels-photo-160107.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
                },
                new Channel
                {
                    Name = "Developers Club",
                    Views = 1000,
                    Subscribers = 2000,
                    PlatformId = 2,
                    CategoryId = 3,
                    Link = "@programmers_live",
                    Image = "https://images.pexels.com/photos/160107/pexels-photo-160107.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
                },
                new Channel
                {
                    Name = "Code Blog",
                    Views = 7000,
                    Subscribers = 9000,
                    PlatformId = 2,
                    CategoryId = 5,
                    Link = "@codeblog",
                    Image = "https://images.pexels.com/photos/160107/pexels-photo-160107.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
                },
                new Channel
                {
                    Name = "EbannoeIT",
                    Views = 3000,
                    Subscribers = 1500,
                    PlatformId = 2,
                    CategoryId = 6,
                    Link = "@ebannoeIT",
                    Image = "https://images.pexels.com/photos/160107/pexels-photo-160107.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
                },
            };
        }
    }
}
