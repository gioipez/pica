using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HiltonBookingService.ViewModels;

namespace HiltonBookingService.Api.Controllers
{
    //[EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private static bool success = false;

        [HttpPost]
        [Route("reserveRoom")]
        public IActionResult reserveRoom(RoomViewModel roomViewModel)
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
        [Route("cancelRoom")]
        public IActionResult cancelRoom(RoomViewModel roomViewModel)
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