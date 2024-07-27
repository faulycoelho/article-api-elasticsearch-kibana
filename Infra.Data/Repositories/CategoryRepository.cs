using Application.Interfaces.Repository;
using Domain;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Category> CreateAsync(Category obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Category> DeleteAsync(Category obj)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Category> UpdateAsync(Category obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Category?> GetAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
