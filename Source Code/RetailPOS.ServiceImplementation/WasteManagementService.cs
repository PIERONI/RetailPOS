#region Using directives

using RetailPOS.CommonLayer.DataTransferObjects.Settings;

#endregion

namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService
    {
        #region Public Methods

        /// <summary>
        /// Save Waste Management details in database
        /// </summary>
        /// <param name="wasteManagementDetails">Waste management object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        public bool SaveWasteManagement(WasteManagementDTO wasteManagementDetails)
        {
            return SettingService.SaveWasteManagement(wasteManagementDetails);
        }

        #endregion
    }
}