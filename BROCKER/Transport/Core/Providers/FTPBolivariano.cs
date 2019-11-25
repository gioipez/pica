using MoteeQueso.BROCKER.Transport.Core.Factories;
using MoteeQueso.BROCKER.Transport.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Transport.Core.Providers
{
    public class FTPBolivariano : FTPFactory
    {
        public override Task<bool> Cancel(reserve reserve)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Reserve(reserve reserve)
        {
            throw new NotImplementedException();
        }
    }
}