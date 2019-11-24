using MoteeQueso.BROCKER.Transport.Core.Factories;
using MoteeQueso.BROCKER.Transport.Infraestructure.Entities;
using MoteeQueso.BROCKER.Transport.Infraestructure.Enums;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Transport.Core.Providers
{
    public class ProviderFTP : ProviderFactory
    {
        public override async Task<Guid> Cancel(reserve reserve)
        {
            throw new NotImplementedException();
        }

        public override async Task<Guid> Reserve(reserve reserve)
        {
            FTPFactory fTPFactory = InstanceFTPFactory(reserve.provider_id);
            return await fTPFactory.Reserve(reserve);
        }

        private FTPFactory InstanceFTPFactory(int provider_id)
        {
            switch ((provider)provider_id)
            {
                case provider.Bolivariano:
                    return new FTPBolivariano();
                default:
                    throw new NotImplementedException("Not Implemented Integration For Provider Id: " + provider_id);
            }
        }
    }
}