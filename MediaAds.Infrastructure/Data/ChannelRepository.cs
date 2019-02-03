using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaAds.Core.Interfaces;
using MediaAds.Core.Models;

namespace MediaAds.Infrastructure.Data
{
    public class ChannelRepository : MediaRepository<Channel>, IChannelRepository
    {
        private readonly MediaDbContext _db;

        public ChannelRepository(MediaDbContext context) : base(context)
        {
            _db = context;
        }

        //public async Task<List<Channel>> GetByCategory(int categoryId)
        //{
            //TODO: add logic
        //}
    }
}
