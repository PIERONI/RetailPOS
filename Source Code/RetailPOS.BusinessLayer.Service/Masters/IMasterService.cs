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
        IList<TownCityDTO> GetTownCityDetail(int countryID);


        /// <summary>
        /// Retrieves available PostalCode details from database
        /// </summary>
        /// <returns>returns list of PostalCode else empty list</returns>
        IList<PostCodeDTO> GetPostalCodeDetail(int towncityID);                    

    }
}