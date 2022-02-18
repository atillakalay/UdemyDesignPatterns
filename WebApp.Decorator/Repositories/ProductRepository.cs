using BaseProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Decorator.Models;

namespace WebApp.Decorator.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppIdentityDbContext _identityDbContext;

        public ProductRepository(AppIdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }

        public async Task<Product> GetById(int id)
        {
            return await _identityDbContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _identityDbContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetAll(string userId)
        {
            return await _identityDbContext.Products.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Product> Save(Product product)
        {
            await _identityDbContext.Products.AddAsync(product);
            await _identityDbContext.SaveChangesAsync();
            return product;
        }

        public async Task Update(Product product)
        {
            _identityDbContext.Update(product);
            await _identityDbContext.SaveChangesAsync();
        }

        public async Task Remove(Product product)
        {
            _identityDbContext.Remove(product);
            await _identityDbContext.SaveChangesAsync();
        }
    }
}
