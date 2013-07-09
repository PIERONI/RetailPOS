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
        /// Retrieves available Measure unit details from database
        /// </summary>
        /// <returns>returns list of Measure unit else empty list</returns>
        IList<MeasureUnitDTO> IMasterService.GetMeasureUnitDetails()
        {
            IList<MeasureUnitDTO> lstMeasureUnit = new List<MeasureUnitDTO>();
            ObjectMapper.Map(base.MeasureUnitRepository.GetList(), lstMeasureUnit);
            return lstMeasureUnit;
        }
    }
}