#region Using directives

using System.Collections.Generic;
using System.Linq;
using RetailPOS.BusinessLayer.Service.Settings;
using RetailPOS.CommonLayer.DataTransferObjects.Settings;
using RetailPOS.CommonLayer.Mapper;
using RetailPOS.PersistenceLayer.Repository.Entities;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Settings
{
    public partial class SettingServiceImpl
    {
        /// <summary>
        /// Save Waste management details in database
        /// </summary>
        /// <param name="wasteManagementDetails">WasteManagement object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        bool ISettingService.SaveWasteManagement(WasteManagementDTO wasteManagementDetails)
        {
            wastemanagement wasteManagementEntity = new wastemanagement();
            ObjectMapper.Map(wasteManagementDetails, wasteManagementEntity);
            return WasteManagementRepository.Save(wasteManagementEntity);
        }

        /// <summary>
        /// Get waste management details from database
        /// </summary>
        /// <returns>returns list of Waste management details else empty list</returns>
        IList<WasteManagementDTO> ISettingService.GetWasteManagementDetails()
        {
            IList<WasteManagementDTO> lstWasteManagementDetails = new List<WasteManagementDTO>();
            ObjectMapper.Map(base.WasteManagementRepository.GetList().OrderByDescending(item => item.CreatedDate).ToList(), lstWasteManagementDetails);
            return lstWasteManagementDetails;
        }
    }
}