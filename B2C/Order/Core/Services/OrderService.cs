using Microsoft.EntityFrameworkCore;
using MoteeQueso.B2C.Order.Core.Interfaces;
using MoteeQueso.B2C.Order.Infraestructure.Data;
using MoteeQueso.B2C.Order.Infraestructure.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace MoteeQueso.B2C.Order.Core.Services
{
    public class OrderService : IOrderService
    {
        public async Task<int> CreateOrder(order order)
        {
            order.status_id = 1;

            using (TransactionScope transaction = new TransactionScope(
                TransactionScopeOption.Required, 
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                TransactionScopeAsyncFlowOption.Enabled))
            {
                using (B2COrderEntities entities = new B2COrderEntities())
                {
                    entities.order.Add(order);
                    await entities.SaveChangesAsync();
                }

                transaction.Complete();
            }

            return order.id;
        }

        public async Task UpdateOrderStatus(int id, int status_id)
        {
            using (B2COrderEntities entities = new B2COrderEntities())
            {
                order order = await entities.order.FirstOrDefaultAsync(x => x.id == id);
                order.status_id = status_id;

                entities.Entry(order).State = EntityState.Modified;
                await entities.SaveChangesAsync();
            }
        }

        public Task<order> GetOrder(int id)
        {
            using (B2COrderEntities entities = new B2COrderEntities())
            {
                return entities.order.Include(x => x.status)
                    .Include(x => x.items).FirstOrDefaultAsync(x => x.id == id);
            }
        }

        public async Task<List<order>> GetOrders(int customer_id, int page, int count)
        {
            using (B2COrderEntities entities = new B2COrderEntities())
            {
                return await entities.order.Include(x => x.status)
                    .Where(x => x.customer_id == customer_id).ToListAsync();
            }
        }
    }
}