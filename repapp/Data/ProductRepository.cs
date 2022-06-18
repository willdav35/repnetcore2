using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using repapp.Data.Entities;

namespace repapp.Data
{
    public class ProductRepository : IProductRepository
    //:IProductsRepository
    {
        private readonly DataDbContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(DataDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _context.Add(model);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _context.Orders.Include(i => i.Items).ToList();
            }
            else
            {
                return _context.Orders.ToList();
            }

        }
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called...");

                return _context.Products.OrderBy(p => p.Title)
                    .ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders
         .Include(o => o.Items)
         .ThenInclude(i => i.Product)
         .Where(o => o.Id == id)
         .FirstOrDefault();

        }




            public IEnumerable<Product> GetProductsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        
    }
}