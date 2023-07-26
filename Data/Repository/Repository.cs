using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class Repository<T> : IRepository <T> where T : class
    {
        public readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<Blogs> AddAsync(Blogs Entity)
        {
            try
            {
                await _context.Blogs.AddAsync(Entity);
                await _context.SaveChangesAsync();
                return Entity;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        Task<IEnumerable<T>> IRepository<T>.GetAllAsync()
        {
            try
            {
                await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                // Implement error handling here (e.g., log the exception, throw custom exception, etc.)
                // For simplicity, we'll just re-throw the exception here
                throw;
            }
        }
    }
}
