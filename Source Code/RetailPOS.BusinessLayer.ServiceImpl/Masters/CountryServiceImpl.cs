#region Using directives

using System;
using System.Collections.Generic;
using RetailPOS.BusinessLayer.Service.Masters;
using RetailPOS.CommonLayer.DataTransferObjects.Master;
using RetailPOS.CommonLayer.Mapper;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Masters
{
    public partial class MasterServiceImpl : MasterBaseService, IMasterService
    {
        /// <summary>
        /// Retrieves available country details from database
        /// </summary>
        /// <returns>returns list of country else empty list</returns>
        IList<CountryDTO> IMasterService.GetCountryDetails()
        {
            IList<CountryDTO> lstCountry = new List<CountryDTO>();
            ObjectMapper.Map(base.CountryRepository.GetList(), lstCountry);
            return lstCountry;
        }
    }
}