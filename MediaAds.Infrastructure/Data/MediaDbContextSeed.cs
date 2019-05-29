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

            if (!context.Roles.Any())
            {
                context.Roles.AddRange(GetRoles());
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(GetUsers());
                await context.SaveChangesAsync();
            }

            if (!context.Reviews.Any())
            {
                context.Reviews.AddRange(GetReviews());
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
                    Name = "Бизнес"
                },
                new Category {
                    Name = "Юмор"
                },
                new Category {
                    Name = "IT"
                },
                new Category {
                    Name = "Образование"
                },
                new Category {
                    Name = "Новости"
                },
                new Category {
                    Name = "Блог"
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
                    ERR = 60,
                    Description = "Канал о web-разработке. Полезные ресурсы для Backend и Frontend разработчиков, программирование, новости IT и многое другое.",
                    PlatformId = 2,
                    CategoryId = 3,
                    Link = "webb_dev",
                    Image = "https://static2.tgstat.com/public/images/channels/_0/ac/ac04d72a15f9992569909320f92e2f9b.jpg"
                },
                new Channel
                {
                    Name = "GameDEV",
                    Description = "Канал о разработке игр. Новости игровой индустрии, полезные статьи, обучение разработке и многое другое.",
                    Views = 1500,
                    ERR = 30,
                    Subscribers = 1600,
                    PlatformId = 2,
                    CategoryId = 3,
                    Link = "gamee_dev",
                    Image = "https://static.tgstat.ru/public/images/channels/_0/96/96e3f1f8d31cebc5c2ed66bdf88c59df.jpg"
                },
                new Channel
                {
                    Name = "Говнокод",
                    Views = 20000,
                    ERR = 109,
                    Description = "Говнокод — канал о самых забавных и интересных подборках говнокода с GitHub и не только.",
                    Subscribers = 16100,
                    PlatformId = 2,
                    CategoryId = 3,
                    Link = "g_code",
                    Image = "https://static2.tgstat.com/public/images/channels/_0/02/029591145fad252b28d844d823097400.jpg"
                },
                new Channel
                {
                    Name = "Daily Coding",
                    Views = 1000,
                    Description = "Канал, который научит вас программировать лучше и эффективнее. Интересные задачи, обучающие статьи, советы по стилю кода и многое другое.",
                    Subscribers = 2000,
                    PlatformId = 2,
                    CategoryId = 3,
                    ERR = 20,
                    Link = "programmers_live",
                    Image = "https://images.pexels.com/photos/160107/pexels-photo-160107.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
                },
                new Channel
                {
                    Name = "Code Blog",
                    Views = 7000,
                    Description = "Статьи о программировании, обучающие видео, книги, IT юмор.",
                    Subscribers = 9000,
                    PlatformId = 2,
                    CategoryId = 3,
                    ERR = 42,
                    Link = "codeblog",
                    Image = "https://static.tgstat.ru/public/images/channels/_0/c3/c33aefbb8e11beca6134f65db0e33133.jpg"
                },
                new Channel
                {
                    Name = "EbannoeIT",
                    Description = "Голая правда о нашем айти в телеграмме.",
                    ERR = 120,
                    Views = 3000,
                    Subscribers = 1500,
                    PlatformId = 2,
                    CategoryId = 1,
                    Link = "ebannoeIT",
                    Image = "https://static.tgstat.ru/public/images/channels/_0/0f/0f8a2773df847871112769dc691c1270.jpg"
                },
            };
        }

        static IEnumerable<Review> GetReviews()
        {
            return new List<Review>
            {
                new Review
                {
                    Text = "Все отличо, спасибо!",
                    Raiting = 5,
                    ChannelId = 1,
                    UserId = 1
                },
                new Review
                {
                    Text = "супер, спасибо!",
                    Raiting = 5,
                    ChannelId = 1,
                    UserId = 1
                },
                new Review
                {
                    Text = "Все отличо, спасибо!",
                    Raiting = 5,
                    ChannelId = 2,
                    UserId = 1
                },
            };
        }

        static IEnumerable<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role { Name = "Admin"},
                new Role { Name = "User" }
            };
        }

        static IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User { Name = "Nikita", RoleId = 1, Username = "admin", Password = "202cb962ac59075b964b07152d234b70" }, // 123
                new User { Name = "Nikita", RoleId = 1, Username = "user", Password = "202cb962ac59075b964b07152d234b70" } // 123
            };
        }
    }
}
