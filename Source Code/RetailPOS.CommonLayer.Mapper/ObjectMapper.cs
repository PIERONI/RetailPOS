// -----------------------------------------------------------------------
// <copyright file="ObjectMapper.cs" company="IndicInfo India Pvt Ltd">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

#region Using directives

using RetailPOS.CommonLayer.DataTransferObjects.Category;
using RetailPOS.CommonLayer.DataTransferObjects.Customer;
using RetailPOS.CommonLayer.DataTransferObjects.Product;
using RetailPOS.CommonLayer.DataTransferObjects.User;
using RetailPOS.PersistenceLayer.Repository.Entities;
using RetailPOS.CommonLayer.DataTransferObjects.Settings;

#endregion

namespace RetailPOS.CommonLayer.Mapper
{
    public class ObjectMapper : IObjectMapper
    {
        public void CreateMap()
        {
            AutoMapper.Mapper.CreateMap<ProductCategoryDTO, product_category>();
            AutoMapper.Mapper.CreateMap<product_category, ProductCategoryDTO>();

            AutoMapper.Mapper.CreateMap<product, ProductDTO>();
            AutoMapper.Mapper.CreateMap<ProductDTO, product>();

            AutoMapper.Mapper.CreateMap<staff, StaffDTO>();
            AutoMapper.Mapper.CreateMap<StaffDTO, staff>();

            AutoMapper.Mapper.CreateMap<customer, CustomerDTO>();
            AutoMapper.Mapper.CreateMap<CustomerDTO, customer>();

            ////Maps ShopSetting object with shop_info object
            AutoMapper.Mapper.CreateMap<shop_info, ShopSettingDTO>();
            AutoMapper.Mapper.CreateMap<ShopSettingDTO, shop_info>();
        }

        #region Map Object

        public static void Map<T, U>(T sourceObject, U destObject)
        {
            AutoMapper.Mapper.Map(sourceObject, destObject);
        }

        #endregion
    }
}