#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.CommonLayer.DataTransferObjects.PromotionalOffer;
#endregion

namespace RetailPOS.BusinessLayer.Service.PromotionalOffer
{
    public interface IPromotionalOfferService
    {
        /// <summary>
        /// Retrieves available PromotionalOffer details from database
        /// </summary>
        /// <returns>returns list of PromotioanlOffer else empty list</returns>
        IList<PromotionalOfferDTO> GetPromotionalOfferDetail();
    }
}