#region Using directives

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
            WasteManagement wasteManagementEntity = new WasteManagement();
            ObjectMapper.Map(wasteManagementDetails, wasteManagementEntity);
            return WasteManagementRepository.Save(wasteManagementEntity);
        }
    }
}