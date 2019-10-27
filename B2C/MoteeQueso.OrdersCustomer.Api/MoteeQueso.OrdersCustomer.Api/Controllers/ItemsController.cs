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

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            IItemsService itemsService = new ItemService();
            List<Items> items = itemsService.GetItems();

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

        [HttpPost]
        public async Task<IActionResult> Create(ItemsViewModel item)
        {
            IItemsService itemsService = new ItemService();

            Items itemDB = new Items
            {
                ItemId = Guid.NewGuid(),
                PartNum = item.PartNum,
                Price = item.Price,
                ProdId = item.ProdId,
                ProductName = item.ProductName,
                Quantity = item.Quantity
            };

            itemDB = itemsService.CreateItem(itemDB);

            return Ok(itemDB);
        }

    }
}