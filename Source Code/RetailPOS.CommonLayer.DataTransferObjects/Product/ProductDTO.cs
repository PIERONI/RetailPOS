using System;

namespace RetailPOS.CommonLayer.DataTransferObjects.Product
{
    public class ProductDTO : BaseDTO
    {
        public int Id { get; set; }
        public Nullable<short> CategoryId { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public Nullable<Decimal> RetailPrice { get; set; }
        public Nullable<Decimal> WholesalePrice { get; set; }
        public Nullable<Decimal> PurchasePrice { get; set; }
        public Nullable<Decimal> TaxRate { get; set; }
        public Nullable<bool> HasWarranty { get; set; }
        public string ImagePath { get; set; }
        public Nullable<decimal> Size { get; set; }
        public Nullable<decimal> Weight { get; set; }
    }
}