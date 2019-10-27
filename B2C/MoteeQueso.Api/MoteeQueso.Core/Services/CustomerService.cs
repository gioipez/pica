using Microsoft.EntityFrameworkCore;
using MoteeQueso.Core.Interfaces;
using MoteeQueso.Infraestructure.Data;
using MoteeQueso.Infraestructure.Entities;

namespace MoteeQueso.Core.Services
{
    public class CustomerService : ICustomerService
    {
        public Customer CreateCustomer(Customer customer)
        {
            using (B2CEntities entities = new B2CEntities())
            {
                entities.Customers.Add(customer);
                entities.SaveChanges();
            }

            return customer;
        }
    }
}