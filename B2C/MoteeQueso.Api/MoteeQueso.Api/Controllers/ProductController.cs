using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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

        public ProductController()
        {
            productService = new ProductService();
        }

        /// <summary>
        /// Consultar productos (Escenario sin autorizacion)
        /// </summary>
        /// <returns>Lista de productos</returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts(int page = 1, int count = 10)
        {
            List<PRODUCTO> products = await productService.GetProducts(page, count);

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (PRODUCTO product in products)
            {
                productViewModels.Add(new ProductViewModel
                {
                    ID = product.id,
                    CIUDAD_ESPECTACULO = product.ciudad_espectaculo,
                    ESPECTACULO = product.espectaculo,
                    FECHA_ESPECTACULO = product.fecha_espectaculo,
                    FECHA_LLEGADA = product.fecha_llegada,
                    FECHA_SALIDA = product.fecha_salida,
                    TIPO_ESPECTACULO = product.tipo_espectaculo,
                    TIPO_OSPEDAJE = product.tipo_ospedaje,
                    TIPO_TRANSPORTE = product.tipo_transporte

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
                ciudad_espectaculo = product.CIUDAD_ESPECTACULO,
                espectaculo = product.ESPECTACULO,
                fecha_espectaculo = product.FECHA_ESPECTACULO,
                fecha_llegada = product.FECHA_LLEGADA,
                fecha_salida = product.FECHA_SALIDA,
                tipo_espectaculo = product.TIPO_ESPECTACULO,
                tipo_ospedaje = product.TIPO_OSPEDAJE,
                tipo_transporte = product.TIPO_TRANSPORTE
            };

            producto = await productService.CreateProduct(producto);

            return Ok(producto.id);
        }

        /// <summary>
        /// Consulta peoducto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            PRODUCTO product = await productService.GetProductById(id);
            return Ok(product);
        }
    }
}