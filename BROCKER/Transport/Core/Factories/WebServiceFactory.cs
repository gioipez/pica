using MoteeQueso.BROCKER.Transport.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Transport.Core.Factories
{
    public abstract class WebServiceFactory
    {
        public abstract Task<Guid> Reserve(reserve reserve);

        public abstract Task<Guid> Cancel(reserve reserve);
    }
}