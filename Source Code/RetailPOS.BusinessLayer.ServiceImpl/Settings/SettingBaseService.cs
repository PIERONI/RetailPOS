#region Using directives

using Microsoft.Practices.Unity;
using RetailPOS.PersistenceLayer.Repository.Entities;
using RetailPOS.PersistenceLayer.Repository.Interfaces;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Settings
{
    public class SettingBaseService
    {
        /// <summary>
        /// Property to inject the persistence layer implementation class for shop setting
        /// </summary>
        [Dependency]
        public IGenericRepository<shop_info> ShopSettingRepository { get; set; }

        /// <summary>
        /// Property to inject the persistence layer implementation class for promotional offers
        /// </summary>
        [Dependency]
        public IGenericRepository<promotional_offer> PromotionalOfferRepository { get; set; }

        /// <summary>
        /// Property to inject the persistence layer implementation class for waste management
        /// </summary>
        [Dependency]
        public IGenericRepository<WasteManagement> WasteManagementRepository { get; set; }

        [Dependency]
        public IGenericRepository<product_purchase_history_master> PurchaseHistoryRepository { get; set; }
    }
}