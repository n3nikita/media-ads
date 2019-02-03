using System;
using System.Collections.Generic;
using System.Text;
using MediaAds.Core.Interfaces;
using MediaAds.Core.Models;

namespace MediaAds.Infrastructure.Data
{
    public class ChannelRepository : MediaRepository<Channel>, IChannelRepository
    {
        public ChannelRepository(MediaDbContext context) : base(context)
        { }
    }
}
