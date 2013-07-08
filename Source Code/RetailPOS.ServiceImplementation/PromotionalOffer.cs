using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.CommonLayer.DataTransferObjects.PromotionalOffer;

namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService
    {
        #region Public Methods

        /// <summary>
        /// Products: This service implementation class is used to get the promoional offert list  from repository
        /// </summary>
        /// <returns>return list of promotionaloffer</returns>
        /// <remarks></remarks>
        public IList<PromotionalOfferDTO> GetPromotionalOfferDetail()
        {
            return PromotionalOfferService.GetPromotionalOfferDetail();
        }

        #endregion
    }
}