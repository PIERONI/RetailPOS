#region Using directives

using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.Category;

#endregion

namespace RetailPOS.BusinessLayer.Service.Admin
{
    public interface ICategoryService
    {
        /// <summary>
        /// Get Categories from database 
        /// </summary>
        /// <returns>returns list of product categories</returns>
        IList<ProductCategoryDTO> GetCategories();

        /// <summary>
        /// Save Category details in database
        /// </summary>
        /// <param name="categoryDetails">Category details to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        bool SaveCategoryDetails(ProductCategoryDTO categoryDetails);
    }
}