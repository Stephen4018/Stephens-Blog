using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class Repository : IRepository 
    {
        public readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<Blogs> AddAsync(Blogs Entity, string userID)
        {
            try
            {
                Entity.UserId = userID;

                await _context.Blogs.AddAsync(Entity);
                
                await _context.SaveChangesAsync();
                return Entity;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
   

        public async Task<IEnumerable<Blogs>> GetAllAsync()
        {
            try
            {
                return await _context.Blogs.Include(b => b.User).ToListAsync();
            }
            catch (Exception ex)
            {
               
                throw;
            }
        }

    }
}
