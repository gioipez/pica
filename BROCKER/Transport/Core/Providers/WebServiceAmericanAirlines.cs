using MoteeQueso.BROCKER.Transport.Core.Factories;
using MoteeQueso.BROCKER.Transport.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Transport.Core.Providers
{
    public class WebServiceAmericanAirlines : WebServiceFactory
    {
        public override Task<Guid> Cancel(reserve reserve)
        {
            throw new NotImplementedException();
        }

        public override Task<Guid> Reserve(reserve reserve)
        {
            throw new NotImplementedException();
        }
    }
}