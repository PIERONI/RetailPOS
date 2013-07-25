#region Using directives

using System;
using RetailPOS.CommonLayer.DataTransferObjects.Product;

#endregion

namespace RetailPOS.CommonLayer.DataTransferObjects.Settings
{
    public class WasteManagementDTO : BaseDTO
    {
        #region Primitive Properties

        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public DateTime CreatedDate { get; set; }

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