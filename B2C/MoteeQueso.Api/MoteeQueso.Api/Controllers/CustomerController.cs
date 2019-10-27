using Microsoft.AspNetCore.Mvc;
using MoteeQueso.Api.ViewModels;
using MoteeQueso.Core.Interfaces;
using MoteeQueso.Core.Services;
using MoteeQueso.Infraestructure.Entities;

namespace MoteeQueso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Crear cliente (Escenario sin autorizacion)
        /// </summary>
        /// <param name="customerViewModel">Datos cliente</param>
        /// <returns>Cliente</returns>
        [HttpPost]
        public IActionResult Create(CustomerViewModel customerViewModel)
        {
            ICustomerService customerService = new CustomerService();

            Customer customer = new Customer
            {
                FirstName = customerViewModel.FirstName,
                SecondName = customerViewModel.SecondName,
                LastName = customerViewModel.LastName,
                SecondLastName = customerViewModel.SecondLastName,
                PhoneNumber = customerViewModel.PhoneNumber,
                Email = customerViewModel.Email
            };

            customer = customerService.CreateCustomer(customer);

            return Ok(customer.Id);
        }
    }
}