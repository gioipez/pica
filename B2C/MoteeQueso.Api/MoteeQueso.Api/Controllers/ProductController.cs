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

namespace MoteeQueso.Api.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
        /// <summary>
        /// Consultar productos (Escenario sin autorizacion)
        /// </summary>
        /// <returns>Lista de productos</returns>
        [HttpGet]
        public IActionResult GetProducts () {
            IProductService productService = new ProductService ();
            List<PRODUCTO> products = productService.GetProducts ();

            List<ProductViewModel> productViewModels = new List<ProductViewModel> ();

            foreach (PRODUCTO product in products) {
                productViewModels.Add (new ProductViewModel {
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

            return Ok (productViewModels);
        }

        [HttpPost]
        public IActionResult Create (ProductViewModel product) {
            IProductService productService = new ProductService ();

            PRODUCTO producto = new PRODUCTO {
                CIUDAD_ESPECTACULO = product.CIUDAD_ESPECTACULO,
                ESPECTACULO = product.ESPECTACULO,
                FECHA_ESPECTACULO = product.FECHA_ESPECTACULO,
                FECHA_LLEGADA = product.FECHA_LLEGADA,
                FECHA_SALIDA = product.FECHA_SALIDA,
                TIPO_ESPECTACULO = product.TIPO_ESPECTACULO,
                TIPO_OSPEDAJE = product.TIPO_OSPEDAJE,
                TIPO_TRANSPORTE = product.TIPO_TRANSPORTE
            };

            producto = productService.CreateProduct (producto);

            return Ok (producto);
        }
    }
}