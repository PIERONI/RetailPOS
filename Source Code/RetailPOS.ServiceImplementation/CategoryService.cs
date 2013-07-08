#region Using directives

using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.Category;

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
        public IList<ProductCategoryDTO> GetCategories()
        {
            return CategoryService.GetCategories();
        }

        /// <summary>
        /// Save Category details in database
        /// </summary>
        /// <param name="categoryDetails">Category details to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        public bool SaveCategoryDetails(ProductCategoryDTO categoryDetails)
        {
            return CategoryService.SaveCategoryDetails(categoryDetails);
        }

        #endregion
    }
}