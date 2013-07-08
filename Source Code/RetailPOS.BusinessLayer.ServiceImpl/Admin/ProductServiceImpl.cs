#region Using directives

using System.Collections.Generic;
using System.Linq;
using RetailPOS.BusinessLayer.Service.Admin;
using RetailPOS.CommonLayer.DataTransferObjects.Product;
using RetailPOS.CommonLayer.Mapper;
using RetailPOS.PersistenceLayer.Repository.Entities;

#endregion

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

        /// <summary>
        /// Get all Commonly Used Products
        /// </summary>
        /// <returns>returns list of all Commonly Used  products present in database</returns>
        IList<ProductDTO> IProductService.GetCommonProduct()
        {
            IList<ProductDTO> lstProducts = new List<ProductDTO>();

            ObjectMapper.Map(base.ProductRepository.GetList(item => item.status_id == 7).ToList(), lstProducts);
            return lstProducts;
        }

        /// <summary>
        /// Get product status from database
        /// </summary>
        /// <returns>returns list of all status present in database for product, else empty list</returns>
        IList<ProductStatusDTO> IProductService.GetProductStatus()
        {
            IList<ProductStatusDTO> lstProductStatus = new List<ProductStatusDTO>();

            ObjectMapper.Map(base.ProductStatusRepository.GetList().ToList(), lstProductStatus);
            return lstProductStatus;
        }

        /// <summary>
        /// Save Product details in database
        /// </summary>
        /// <param name="productDetails">Product details to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        bool IProductService.SaveProductDetails(ProductDTO productDetails)
        {
            product productEntity = new product();

            ObjectMapper.Map(productDetails, productEntity);
            return ProductRepository.Save(productEntity);
        }
    }
}