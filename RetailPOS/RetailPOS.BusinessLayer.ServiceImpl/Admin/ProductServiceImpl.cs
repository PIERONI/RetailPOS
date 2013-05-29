using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.BusinessLayer.Service.Admin;
using RetailPOS.CommonLayer.DataTransferObjects;
using RetailPOS.CommonLayer.Mapper;

namespace RetailPOS.BusinessLayer.ServiceImpl.Admin
{
    public class ProductServiceImpl : AdminBaseService, IProductService
    {
        IList<ProductDTO> IProductService.GetProductByCategory(int categoryId)
        {
            IList<ProductDTO> lstProducts = new List<ProductDTO>();
            ObjectMapper.Map(base.ProductRepository.GetList(item => item.category_id == categoryId).ToList(), lstProducts);
            return lstProducts;
        }
    }
}