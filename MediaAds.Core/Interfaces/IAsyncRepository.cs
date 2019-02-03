using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaAds.Core.Models;

namespace MediaAds.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseModel
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
