using Microsoft.AspNetCore.Mvc;
using MoteeQueso.Api.ViewModels;

namespace MoteeQueso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Crear cliente (Escenario sin autorizacion)
        /// </summary>
        /// <param name="customerViewModel">Datos cliente</param>
        /// <returns>Cliente</returns>
        [HttpPost]
        public IActionResult Create(CustomerViewModel customerViewModel)
        {
            return Ok(customerViewModel);
        }
    }
}