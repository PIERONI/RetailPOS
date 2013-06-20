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
    }
}