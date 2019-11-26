using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoteeQueso.BROCKER.Transport.Api.ViewModels;
using MoteeQueso.BROCKER.Transport.Core.Interfaces;
using MoteeQueso.BROCKER.Transport.Core.Services;
using MoteeQueso.BROCKER.Transport.Infraestructure.Entities;

namespace MoteeQueso.BROCKER.Transport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ITransportService transportService;

        public TransportController()
        {
            transportService = new TransportService();
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
                first_name = reserveViewModel.first_name,
                last_name = reserveViewModel.last_name,
                departure_date = reserveViewModel.departure_date,
                departure_hour = reserveViewModel.departure_hour,
                trip_number = reserveViewModel.trip_number,
                chair_number = reserveViewModel.chair_number,
                origin = reserveViewModel.origin,
                destiny = reserveViewModel.destiny
            };

            return Ok(await transportService.Reserve(reserve));
        }

        [HttpPut]
        [Route("Cancel")]
        public async Task<IActionResult> Cancel(ReserveViewModel reserveViewModel)
        {
            reserve reserve = new reserve
            {
                order_id = reserveViewModel.order_id
            };

            return Ok(await transportService.Cancel(reserve));
        }
    }
}