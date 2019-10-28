using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoteeQueso.OrdersCustomer.Api.ViewModels;
using MoteeQueso.OrdersCustomer.Core.Interfaces;
using MoteeQueso.OrdersCustomer.Core.Services;
using MoteeQueso.OrdersCustomer.Infraestructure.Entities;
using Newtonsoft.Json;

namespace MoteeQueso.OrdersCustomer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController() {
            customerService = new CustomerService();
        }

        /// <summary>
        /// Creacion de clientes
        /// </summary>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel customerViewModel)
        {

            var strCust = JsonConvert.SerializeObject(customerViewModel);

            Customer customer = JsonConvert.DeserializeObject<Customer>(strCust);

            customer = await Task.Run(() => customer = customerService.Create(customer));

            return Ok(customer.CustId);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers() {
            List<Customer> customers = await Task.Run(() => customers = customerService.GetCustomers());
            return Ok(customers);
        }

        [HttpGet("{custId}")]
        public async Task<IActionResult> GetCustomer(string custId)
        {
            Customer customer = await Task.Run(() => customer = customerService.GetCustomerById(custId));
            return Ok(customer);
        }
    }
}