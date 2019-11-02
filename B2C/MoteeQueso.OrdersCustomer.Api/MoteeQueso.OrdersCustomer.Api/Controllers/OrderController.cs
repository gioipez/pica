using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoteeQueso.OrdersCustomer.Api.ViewModels;
using MoteeQueso.OrdersCustomer.Core.Interfaces;
using MoteeQueso.OrdersCustomer.Core.ModelsBO;
using MoteeQueso.OrdersCustomer.Core.Services;
using MoteeQueso.OrdersCustomer.Infraestructure.Entities;
using Newtonsoft.Json;

namespace MoteeQueso.OrdersCustomer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersService orderService;

        public OrderController() {

            orderService = new OrderService();

        }

        /// <summary>
        /// Creacion de una orden
        /// </summary>
        /// <param name="orderViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel orderViewModel)
        {

            var strOrderBo = JsonConvert.SerializeObject(orderViewModel);

            OrderBO orderBo = JsonConvert.DeserializeObject<OrderBO>(strOrderBo);

            Orders order = await Task.Run(() => order = orderService.Create(orderBo));

            return Ok(order.ordid);
        }

        public async Task<IActionResult> GetOrderById(string ordId) {
            
            Orders order = await Task.Run(()=>  order = orderService.GetOrderById(new Guid(ordId)));

            return Ok(order);
        }
    }
}