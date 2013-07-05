using System;

namespace RetailPOS.CommonLayer.DataTransferObjects.PromotionalOffer
{
   public  class PromotionalOfferDTO:BaseDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public int Purchase_Quantity { get; set; }
        public int pqty_mu { get; set; }
        public Nullable<decimal> offer_quantity { get; set; }
        public int oqty_mu { get; set; }
        public Nullable<decimal> offer_percentage { get; set; }
        public double Duration { get; set; }
    }
}