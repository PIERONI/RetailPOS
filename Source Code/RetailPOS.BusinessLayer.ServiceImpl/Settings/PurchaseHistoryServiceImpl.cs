#region Using directives

using System.Collections.Generic;
using System.Linq;
using RetailPOS.BusinessLayer.Service.Settings;
using RetailPOS.CommonLayer.DataTransferObjects.Settings;
using RetailPOS.CommonLayer.Mapper;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Settings
{
    public partial class SettingServiceImpl
    {
        /// <summary>
        /// Retrieves available Purchase History details from database
        /// </summary>
        /// <returns>returns list of Purchase History else empty list</returns>
        IList<PurchaseHistoryDTO> ISettingService.GetPurchaseHistoryDetails()
        {
            IList<PurchaseHistoryDTO> lstPurchaseHistory = new List<PurchaseHistoryDTO>();
            ObjectMapper.Map(base.PurchaseHistoryRepository.GetList().OrderByDescending(item => item.purchase_date).ToList(), lstPurchaseHistory);
            return lstPurchaseHistory;
        }
    }
}