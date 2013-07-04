using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetailPOS.CommonLayer.DataTransferObjects.PromotionalOffer
{
   public  class PromotionalOfferDTO:BaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int PurchaseQuantity { get; set; }
        public int PurchaseQuantitymu { get; set; }
        public decimal OfferQuantity { get; set; }
        public int OfferQuantitymu { get; set; }
        public decimal OfferPercentage { get; set; }
    }
}
