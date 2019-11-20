using Microsoft.EntityFrameworkCore;
using MoteeQueso.B2C.Customer.Core.Interfaces;
using MoteeQueso.B2C.Customer.Infraestructure.Data;
using MoteeQueso.B2C.Customer.Infraestructure.Entities;
using System.Threading.Tasks;
using System.Transactions;

namespace MoteeQueso.B2C.Customer.Core.Services
{
    public class CustomerService : ICustomerService
    {
        public async Task<int> CreateCustomer(customer customer)
        {
            customer.status_id = 1;

            using (TransactionScope transaction = new TransactionScope(
                TransactionScopeOption.Required, 
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                TransactionScopeAsyncFlowOption.Enabled))
            {
                using (B2CCustomerEntities entities = new B2CCustomerEntities())
                {
                    entities.customer.Add(customer);
                    await entities.SaveChangesAsync();
                }

                transaction.Complete();
            }

            return customer.id;
        }

        public async Task UpdateCustomer(customer customer)
        {
            using (TransactionScope transaction = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                TransactionScopeAsyncFlowOption.Enabled))
            {
                using (B2CCustomerEntities entities = new B2CCustomerEntities())
                {
                    entities.Entry(customer).State = EntityState.Modified;
                    await entities.SaveChangesAsync();

                    foreach (address address in customer.addresses)
                    {
                        address.customer_id = customer.id;

                        if (address.id == 0)
                        {
                            entities.address.Add(address);
                        }
                        else
                        {
                            entities.Entry(address).State = EntityState.Modified;
                        }

                        await entities.SaveChangesAsync();
                    }
                }

                transaction.Complete();
            }
        }
    }
}