using MoteeQueso.BROCKER.Lodging.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Lodging.Core.Factories
{
    public abstract class WebServiceFactory
    {
        public abstract Task<bool> Reserve(reserve reserve);

        public abstract Task<bool> Cancel(reserve reserve);
    }
}