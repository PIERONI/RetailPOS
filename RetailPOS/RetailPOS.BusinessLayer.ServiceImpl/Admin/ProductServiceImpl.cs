using System.Collections.Generic;
using System.Linq;
using RetailPOS.BusinessLayer.Service.Admin;
using RetailPOS.CommonLayer.DataTransferObjects.Product;
using RetailPOS.CommonLayer.Mapper;

namespace RetailPOS.BusinessLayer.ServiceImpl.Admin
{
    public class ProductServiceImpl : AdminBaseService, IProductService
    {
        /// <summary>
        /// Get Products By Category Id
        /// </summary>
        /// <param name="categoryId">Category Id to to search products</param>
        /// <returns>returns list of products by category</returns>
        IList<ProductDTO> IProductService.GetProductByCategory(int categoryId)
        {
            IList<ProductDTO> lstProducts = new List<ProductDTO>();
            ObjectMapper.Map(base.ProductRepository.GetList(item => item.category_id == categoryId).ToList(), lstProducts);
            return lstProducts;
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns>returns list of all products present in database</returns>
        IList<ProductDTO> IProductService.GetAllProducts()
        {
            IList<ProductDTO> lstProducts = new List<ProductDTO>();
            ObjectMapper.Map(base.ProductRepository.GetList(item => item.status_id == 1).ToList(), lstProducts);
            return lstProducts;
        }
    }
}