using MoteeQueso.BROCKER.Transport.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Transport.Core.Interfaces
{
    public interface ITransportService
    {
        Task<bool> Reserve(reserve reserve);

        Task<bool> Cancel(reserve reserve);
    }
}