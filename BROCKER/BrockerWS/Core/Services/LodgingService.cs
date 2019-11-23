using MoteeQueso.Providers.Lodging.Core.Factories;
using MoteeQueso.Providers.Lodging.Core.Interfaces;
using MoteeQueso.Providers.Lodging.Core.Providers;
using MoteeQueso.Providers.Lodging.Infraestructure.Entities;
using MoteeQueso.Providers.Lodging.Infraestructure.Enums;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.Providers.Lodging.Core.Services
{
    public class LodgingService : ILodgingService
    {
        public async Task<Guid> Cancel(reserve reserve)
        {
            ProviderFactory providerFactory = InstanceProviderLodging(reserve.integration_type_id);
            return await providerFactory.Cancel(reserve);
        }

        public async Task<Guid> Reserve(reserve reserve)
        {
            ProviderFactory providerFactory = InstanceProviderLodging(reserve.integration_type_id);
            return await providerFactory.Reserve(reserve);
        }

        private ProviderFactory InstanceProviderLodging(int integration_type_id)
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
                    throw new NotImplementedException("Not Implemented Integration For Provider Id: " + integration_type_id);
            }
        }
    }
}