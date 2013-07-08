using RetailPOS.BusinessLayer.Service.Setting;
using RetailPOS.CommonLayer.DataTransferObjects.Settings;
using RetailPOS.CommonLayer.Mapper;
using RetailPOS.PersistenceLayer.Repository.Entities;
using RetailPOS.CommonLayer.DataTransferObjects.Customer;

namespace RetailPOS.BusinessLayer.ServiceImpl.Setting
{
    public partial class SettingServiceImpl : SettingBaseService, ISettingService
    {
        /// <summary>
        /// Save Shop setting details in database
        /// </summary>
        /// <param name="shopSettingDetails">Shopsetting object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        bool ISettingService.SaveShopSetting(ShopSettingDTO shopSettingDetails)
        {
            shop_info shopSettingEntity = new shop_info();
            ObjectMapper.Map(shopSettingDetails, shopSettingEntity);
            return ShopSettingRepository.Save(shopSettingEntity);
        }

       
    }
}