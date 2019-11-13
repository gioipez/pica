using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoteeQueso.B2C.Customer.Api.ViewModels;
using MoteeQueso.B2C.Customer.Core.Interfaces;
using MoteeQueso.B2C.Customer.Core.Services;
using MoteeQueso.B2C.Customer.Infraestructure.Entities;

namespace MoteeQueso.B2C.Customer.Api.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController()
        {
            customerService = new CustomerService();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerViewModel customerViewModel)
        {
            customer customer = new customer
            {
                first_name = customerViewModel.first_name,
                last_name = customerViewModel.last_name,
                phone_number = customerViewModel.phone_number,
                email = customerViewModel.email,
                credit_card_type_id = customerViewModel.credit_card_type_id,
                credit_card_number = customerViewModel.credit_card_number
            };

            return Ok(await customerService.CreateCustomer(customer));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerViewModel customerViewModel)
        {
            customer customer = new customer
            {
                id = customerViewModel.id,
                first_name = customerViewModel.first_name,
                last_name = customerViewModel.last_name,
                phone_number = customerViewModel.phone_number,
                email = customerViewModel.email,
                credit_card_type_id = customerViewModel.credit_card_type_id,
                credit_card_number = customerViewModel.credit_card_number,
                status_id = customerViewModel.status_id
            };

            await customerService.UpdateCustomer(customer);

            return Ok();
        }
    }
}