using repapp.Data.Entities;
using System.Collections.Generic;

namespace repapp.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
       IEnumerable<Product> GetProductsByCategory(string category);
      
        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);
        bool SaveAll();
        void AddEntity(object model);
    }
}