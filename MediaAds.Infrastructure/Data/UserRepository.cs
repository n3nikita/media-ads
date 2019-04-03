using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaAds.Core.Interfaces;
using MediaAds.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaAds.Infrastructure.Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MediaDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByCredentials(string username, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (user is null)
                throw new ArgumentException($"User {username}:{password} not found");

            return user;
        }
    }
}
