using MoteeQueso.BROCKER.Lodging.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Lodging.Core.Factories
{
    public abstract class ProviderFactory
    {
        public abstract Task<Guid> Reserve(reserve reserve);

        public abstract Task<Guid> Cancel(reserve reserve);
    }
}