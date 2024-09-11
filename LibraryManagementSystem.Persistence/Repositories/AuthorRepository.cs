using LibraryManagement.Application.Contracts.Persistence;
using LibraryManagement.Domain;
using LibraryManagementSystem.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Persistence.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ConnectionDatabaseContext _dbContext;

        public AuthorRepository(ConnectionDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _dbContext.Authors.FindAsync(id);
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task AddAsync(Author author)
        {
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            _dbContext.Authors.Update(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Author author)
        {
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
        }
    }
}
