#region Using directives

using System.Collections.Generic;
using System.Linq;
using RetailPOS.BusinessLayer.Service.Setting;
using RetailPOS.BusinessLayer.ServiceImpl.Setting;
using RetailPOS.CommonLayer.CommonLibrary;
using RetailPOS.CommonLayer.DataTransferObjects.PromotionalOffer;
using RetailPOS.CommonLayer.Mapper;
using RetailPOS.PersistenceLayer.Repository.Entities;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Setting
{
    public partial class SettingServiceImpl
    {
        /// <summary>        
        /// Retrieves available PromotionalOffer details from database
        /// </summary>         
        ///<returns>returns list of all promotional Offer present in database</returns>    
        IList<PromotionalOfferDTO> ISettingService.GetPromotionalOfferDetail()
        {
            IList<PromotionalOfferDTO> lstPromotionalOffer = new List<PromotionalOfferDTO>();
            ObjectMapper.Map(base.PromotionalOfferRepository.GetList().ToList(), lstPromotionalOffer);
            return lstPromotionalOffer;
        } 
        
        /// <summary>
        /// Save Promotional offer details in database
        /// </summary>
        /// <param name="promitonalOfferDetails">Promotional offer object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        bool ISettingService.SavePromotionalOffer(PromotionalOfferDTO promotionalOfferDetails)
        {
            promotional_offer promotionalOfferEntity = new promotional_offer();
            ObjectMapper.Map(promotionalOfferDetails, promotionalOfferEntity);
            return PromotionalOfferRepository.Save(promotionalOfferEntity);
        }
    }
}