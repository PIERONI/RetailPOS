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
        /// Retrieves available Street details from database
        /// </summary>
        /// <returns>returns list of Streets else empty list</returns>
        IList<StreetDTO> IMasterService.GetStreetDetails(int localityId)
        {
            IList<StreetDTO> lstStreet = new List<StreetDTO>();
            ObjectMapper.Map(base.StreetRepository.GetList(item => item.LocalityId == localityId), lstStreet);
            return lstStreet;
        }
    }
}