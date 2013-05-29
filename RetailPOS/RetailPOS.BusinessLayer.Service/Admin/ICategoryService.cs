using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.CommonLayer.DataTransferObjects;

namespace RetailPOS.BusinessLayer.Service.Admin
{
    public interface ICategoryService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IList<ProductCategoryDTO> GetCategories();
    }
}