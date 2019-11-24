using MoteeQueso.BROCKER.Transport.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Transport.Core.Interfaces
{
    public interface ITransportService
    {
        Task<Guid> Reserve(reserve reserve);

        Task<Guid> Cancel(reserve reserve);
    }
}