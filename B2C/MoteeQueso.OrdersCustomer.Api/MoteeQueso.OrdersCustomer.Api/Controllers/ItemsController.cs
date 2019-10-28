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

namespace MoteeQueso.OrdersCustomer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService itemsService;

        public ItemsController()
        {
            itemsService = new ItemService();
        }

        /// <summary>
        /// Consulta de items de una orden
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            List<Items> items = await Task.Run(()=> items = itemsService.GetItems());

            List<ItemsViewModel> itemsViewModels = new List<ItemsViewModel>();

            foreach (Items item in items)
            {
                itemsViewModels.Add(new ItemsViewModel
                {
                    ItemId = item.ItemId,
                    PartNum = item.PartNum,
                    Price = item.Price,
                    ProdId = item.ProdId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                });
            }

            return Ok(itemsViewModels);
        }

        /// <summary>
        /// creacion de Items de orden
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(ItemsViewModel item)
        {
            Items itemDB = new Items
            {
                ItemId = Guid.NewGuid(),
                PartNum = item.PartNum,
                Price = item.Price,
                ProdId = item.ProdId,
                ProductName = item.ProductName,
                Quantity = item.Quantity
            };

            itemDB = await Task.Run(() => itemDB = itemsService.CreateItem(itemDB));

            return Ok(itemDB);
        }   

    }
}