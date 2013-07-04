using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.BusinessLayer.Service.PromotionalOffer;
using RetailPOS.CommonLayer.DataTransferObjects.PromotionalOffer;
using RetailPOS.CommonLayer.Mapper;

namespace RetailPOS.BusinessLayer.ServiceImpl.PromotionalOffer
{
    public class PromotionalOfferServiceImpl : PromotionalBaseService,IPromotionalOfferService
    {
        /// <summary>
        /// Get all promotional Offer
        /// </summary>
        /// <returns>returns list of all promotional Offer present in database</returns>    
        //IList<PromotionalOfferDTO> IPromotionalOfferService.GetPromotionalOfferDetail()
        //{
        //    //IList<PromotionalOfferDTO> lstPromotionalOffer = new List<PromotionalOfferDTO>();
        //    //ObjectMapper.Map(base.PromotionalOfferRepository.GetList(item => item.status_id == 10).ToList(), lstPromotionalOffer);
        //    //return lstPromotionalOffer;
        //}
    }
}
