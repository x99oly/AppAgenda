using System;
using SQLite;

namespace Duckendar.Model.Repositories
{
    public class SqLiteRepository<T>(string dbPath)
    {
        private readonly SQLiteAsyncConnection _connection = new(dbPath);

        public Task<int> AddAsync(T entity)
        {
            return _connection.InsertAsync(entity);
        }

        public Task<List<T>> GetAllTsAsync()
        {
            return _connection.Table<T>().ToListAsync();
        }

        public Task<int> DeleteTAsync(T entity)
        {
            return _connection.DeleteAsync(entity);
        }

        public Task<int> UpdateTAsync(T entity)
        {
            return _connection.UpdateAsync(entity);
        }
    }
}
