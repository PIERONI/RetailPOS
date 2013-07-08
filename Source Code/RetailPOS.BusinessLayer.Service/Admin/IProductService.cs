#region Using directives

using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.Product;

#endregion

namespace RetailPOS.BusinessLayer.Service.Admin
{
    public interface IProductService
    {
        /// <summary>
        /// Get Products By Category Id
        /// </summary>
        /// <returns>returns list of products by category</returns>
        IList<ProductDTO> GetProductByCategory(int categoryId);

        /// <summary>
        /// Get all active Products
        /// </summary>
        /// <returns>returns list of all products present in database</returns>
        IList<ProductDTO> GetAllProducts();

        /// <summary>
        /// Get all Commonly Used Products
        /// </summary>
        /// <returns>returns list of all Commonly Used  products present in database</returns>
        IList<ProductDTO> GetCommonProduct();

        /// <summary>
        /// Get product status from database
        /// </summary>
        /// <returns>returns list of all status present in database for product, else empty list</returns>
        IList<ProductStatusDTO> GetProductStatus();

        /// <summary>
        /// Save Product details in database
        /// </summary>
        /// <param name="productDetails">Product details to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        bool SaveProductDetails(ProductDTO productDetails);
    }
}