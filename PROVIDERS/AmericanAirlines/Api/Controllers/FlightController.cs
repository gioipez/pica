using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AAFlightsService.ViewModels;

namespace AAFlightsService.Api.Controllers
{
    //[EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private static bool success = false;

        [HttpPost]
        [Route("reserveFlight")]
        public IActionResult reserveFlight(FlightViewModel flightViewModel)
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
        [Route("cancelFlight")]
        public IActionResult cancelFlight(FlightViewModel flightViewModel)
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