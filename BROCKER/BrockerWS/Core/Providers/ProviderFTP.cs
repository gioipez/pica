using MoteeQueso.Providers.Lodging.Core.Factories;
using MoteeQueso.Providers.Lodging.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.Providers.Lodging.Core.Providers
{
    public class ProviderFTP : ProviderFactory
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