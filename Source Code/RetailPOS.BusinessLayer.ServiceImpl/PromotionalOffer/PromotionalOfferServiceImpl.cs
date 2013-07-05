#region Using directives

using System.Collections.Generic;
using System.Linq;
using RetailPOS.BusinessLayer.Service.PromotionalOffer;
using RetailPOS.CommonLayer.DataTransferObjects.PromotionalOffer;
using RetailPOS.CommonLayer.Mapper;
using RetailPOS.PersistenceLayer.Repository.Entities;
using System.Data.Objects;
using RetailPOS.CommonLayer.CommonLibrary;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.PromotionalOffer
{
    public partial  class PromotionalOfferServiceImpl : PromotionalBaseService, IPromotionalOfferService
    {
        /// <summary>        /// Retrieves available PromotionalOffer details from database
        /// </summary>         
        ///<returns>returns list of all promotional Offer present in database</returns>    
        IList<PromotionalOfferDTO> IPromotionalOfferService.GetPromotionalOfferDetail()
        {
            IList<PromotionalOfferDTO> lstPromotionalOffer = new List<PromotionalOfferDTO>();

            lstPromotionalOffer = (from item in base.PromotionalOfferRepository.GetList()
                                   select new PromotionalOfferDTO
                                   {
                                       Id = item.id,
                                       Name = item.name,
                                       Start_Date=item.start_date,
                                       End_Date = item.end_date,
                                       Purchase_Quantity =item.purchase_quantity,
                                       offer_quantity=item.offer_quantity,
                                       offer_percentage=item.offer_percentage
                                   }).ToList();

            (from item in lstPromotionalOffer select item).Update(
                item => item.Duration = item.End_Date.Subtract(item.Start_Date).TotalDays);
          
            return lstPromotionalOffer;
        }
    }
}