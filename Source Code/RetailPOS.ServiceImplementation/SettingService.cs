using RetailPOS.CommonLayer.DataTransferObjects.Settings;
using RetailPOS.CommonLayer.DataTransferObjects.Customer;

namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService
    {
        /// <summary>
        /// Save Shop setting details in database
        /// </summary>
        /// <param name="shopSettingDetails">Shopsetting object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        public bool SaveShopSetting(ShopSettingDTO shopSettingDetails)
        {
            return SettingService.SaveShopSetting(shopSettingDetails);
        }

        /// Save Customer details in database
        /// </summary>
        /// <param name="shopSettingDetails">Customer object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        /// <summary>
        public bool SaveCustomerDetail(CustomerDTO customerDetails)
        {
            return SettingService.SaveCustomerDetail(customerDetails);
        }

    }
}