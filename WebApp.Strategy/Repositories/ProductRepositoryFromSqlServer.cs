using BaseProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Strategy.Models;

namespace WebApp.Strategy.Repositories
{
    public class ProductRepositoryFromSqlServer : IProductRepository
    {
        private readonly AppIdentityDbContext _appIdentityDbContext;

        public ProductRepositoryFromSqlServer(AppIdentityDbContext appIdentityDbContext)
        {
            _appIdentityDbContext = appIdentityDbContext;
        }

        public async Task<Product> GeyById(string id)
        {
            return await _appIdentityDbContext.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAllByUserId(string userId)
        {
            return await _appIdentityDbContext.Products.Where(x => x.UserId == userId).ToListAsync();
        }


        public async Task<Product> Save(Product product)
        {
            product.Id = Guid.NewGuid().ToString();
            await _appIdentityDbContext.Products.AddAsync(product);
            await _appIdentityDbContext.SaveChangesAsync();
            return product;
        }

        public async Task Update(Product product)
        {
            _appIdentityDbContext.Products.Update(product);
            await _appIdentityDbContext.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _appIdentityDbContext.Remove(product);
            await _appIdentityDbContext.SaveChangesAsync();
        }
    }
}
