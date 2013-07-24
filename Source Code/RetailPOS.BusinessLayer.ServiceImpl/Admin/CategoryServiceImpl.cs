#region Using directives

using System.Collections.Generic;
using System.Linq;
using RetailPOS.BusinessLayer.Service.Admin;
using RetailPOS.CommonLayer.DataTransferObjects.Category;
using RetailPOS.CommonLayer.Mapper;
using RetailPOS.PersistenceLayer.Repository.Entities;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Admin
{
    public class CategoryServiceImpl : AdminBaseService, ICategoryService
    {
        /// <summary>
        /// Get Categories from database
        /// </summary>
        /// <returns>returns list of product categories</returns>
        IList<ProductCategoryDTO> ICategoryService.GetCategories()
        {
            IList<ProductCategoryDTO> lstCategories = new List<ProductCategoryDTO>();
            ObjectMapper.Map(base.CategoryRepository.GetList().ToList().OrderBy(item => item.name), lstCategories);
            return lstCategories;
        }

        /// <summary>
        /// Save Category details in database
        /// </summary>
        /// <param name="categoryDetails">Category details to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        bool ICategoryService.SaveCategoryDetails(ProductCategoryDTO categoryDetails)
        {
            product_category categoryEntity = new product_category();

            ObjectMapper.Map(categoryDetails, categoryEntity);
            return CategoryRepository.Save(categoryEntity);
        }
    }
}