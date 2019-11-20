using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoteeQueso.B2C.Order.Api.ViewModels;
using MoteeQueso.B2C.Order.Core.Interfaces;
using MoteeQueso.B2C.Order.Core.Services;
using MoteeQueso.B2C.Order.Infraestructure.Entities;

namespace MoteeQueso.B2C.Order.Api.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController()
        {
            orderService = new OrderService();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(int? id, int customer_id, int page = 1, int count = 5)
        {
            if (id.HasValue)
            {
                order order = await orderService.GetOrder(id.Value);

                if (order != null)
                {
                    OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel
                    {
                        id = order.id,
                        date = order.date,
                        price = order.price,
                        customer_id = order.customer_id,
                        status_id = order.status_id,
                        comments = order.comments
                    };

                    foreach (item item in order.items)
                    {
                        orderDetailViewModel.items.Add(new ItemViewModel
                        {
                            id = item.id,
                            product_id = item.product_id,
                            product_name = item.product_name,
                            price = item.price,
                            quantity = item.quantity
                        });
                    }

                    return Ok(orderDetailViewModel);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                List<order> orders = await orderService.GetOrders(customer_id, page, count);

                if (orders.Count > 0)
                {
                    List<OrderViewModel> orderViewModels = new List<OrderViewModel>();

                    foreach (order order in orders)
                    {
                        orderViewModels.Add(new OrderViewModel
                        {
                            id = order.id,
                            date = order.date,
                            price = order.price,
                            status = order.status.description
                        });
                    }

                    return Ok(orderViewModels);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDetailViewModel orderDetailViewModel)
        {
            order order = new order
            {
                date = orderDetailViewModel.date,
                price = orderDetailViewModel.price,
                comments = orderDetailViewModel.comments,
                customer_id = orderDetailViewModel.customer_id
            };

            foreach (ItemViewModel itemViewModel in orderDetailViewModel.items)
            {
                order.items.Add(new item
                {
                    product_id = itemViewModel.product_id,
                    product_name = itemViewModel.product_name,
                    price = itemViewModel.price,
                    quantity = itemViewModel.quantity
                });
            }

            return Ok(await orderService.CreateOrder(order));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderStatus(OrderStatusViewModel orderStatusViewModel)
        {
            await orderService.UpdateOrderStatus(orderStatusViewModel.id, orderStatusViewModel.status_id);
            return Ok();
        }
    }
}