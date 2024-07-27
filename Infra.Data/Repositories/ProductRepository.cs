using Application.Interfaces.Repository;
using Domain;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Product> CreateAsync(Product obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Product> DeleteAsync(Product obj)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Product> UpdateAsync(Product obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Product?> GetAsync(int id)
        {
            return await _context.Products
                .Include(o => o.Category)
                .SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
