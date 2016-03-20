using System.Collections.Generic;
using DM.Core.Model;

namespace DM.Core.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
    }
}
