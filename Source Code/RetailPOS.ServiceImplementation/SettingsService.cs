using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.CommonLayer.DataTransferObjects.Settings;

namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService
    {
        #region Shop Settings

        /// <summary>
        /// Save Shop setting details in database
        /// </summary>
        /// <param name="shopSettingDetails">Shopsetting object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        public bool SaveShopSetting(ShopSettingDTO shopSettingDetails)
        {
            return SettingService.SaveShopSetting(shopSettingDetails);
        }

        #endregion

        #region Promotional Offer Settings

        /// <summary>
        /// Products: This service implementation class is used to get the promoional offert list  from repository
        /// </summary>
        /// <returns>return list of promotionaloffer</returns>
        /// <remarks></remarks>
        public IList<PromotionalOfferDTO> GetPromotionalOfferDetail()
        {
            return SettingService.GetPromotionalOfferDetail();
        }

        /// <summary>
        /// Save Promotional offer details in database
        /// </summary>
        /// <param name="promitonalOfferDetails">Promotional offer object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        public bool SavePromotionalOffer(PromotionalOfferDTO promotionalOfferDetails)
        {
            return SettingService.SavePromotionalOffer(promotionalOfferDetails);
        }

        #endregion

        #region Waste Management Settings

        /// <summary>
        /// Save Waste Management details in database
        /// </summary>
        /// <param name="wasteManagementDetails">Waste management object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        public bool SaveWasteManagement(WasteManagementDTO wasteManagementDetails)
        {
            return SettingService.SaveWasteManagement(wasteManagementDetails);
        }

        /// <summary>
        /// Get waste management details from database
        /// </summary>
        /// <returns>returns list of Waste management details else empty list</returns>
        public IList<WasteManagementDTO> GetWasteManagementDetails()
        {
            return SettingService.GetWasteManagementDetails();
        }

        #endregion

        #region Purchase History Settings

        /// <summary>
        /// Retrieves available Purchase History details from database
        /// </summary>
        /// <returns>returns list of Purchase History else empty list</returns>
        public IList<PurchaseHistoryDTO> GetPurchaseHistoryDetails()
        {
            return SettingService.GetPurchaseHistoryDetails();
        }

        #endregion
    }
}