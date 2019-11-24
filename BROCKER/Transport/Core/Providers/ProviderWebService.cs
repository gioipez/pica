using MoteeQueso.BROCKER.Transport.Core.Factories;
using MoteeQueso.BROCKER.Transport.Infraestructure.Entities;
using MoteeQueso.BROCKER.Transport.Infraestructure.Enums;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Transport.Core.Providers
{
    public class ProviderWebService : ProviderFactory
    {
        public override async Task<Guid> Cancel(reserve reserve)
        {
            throw new NotImplementedException();
        }

        public override async Task<Guid> Reserve(reserve reserve)
        {
            WebServiceFactory webServiceFactory = InstanceWebServiceFactory(reserve.provider_id);
            return await webServiceFactory.Reserve(reserve);
        }

        private WebServiceFactory InstanceWebServiceFactory(int provider_id)
        {
            switch ((provider)provider_id)
            {
                case provider.Avianca:
                    return new WebServiceAvianca();
                case provider.AmericanAirlines:
                    return new WebServiceAmericanAirlines();
                default:
                    throw new NotImplementedException("Not Implemented Integration For Provider Id: " + provider_id);
            }
        }
    }
}