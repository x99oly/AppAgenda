using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleAgenda.Context;
using SimpleAgenda.DTOS;
using SimpleAgenda.Interfaces;

namespace SimpleAgenda.Repositories
{
    internal class AgendaRepository<T> : IRepository<T> where T : class
    {
        private readonly SqliteContext _context;
        private readonly DbSet<T> _dbSet;

        internal AgendaRepository(SqliteContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Get by ID
        public async Task<T?> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Get list of all entities
        public async Task<List<T>> GetList()
        {
            return await _dbSet.ToListAsync();
        }

        // Create new entity
        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Update an existing entity
        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        // Delete entity by ID
        public async Task Delete(int id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

    }
}
