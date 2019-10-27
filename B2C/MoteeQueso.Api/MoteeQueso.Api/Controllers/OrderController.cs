using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoteeQueso.Api.ViewModels;
using MoteeQueso.Core.Interfaces;
using MoteeQueso.Core.Services;
using MoteeQueso.Infraestructure.Entities;

namespace MoteeQueso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        /// <summary>
        /// Crear orden (Escenario con autorizacion)
        /// </summary>
        /// <param name="orderViewModel">Datos orden</param>
        /// <returns>Orden</returns>
        /*[HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            IOrderService orderService = new OrderService();

            Order order = new Order
            {
                CustomerId = orderViewModel.CustomerId,
                Date = orderViewModel.Date,
                Number = orderViewModel.Number,
                Price = orderViewModel.Price,
                StatusId = orderViewModel.StatusId,
                Comments = orderViewModel.Comments
            };

            order = orderService.CreateOrder(order);

            return Ok(order.Id);
        }

        /// <summary>
        /// Actualizar orden (Escenario con autorizacion)
        /// </summary>
        /// <param name="orderViewModel">Datos orden</param>
        /// <returns>Orden</returns>
        [HttpPut]
        public IActionResult Update(OrderViewModel orderViewModel)
        {
            IOrderService orderService = new OrderService();

            Order order = new Order
            {
                CustomerId = orderViewModel.CustomerId,
                Date = orderViewModel.Date,
                Number = orderViewModel.Number,
                Price = orderViewModel.Price,
                StatusId = orderViewModel.StatusId,
                Comments = orderViewModel.Comments
            };

            order = orderService.CreateOrder(order);

            return Ok(true);
        }*/
    }
}