using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioWebAvianca.ViewModels;

namespace ServicioWebAvianca.Api.Controllers
{
    //[EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class VueloController : ControllerBase
    {
        private static bool success = false;

        [HttpPost]
        [Route("reservarVuelo")]
        public IActionResult reservarVuelo(VueloViewModel vueloViewModel)
        {
            success = !success;

            if (success)
            {
                return Ok(Guid.NewGuid());
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("cancelarVuelo")]
        public IActionResult cancelarVuelo(VueloViewModel vueloViewModel)
        {
            success = !success;

            if (success)
            {
                return Ok(Guid.NewGuid());
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}