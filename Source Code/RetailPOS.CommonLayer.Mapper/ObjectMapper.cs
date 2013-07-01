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
using RetailPOS.CommonLayer.DataTransferObjects.Master;

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

            CreateMapObjectForMasters();
        }

        #region Map Object

        public static void Map<T, U>(T sourceObject, U destObject)
        {
            AutoMapper.Mapper.Map(sourceObject, destObject);
        }

        private void CreateMapObjectForMasters()
        {
            ////Maps CountryDTO object with country object
            AutoMapper.Mapper.CreateMap<country, CountryDTO>();
            AutoMapper.Mapper.CreateMap<CountryDTO, country>();

            ////Maps TownCityDTO object with town_city object
            AutoMapper.Mapper.CreateMap<town_city, TownCityDTO>();
            AutoMapper.Mapper.CreateMap<TownCityDTO, town_city>();
        }

        #endregion
    }
}