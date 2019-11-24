using MoteeQueso.BROCKER.Lodging.Core.Factories;
using MoteeQueso.BROCKER.Lodging.Infraestructure.Entities;
using MoteeQueso.BROCKER.Lodging.Infraestructure.Enums;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Lodging.Core.Providers
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
                case provider.Hilton:
                    return new WebServiceHilton();
                default:
                    throw new NotImplementedException("Not Implemented Integration For Provider Id: " + provider_id);
            }
        }
    }
}