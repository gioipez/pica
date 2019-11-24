using MoteeQueso.BROCKER.Transport.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Transport.Core.Factories
{
    public abstract class FTPFactory
    {
        public abstract Task<Guid> Reserve(reserve reserve);

        public abstract Task<Guid> Cancel(reserve reserve);
    }
}