using DutchTreatAspNetCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreatAspNetCore.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _ctx;
        private readonly ILogger<DutchRepository> _logger;

        public DutchRepository(DutchContext ctx, ILogger<DutchRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems = true)
        {
            if(includeItems)
            {
                return _ctx.Orders.Include(o => o.Items)
                  .ThenInclude(i => i.Product)
                  .ToList();

            }
            else
            {
                return _ctx.Orders.ToList();
            }
        }

        public IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders
                  .Where(o => o.User.UserName == userName)
                    .Include(o => o.Items)
                  .ThenInclude(i => i.Product)
                  .ToList();

            }
            else
            {
                return _ctx.Orders.Where(o => o.User.UserName == userName).ToList();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            _logger.LogInformation("Getting all products..");
            return _ctx.Products.OrderBy(p => p.Category).ToList();
        }

        public Order GetOrderById(string userName, int id)
        {
            //return _ctx.Orders.Find(id);
            return _ctx.Orders
                .Where(o => o.User.UserName == userName)
                .Include(o => o.Items)
                  .ThenInclude(i => i.Product)
                  .FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products.Where(p => p.Category == category).ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
