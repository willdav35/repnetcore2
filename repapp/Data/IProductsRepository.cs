using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using repapp.Data.Entities;

namespace repapp.Data
{
    public interface IProductsRepository
    {
        // IEnumerable<Product> GetAllProducts();
       
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}