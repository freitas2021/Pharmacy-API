using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Pharmacy.API.Data;
using Pharmacy.API.Interfaces;
using Pharmacy.API.Models;

namespace Pharmacy.API.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(long id)
        {
            var product = await GetProductById(id);
            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(long id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateProduct(long id, Product request)
        {
            var product = await GetProductById(id);
            product.Description = request.Description;
            product.Price = request.Price;
            await _context.SaveChangesAsync();
        }
    }
}
