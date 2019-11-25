using MoteeQueso.BROCKER.Lodging.Core.Factories;
using MoteeQueso.BROCKER.Lodging.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Lodging.Core.Providers
{
    public class ProviderFTP : ProviderFactory
    {
        public override Task<bool> Cancel(reserve reserve)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Reserve(reserve reserve)
        {
            throw new NotImplementedException();
        }
    }
}