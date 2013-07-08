#region Using directives

using System.Collections.Generic;
using RetailPOS.BusinessLayer.Service.Masters;
using RetailPOS.CommonLayer.DataTransferObjects.Master;
using RetailPOS.CommonLayer.Mapper;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Masters
{
    public partial class MasterServiceImpl
    {
        /// <summary>
        /// Retrieves available Locality details from database
        /// </summary>
        /// <returns>returns list of Locality else empty list</returns>
        IList<LocalityDTO> IMasterService.GetLocalityDetails(int townCityId)
        {
            IList<LocalityDTO> lstTownCity = new List<LocalityDTO>();
            ObjectMapper.Map(base.LocalityRepository.GetList(item => item.TownCityId == townCityId), lstTownCity);
            return lstTownCity;
        }
    }
}