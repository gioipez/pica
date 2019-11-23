using MoteeQueso.Providers.Lodging.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.Providers.Lodging.Core.Interfaces
{
    public interface ILodgingService
    {
        Task<Guid> Reserve(reserve reserve);

        Task<Guid> Cancel(reserve reserve);
    }
}