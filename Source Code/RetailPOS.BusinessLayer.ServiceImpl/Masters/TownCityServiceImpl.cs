using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.BusinessLayer.Service.Masters;
using RetailPOS.CommonLayer.DataTransferObjects.Master;
using RetailPOS.CommonLayer.Mapper;

namespace RetailPOS.BusinessLayer.ServiceImpl.Masters
{
    public partial class MasterServiceImpl
    {
        /// <summary>
        /// Retrieves available Town/City details from database
        /// </summary>
        /// <returns>returns list of Town/City else empty list</returns>

        IList<TownCityDTO> IMasterService.GetTownCityDetail(int countryID)
        {
            IList<TownCityDTO> lstTownCity = new List<TownCityDTO>();
            ObjectMapper.Map(base.TownCityRepository.GetList(item => item.CountryID == countryID), lstTownCity);
            return lstTownCity;
        }
    }
}