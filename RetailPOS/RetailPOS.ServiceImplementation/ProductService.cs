#region Using directives

using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects;

#endregion

namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService
    {
        #region Public Methods

        /// <summary>
        /// Products: This service implementation class is used to get the product list by category from repository
        /// </summary>
        /// <returns>return list of product by category</returns>
        /// <remarks></remarks>
        public IList<ProductDTO> GetProductByCategory(int categoryId)
        {
            return ProductService.GetProductByCategory(categoryId);
        }

        /// <summary>
        /// Products: This service implementation class is used to get all products from repository
        /// </summary>
        /// <returns>returns list of all products present in database</returns>
        public IList<ProductDTO> GetAllProducts()
        {
            return ProductService.GetAllProducts();
        }

        #endregion
    }
}