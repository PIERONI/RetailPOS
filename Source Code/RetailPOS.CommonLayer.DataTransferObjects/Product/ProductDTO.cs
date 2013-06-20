using System;

namespace RetailPOS.CommonLayer.DataTransferObjects.Product
{
    public class ProductDTO : BaseDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public Decimal? RetailPrice { get; set; }
        public Decimal? WholesalePrice { get; set; }
        public Decimal? TaxRate { get; set; }
        public bool HasWarranty { get; set; }
        public string ImagePath { get; set; }
        public decimal Size { get; set; }
        public decimal Weight { get; set; }
        public string Color { get; set; }
    }
}