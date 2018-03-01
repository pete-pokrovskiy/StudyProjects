using System.Collections.Generic;
using DutchTreatAspNetCore.Data.Entities;

namespace DutchTreatAspNetCore.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}