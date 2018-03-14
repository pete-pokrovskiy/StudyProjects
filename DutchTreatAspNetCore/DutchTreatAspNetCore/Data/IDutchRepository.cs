using System.Collections.Generic;
using DutchTreatAspNetCore.Data.Entities;

namespace DutchTreatAspNetCore.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        IEnumerable<Order> GetAllOrders(bool includeItems = true);
        IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItems);

        Order GetOrderById(string userName, int id);

        void AddEntity(object model);

        bool SaveAll();
    }
}