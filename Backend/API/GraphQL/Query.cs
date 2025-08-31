using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.GraphQL
{
    public class Query
    {
        [UseFiltering]
        public IQueryable<Customer> GetCustomers([Service] OMAContext context)
        {
            context.Database.EnsureCreated();
            return context.Customers
                    .Include(c => c.Orders)
                    .Include(c => c.Address);
        }
        [UseFiltering]
        public IQueryable<Order> GetOrders([Service] OMAContext context)
        {
            context.Database.EnsureCreated();
            return context.Orders
                    .Include(o => o.Customer);
        }
    }
}