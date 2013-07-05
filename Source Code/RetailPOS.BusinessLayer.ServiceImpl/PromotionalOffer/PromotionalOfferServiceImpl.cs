#region Using directives

using System.Collections.Generic;
using System.Linq;
using RetailPOS.BusinessLayer.Service.PromotionalOffer;
using RetailPOS.CommonLayer.DataTransferObjects.PromotionalOffer;
using RetailPOS.CommonLayer.Mapper;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.PromotionalOffer
{
    public class PromotionalOfferServiceImpl : PromotionalBaseService, IPromotionalOfferService
    {
        /// <summary>
        /// Retrieves available PromotionalOffer details from database
        /// </summary>         
        ///<returns>returns list of all promotional Offer present in database</returns>    
        IList<PromotionalOfferDTO> IPromotionalOfferService.GetPromotionalOfferDetail()
        {
            IList<PromotionalOfferDTO> lstPromotionalOffer = new List<PromotionalOfferDTO>();
            ObjectMapper.Map(base.PromotionalOfferRepository.GetList().ToList(), lstPromotionalOffer);

            return lstPromotionalOffer;
        }
    }
}