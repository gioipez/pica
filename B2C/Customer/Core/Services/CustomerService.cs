using Microsoft.EntityFrameworkCore;
using MoteeQueso.B2C.Customer.Core.Interfaces;
using MoteeQueso.B2C.Customer.Infraestructure.Data;
using MoteeQueso.B2C.Customer.Infraestructure.Entities;
using System.Threading.Tasks;

namespace MoteeQueso.B2C.Customer.Core.Services
{
    public class CustomerService : ICustomerService
    {
        public async Task<int> CreateCustomer(customer customer)
        {
            customer.status_id = 1;

            using (B2CCustomerEntities entities = new B2CCustomerEntities())
            {
                entities.customer.Add(customer);
                await entities.SaveChangesAsync();
            }

            return customer.id;
        }

        public async Task UpdateCustomer(customer customer)
        {
            using (B2CCustomerEntities entities = new B2CCustomerEntities())
            {
                entities.Entry(customer).State = EntityState.Modified;
                await entities.SaveChangesAsync();
            }
        }
    }
}