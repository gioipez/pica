using MoteeQueso.B2C.Customer.Infraestructure.Entities;
using System.Threading.Tasks;

namespace MoteeQueso.B2C.Customer.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<int> CreateCustomer(customer customer);

        Task UpdateCustomer(customer customer);
    }
}