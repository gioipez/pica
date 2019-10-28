using MoteeQueso.OrdersCustomer.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoteeQueso.OrdersCustomer.Core.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(string CustId);
        Customer Create(Customer customer);
    }
}
