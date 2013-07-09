#region Using directives

using Microsoft.Practices.Unity;
using RetailPOS.PersistenceLayer.Repository.Entities;
using RetailPOS.PersistenceLayer.Repository.Interfaces;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Masters
{
    public class MasterBaseService
    {
        [Dependency]
        public IGenericRepository<country> CountryRepository { get; set; }

        [Dependency]
        public IGenericRepository<town_city> TownCityRepository { get; set; }

        [Dependency]
        public IGenericRepository<locality> LocalityRepository { get; set; }

        [Dependency]
        public IGenericRepository<street> StreetRepository { get; set; }

        [Dependency]
        public IGenericRepository<postcode> PostalCodeRepository { get; set; }

        [Dependency]
        public IGenericRepository<measure_unit> MeasureUnitRepository { get; set; }
    }
}