using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaAds.Core.Interfaces;
using MediaAds.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaAds.Infrastructure.Data
{
    public class MediaRepository<T> : IAsyncRepository<T> where T : BaseModel
    {
        protected readonly MediaDbContext _db;

        public MediaRepository(MediaDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
