using MoteeQueso.BROCKER.Lodging.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Lodging.Core.Interfaces
{
    public interface ILodgingService
    {
        Task<Guid> Reserve(reserve reserve);

        Task<Guid> Cancel(reserve reserve);
    }
}