using MediaAds.Core.Interfaces;
using MediaAds.Core.Models;
using MediaAds.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaAds.Infrastructure.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        private readonly MediaDbContext _db;

        public ReviewRepository(MediaDbContext context) : base(context)
        {
            _db = context;
        }

        public async Task<List<Review>> GetByChannel(int id)
        {
            return await _db.Reviews.Where(x => x.ChannelId == id).ToListAsync();
        }

        public async Task<List<Review>> GetByUser(int id)
        {
            return await _db.Reviews.Where(x => x.UserId == id).ToListAsync();
        }

        public async Task<double> GetAverageRating(int id)
        {
            return await _db.Reviews.Where(x => x.ChannelId == id).AverageAsync(a => a.Raiting);
        }
    }
}
