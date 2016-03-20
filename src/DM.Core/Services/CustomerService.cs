using System.Collections.Generic;
using DM.Core.Model;

namespace DM.Core.Services
{
    public class CustomerService : ICustomerService
    {
        public List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();

            customers.Add(new Customer { FirstName = "Orlando", LastName = "Gee", Email = "orlando@adventure-works.com", IsMember = true, Status = OrderStatus.New });
            customers.Add(new Customer { FirstName = "Keith", LastName = "Harris", Email = "keith@adventure-works.com", IsMember = true, Status = OrderStatus.Received });
            customers.Add(new Customer { FirstName = "Donna", LastName = "Carreras", Email = "donna@adventure-works.com", IsMember = false, Status = OrderStatus.None });
            customers.Add(new Customer { FirstName = "Janet", LastName = "Gates", Email = "janet@adventure-works.com", IsMember = true, Status = OrderStatus.Shipped });
            customers.Add(new Customer { FirstName = "Lucy", LastName = "Harrington", Email = "lucy@adventure-works.com", IsMember = false, Status = OrderStatus.New });
            customers.Add(new Customer { FirstName = "Rosmarie", LastName = "Carroll", Email = "rosmarie@adventure-works.com", IsMember = true, Status = OrderStatus.Processing });
            customers.Add(new Customer { FirstName = "Dominic", LastName = "Gash", Email = "dominic@adventure-works.com", IsMember = true, Status = OrderStatus.Received });
            customers.Add(new Customer { FirstName = "Kathleen", LastName = "Garza", Email = "kathleen@adventure-works.com", IsMember = false, Status = OrderStatus.None });
            customers.Add(new Customer { FirstName = "Katherine", LastName = "Harding", Email = "katherine@adventure-works.com", IsMember = true, Status = OrderStatus.Shipped });
            customers.Add(new Customer { FirstName = "Johnny", LastName = "Caprio", Email = "johnny@adventure-works.com", IsMember = false, Status = OrderStatus.Processing });

            return customers;
        }
    }
}
