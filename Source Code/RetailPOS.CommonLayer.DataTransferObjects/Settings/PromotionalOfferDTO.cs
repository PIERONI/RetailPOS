#region Using directives

using System;
using RetailPOS.CommonLayer.DataTransferObjects.Master;

#endregion

namespace RetailPOS.CommonLayer.DataTransferObjects.Settings
{
    public class PromotionalOfferDTO : BaseDTO
    {
        #region Primitive Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string DateDuration { get; set; }
        public int Purchase_Quantity { get; set; }
        public int Pqty_Mu { get; set; }
        public MeasureUnitDTO Measure_Unit1 { get; set; }
        public string PurchaseQuantityWithUnit { get; set; }
        public Nullable<decimal> Offer_Quantity { get; set; }
        public string OfferQuantityWithUnit { get; set; }
        public Nullable<short> Oqty_Mu { get; set; }
        public MeasureUnitDTO Measure_Unit { get; set; }
        public Nullable<decimal> Offer_Percentage { get; set; }
        public double Duration { get; set; }

        #endregion
    }
}