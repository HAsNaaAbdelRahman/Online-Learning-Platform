using Microsoft.EntityFrameworkCore;
using Online_Learning_Platform.Core.Repositories.Contract;
using Online_Learning_Platform.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_Platform.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void addAsync(T entity)
        {
           _context.Set<T>().AddAsync(entity);

        }

        public void deleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);

        }

        public void updateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
