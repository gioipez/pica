using MoteeQueso.BROCKER.Lodging.Core.Factories;
using MoteeQueso.BROCKER.Lodging.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Lodging.Core.Providers
{
    public class ProviderDataBase : ProviderFactory
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