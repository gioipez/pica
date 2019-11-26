using MoteeQueso.BROCKER.Lodging.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Lodging.Core.Interfaces
{
    public interface ILodgingService
    {
        Task<bool> Reserve(reserve reserve);

        Task<bool> Cancel(reserve reserve);
    }
}