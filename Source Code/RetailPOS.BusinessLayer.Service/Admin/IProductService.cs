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
    }
}