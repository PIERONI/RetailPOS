#region Using directives

using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.Master;

#endregion

namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService
    {
        /// <summary>
        /// Retrieves available country details from database
        /// </summary>
        /// <returns>returns list of country else empty list</returns>
        public IList<CountryDTO> GetCountryDetails()
        {
            return MasterService.GetCountryDetails();
        }

        /// <summary>
        /// Retrieves available TownCity details from database
        /// </summary>
        /// <returns>returns list of TownCity else empty list</returns>
        public IList<TownCityDTO> GetTownCityDetails(int countryId)
        {
            return MasterService.GetTownCityDetails(countryId);
        }

        /// <summary>
        /// Retrieves available TownCity details from database
        /// </summary>
        /// <returns>returns list of TownCity else empty list</returns>
        public IList<LocalityDTO> GetLocalityDetails(int localityId)
        {
            return MasterService.GetLocalityDetails(localityId);
        }

        /// <summary>
        /// Retrieves available TownCity details from database
        /// </summary>
        /// <returns>returns list of TownCity else empty list</returns>
        public IList<StreetDTO> GetStreetDetails(int localityId)
        {
            return MasterService.GetStreetDetails(localityId);
        }

        /// <summary>
        /// Retrieves available Postalcode details from database
        /// </summary>
        /// <returns>returns list of Postalcode else empty list</returns>
        public IList<PostCodeDTO> GetPostalCodeDetails(int localityId)
        {
            return MasterService.GetPostalCodeDetails(localityId);
        }
    }
}