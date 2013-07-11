using System;

namespace RetailPOS.CommonLayer.DataTransferObjects.Product
{
    public class ProductDTO : BaseDTO
    {
        public int Id { get; set; }
        public Nullable<short> Category_Id { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status_Id { get; set; }
        public Nullable<Decimal> Retail_Price { get; set; }
        public Nullable<Decimal> Wholesale_Price { get; set; }
        public Nullable<Decimal> PurchasePrice { get; set; }
        public Nullable<Decimal> Tax_Rate { get; set; }
        public Nullable<bool> Has_Warranty { get; set; }
        public string Image_Path { get; set; }
        public Nullable<decimal> Size { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public decimal Quantity { get; set; }
        public decimal? Amount { get; set; }
        public bool IsSelected { get; set; }
    }
}