using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using repapp.Data.Entities;

namespace repapp.Data
{
    public class ProductRepository :IProductsRepository
    {
        private readonly DataDbContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(DataDbContext context ,ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


 
        public async Task<IEnumerable<Product>> GetProductsAsync()
     {
      try
      {
        _logger.LogInformation("GetAllProducts was called...");

                return await _context.Products.ToListAsync();

            }
      catch (Exception ex)
      {
        _logger.LogError($"Failed to get all products: {ex}");
        return null;
      }
    }

    }
}