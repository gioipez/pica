using MoteeQueso.Infraestructure.Entities;

namespace MoteeQueso.Core.Interfaces
{
    public interface ICustomerService
    {
        Customer CreateCustomer(Customer customer);
    }
}