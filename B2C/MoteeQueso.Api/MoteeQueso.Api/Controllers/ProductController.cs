using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoteeQueso.Api.ViewModels;
using MoteeQueso.Core.Interfaces;
using MoteeQueso.Core.Services;
using MoteeQueso.Infraestructure.Entities;

namespace MoteeQueso.Api.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController() {
            productService = new ProductService();
        }
        /// <summary>
        /// Consultar productos (Escenario sin autorizacion)
        /// </summary>
        /// <returns>Lista de productos</returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts(int page, int count)
        {
            List<PRODUCTO> products = await Task.Run(() => products = productService.GetProducts(page, count));

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (PRODUCTO product in products)
            {
                productViewModels.Add(new ProductViewModel
                {
                    ID = product.ID,
                    CIUDAD_ESPECTACULO = product.CIUDAD_ESPECTACULO,
                    ESPECTACULO = product.ESPECTACULO,
                    FECHA_ESPECTACULO = product.FECHA_ESPECTACULO,
                    FECHA_LLEGADA = product.FECHA_LLEGADA,
                    FECHA_SALIDA = product.FECHA_SALIDA,
                    TIPO_ESPECTACULO = product.TIPO_ESPECTACULO,
                    TIPO_OSPEDAJE = product.TIPO_OSPEDAJE,
                    TIPO_TRANSPORTE = product.TIPO_TRANSPORTE

                });
            }

            return Ok(productViewModels);
        }

        
        /// <summary>
        /// Creacion de productos
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel product)
        {
            PRODUCTO producto = new PRODUCTO
            {
                CIUDAD_ESPECTACULO = product.CIUDAD_ESPECTACULO,
                ESPECTACULO = product.ESPECTACULO,
                FECHA_ESPECTACULO = product.FECHA_ESPECTACULO,
                FECHA_LLEGADA = product.FECHA_LLEGADA,
                FECHA_SALIDA = product.FECHA_SALIDA,
                TIPO_ESPECTACULO = product.TIPO_ESPECTACULO,
                TIPO_OSPEDAJE = product.TIPO_OSPEDAJE,
                TIPO_TRANSPORTE = product.TIPO_TRANSPORTE
            };

            producto = await Task.Run(() => productService.CreateProduct(producto));

            return Ok(producto);
        }

        /// <summary>
        /// Consulta peoducto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            PRODUCTO product = await Task.Run(() => product = productService.GetProductById(id) );
            return Ok(product);
        }
    
    }
}