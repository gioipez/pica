using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoteeQueso.Providers.Lodging.Api.ViewModels;
using MoteeQueso.Providers.Lodging.Core.Interfaces;
using MoteeQueso.Providers.Lodging.Core.Services;
using MoteeQueso.Providers.Lodging.Infraestructure.Entities;

namespace MoteeQueso.Providers.Lodging.Api.Controllers
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
                id = reserveViewModel.id,
                provider_id = reserveViewModel.provider_id,
                integration_type_id = reserveViewModel.integration_type_id,
                agreement_id = reserveViewModel.agreement_id,
                days = reserveViewModel.days
            };

            return Ok(await lodgingService.Reserve(reserve));
        }

        [HttpPut]
        [Route("Cancel")]
        public async Task<IActionResult> Cancel(ReserveViewModel reserveViewModel)
        {
            reserve reserve = new reserve
            {
                filed = reserveViewModel.filed
            };

            return Ok(await lodgingService.Cancel(reserve));
        }
    }
}