using System;
using RetailPOS.CommonLayer.DataTransferObjects.Product;

namespace RetailPOS.CommonLayer.DataTransferObjects.Order
{
    public class OrderChildDTO : BaseDTO
    {
        #region Primitive Properties

        public long Order_Id { get; set; }
        public short Product_Id { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public short Measure_Unit_Id { get; set; }
        public decimal Amount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public int Taxed { get; set; }
       // public Nullable<int> Discount { get; set; }
        public Nullable<decimal> Retail_price { get; set; }
        #endregion

        #region Navigational Properties

        private ProductDTO _product;

        public ProductDTO product
        {
            get { return _product; }
            set
            {
                if (!ReferenceEquals(_product, value))
                {
                    var previousValue = _product;
                    _product = null;
                    ProductName = value.Name;
                }
            }
        }

        #endregion
    }
}