#region Using directives

using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.Master;

#endregion

namespace RetailPOS.BusinessLayer.Service.Masters
{
    public interface IMasterService
    {
        /// <summary>
        /// Retrieves available country details from database
        /// </summary>
        /// <returns>returns list of country else empty list</returns>
        IList<CountryDTO> GetCountryDetails();

        /// <summary>
        /// Retrieves available Town/City details from database
        /// </summary>
        /// <returns>returns list of Town/City else empty list</returns>
        IList<TownCityDTO> GetTownCityDetails(int countryId);

        /// <summary>
        /// Retrieves available Locality details from database
        /// </summary>
        /// <returns>returns list of Locality else empty list</returns>
        IList<LocalityDTO> GetLocalityDetails(int townCityId);

        /// <summary>
        /// Retrieves available Streets details from database
        /// </summary>
        /// <returns>returns list of Locality else empty list</returns>
        IList<StreetDTO> GetStreetDetails(int localityId);

        /// <summary>
        /// Retrieves available PostalCode details from database
        /// </summary>
        /// <returns>returns list of PostalCode else empty list</returns>
        IList<PostCodeDTO> GetPostalCodeDetails(int localityId);
    }
}