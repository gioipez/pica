using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoteeQueso.Api.ViewModels;

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
        [HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            return Ok(orderViewModel);
        }

        /// <summary>
        /// Actualizar orden (Escenario con autorizacion)
        /// </summary>
        /// <param name="orderViewModel">Datos orden</param>
        /// <returns>Orden</returns>
        [HttpPut]
        public IActionResult Update(OrderViewModel orderViewModel)
        {
            return Ok(orderViewModel);
        }
    }
}