using RetailPOS.CommonLayer.DataTransferObjects.Settings;

namespace RetailPOS.BusinessLayer.Service.Setting
{
    public interface ISettingService
    {
        /// <summary>
        /// Save Shop setting details in database
        /// </summary>
        /// <param name="shopSettingDetails">Shopsetting object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        bool SaveShopSetting(ShopSettingDTO shopSettingDetails);
    }
}