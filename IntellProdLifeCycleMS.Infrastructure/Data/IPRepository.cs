using IntellProdLifeCycleMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntellProdLifeCycleMS.Infrastructure.Data
{
    public class IPRepository
    {
        private readonly AppDbContext _dbContext;

        public IPRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<T>> GetByIdAll<T>() where T : IntelliegentWork
        {

            return await _dbContext.Set<T>().ToListAsync();
            
        }

        public async Task<T> GetById<T>(int id) where T : IntelliegentWork
        {

            var temp = await _dbContext.Set<T>().FindAsync(id);
            return temp;
        }

        public async Task<T> GetById<T>(int id, string include) where T : IntelliegentWork
        {
            return await _dbContext.Set<T>()
                .Include(include)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> Add<T>(T entity) where T : IntelliegentWork
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Delete<T>(T entity) where T : IntelliegentWork
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update<T>(T entity) where T : IntelliegentWork
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public bool EntityExist<T>(int Id) where T : IntelliegentWork
        {
            return _dbContext.Set<T>().Any(e => e.Id == Id);
        }
    }
}