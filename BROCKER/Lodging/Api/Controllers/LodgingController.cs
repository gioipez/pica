using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoteeQueso.BROCKER.Lodging.Api.ViewModels;
using MoteeQueso.BROCKER.Lodging.Core.Interfaces;
using MoteeQueso.BROCKER.Lodging.Core.Services;
using MoteeQueso.BROCKER.Lodging.Infraestructure.Entities;

namespace MoteeQueso.BROCKER.Lodging.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LodgingController : ControllerBase
    {
        private readonly ILodgingService lodgingService;

        public LodgingController()
        {
            lodgingService = new LodgingService();
        }

        [HttpPost]
        [Route("Reserve")]
        public async Task<IActionResult> Reserve(ReserveViewModel reserveViewModel)
        {
            reserve reserve = new reserve
            {
                provider_id = reserveViewModel.provider_id,
                integration_type_id = reserveViewModel.integration_type_id,
                order_id = reserveViewModel.order_id,
                hotel_id = reserveViewModel.hotel_id,
                room_number = reserveViewModel.hotel_id,
                check_in_date = reserveViewModel.check_in_date,
                check_out_date = reserveViewModel.check_out_date,
                state = reserveViewModel.state,
                guest_name = reserveViewModel.guest_name
            };

            return Ok(await lodgingService.Reserve(reserve));
        }

        [HttpPut]
        [Route("Cancel")]
        public async Task<IActionResult> Cancel(ReserveViewModel reserveViewModel)
        {
            reserve reserve = new reserve
            {
                order_id = reserveViewModel.order_id
            };

            return Ok(await lodgingService.Cancel(reserve));
        }
    }
}