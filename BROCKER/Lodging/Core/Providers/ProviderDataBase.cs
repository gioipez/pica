using MoteeQueso.BROCKER.Lodging.Core.Factories;
using MoteeQueso.BROCKER.Lodging.Infraestructure.Entities;
using MoteeQueso.BROCKER.Lodging.Infraestructure.Enums;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Lodging.Core.Providers
{
    public class ProviderDataBase : ProviderFactory
    {
        public override async Task<Guid> Cancel(reserve reserve)
        {
            DataBaseFactory dataBaseFactory = InstanceDataBaseFactory(reserve.provider_id);
            return await dataBaseFactory.Cancel(reserve);
        }

        public override async Task<Guid> Reserve(reserve reserve)
        {
            DataBaseFactory dataBaseFactory = InstanceDataBaseFactory(reserve.provider_id);
            return await dataBaseFactory.Reserve(reserve);
        }

        private DataBaseFactory InstanceDataBaseFactory(int provider_id)
        {
            switch ((provider)provider_id)
            {
                case provider.DanCarlton:
                    return new DataBaseDanCarlton();
                default:
                    throw new NotImplementedException("Not Implemented Integration For Provider Id: " + provider_id);
            }
        }
    }
}