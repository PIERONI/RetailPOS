#region Using directives

using System.Collections.Generic;
using System.Linq;
using RetailPOS.BusinessLayer.Service.Setting;
using RetailPOS.BusinessLayer.ServiceImpl.Setting;
using RetailPOS.CommonLayer.CommonLibrary;
using RetailPOS.CommonLayer.DataTransferObjects.PromotionalOffer;
using RetailPOS.CommonLayer.Mapper;

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
            ObjectMapper.Map(base.PromotionalOfferRepository.GetList(), lstPromotionalOffer);

            (from item in lstPromotionalOffer select item).Update(
                item => item.Duration = item.End_Date.Subtract(item.Start_Date).TotalDays);
            
            return lstPromotionalOffer;
        } 

        /// <summary>
        /// Get all promotional Offer
        /// </summary>
        /// <returns>returns list of all promotional Offer present in database</returns>    
        //IList<PromotionalOfferDTO> IPromotionalOfferService.GetPromotionalOfferDetail()
        //{
        //    IList<PromotionalOfferDTO> lstPromotionalOffer = new List<PromotionalOfferDTO>();
        //    ObjectMapper.Map(base.PromotionalOfferRepository.GetList().ToList(), lstPromotionalOffer);
        //   
        //}
    }
}