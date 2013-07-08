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
        /// Retrieves available PostalCode details from database
        /// </summary>
        /// <returns>returns list of PostalCode else empty list</returns>
        IList<PostCodeDTO> IMasterService.GetPostalCodeDetails(int localityId)
        {
            IList<PostCodeDTO> lstPostCode = new List<PostCodeDTO>();
            ObjectMapper.Map(base.PostalCodeRepository.GetList(item => item.LocalityId == localityId), lstPostCode);
            return lstPostCode;
        }
    }
}