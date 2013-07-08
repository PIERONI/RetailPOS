#region Using directives

using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.Product;

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

        /// <summary>
        /// Get all Commonly Used Products
        /// </summary>
        /// <returns>returns list of all Commonly Used  products present in database</returns>
        public IList<ProductDTO> GetCommonProduct()
        {
            return ProductService.GetCommonProduct();
        }

        /// <summary>
        /// Get product status from database
        /// </summary>
        /// <returns>returns list of all status present in database for product, else empty list</returns>
        public IList<ProductStatusDTO> GetProductStatus()
        {
            return ProductService.GetProductStatus();
        }

        /// <summary>
        /// Save Product details in database
        /// </summary>
        /// <param name="productDetails">Product details to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        public bool SaveProductDetails(ProductDTO productDetails)
        {
            return ProductService.SaveProductDetails(productDetails);
        }

        #endregion
    }
}