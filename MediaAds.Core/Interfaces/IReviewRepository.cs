using MediaAds.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaAds.Core.Interfaces
{
    public interface IReviewRepository : IAsyncRepository<Review>
    {
        Task<List<Review>> GetByChannel(int id);
        Task<List<Review>> GetByUser(int id);
        Task<double> GetAverageRating(int id);
    }
}
