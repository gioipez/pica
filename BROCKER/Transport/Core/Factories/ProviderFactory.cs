using MoteeQueso.BROCKER.Transport.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Transport.Core.Factories
{
    public abstract class ProviderFactory
    {
        public abstract Task<bool> Reserve(reserve reserve);

        public abstract Task<bool> Cancel(reserve reserve);
    }
}