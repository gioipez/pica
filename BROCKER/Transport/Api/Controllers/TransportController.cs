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
                id = reserveViewModel.id,
                provider_id = reserveViewModel.provider_id,
                integration_type_id = reserveViewModel.integration_type_id,
                agreement_id = reserveViewModel.agreement_id,
                tickets = reserveViewModel.tickets
            };

            return Ok(await transportService.Reserve(reserve));
        }

        [HttpPut]
        [Route("Cancel")]
        public async Task<IActionResult> Cancel(ReserveViewModel reserveViewModel)
        {
            reserve reserve = new reserve
            {
                filed = reserveViewModel.filed
            };

            return Ok(await transportService.Cancel(reserve));
        }
    }
}