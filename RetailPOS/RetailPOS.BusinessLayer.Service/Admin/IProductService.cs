using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.CommonLayer.DataTransferObjects;

namespace RetailPOS.BusinessLayer.Service.Admin
{
    public interface IProductService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IList<ProductDTO> GetProductByCategory(int categoryId);
    }
}