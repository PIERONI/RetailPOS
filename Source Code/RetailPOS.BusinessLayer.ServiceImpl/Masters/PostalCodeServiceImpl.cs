using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.CommonLayer.DataTransferObjects.Master;
using RetailPOS.BusinessLayer.Service.Masters;
using RetailPOS.CommonLayer.Mapper;

namespace RetailPOS.BusinessLayer.ServiceImpl.Masters
{
    public partial class MasterServiceImpl
    {
        /// <summary>
        /// Retrieves available PostalCode details from database
        /// </summary>
        /// <returns>returns list of PostalCode else empty list</returns>

        IList<PostCodeDTO> IMasterService.GetPostalCodeDetail(int towncityID)
        {
            IList<PostCodeDTO> lstPostCode = new List<PostCodeDTO>();
            ObjectMapper.Map(base.PostalCodeRepositoer.GetList(item => item.towncityid == towncityID), lstPostCode);
            return lstPostCode;
        }
    }
}
