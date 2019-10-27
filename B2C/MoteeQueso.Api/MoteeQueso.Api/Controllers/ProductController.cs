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
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Consultar productos (Escenario sin autorizacion)
        /// </summary>
        /// <returns>Lista de productos</returns>
        [HttpGet]
        public IActionResult GetProducts()
        {
            IProductService productService = new ProductService();
            List<Product> products = productService.GetProducts();

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (Product product in products)
            {
                productViewModels.Add(new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    City = product.City,
                    Date = product.Date
                });
            }

            return Ok(productViewModels);
        }
    }
}