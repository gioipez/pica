using MoteeQueso.BROCKER.Transport.Core.Factories;
using MoteeQueso.BROCKER.Transport.Core.Interfaces;
using MoteeQueso.BROCKER.Transport.Core.Providers;
using MoteeQueso.BROCKER.Transport.Infraestructure.Entities;
using MoteeQueso.BROCKER.Transport.Infraestructure.Enums;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Transport.Core.Services
{
    public class TransportService : ITransportService
    {
        public async Task<bool> Cancel(reserve reserve)
        {
            ProviderFactory providerFactory = InstanceProviderFactory(reserve.integration_type_id);
            return await providerFactory.Cancel(reserve);
        }

        public async Task<bool> Reserve(reserve reserve)
        {
            ProviderFactory providerFactory = InstanceProviderFactory(reserve.integration_type_id);
            return await providerFactory.Reserve(reserve);
        }

        private ProviderFactory InstanceProviderFactory(int integration_type_id)
        {
            switch ((integration_type)integration_type_id)
            {
                case integration_type.FTP:
                    return new ProviderFTP();
                case integration_type.DataBase:
                    return new ProviderDataBase();
                case integration_type.WebService:
                    return new ProviderWebService();
                default:
                    throw new NotImplementedException("Not Implemented Integration For Integration Type Id: " + integration_type_id);
            }
        }
    }
}