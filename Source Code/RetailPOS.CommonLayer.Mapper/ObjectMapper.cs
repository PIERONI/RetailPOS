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
using RetailPOS.CommonLayer.DataTransferObjects.PromotionalOffer;

#endregion

namespace RetailPOS.CommonLayer.Mapper
{
    public class ObjectMapper : IObjectMapper
    {
        public void CreateMap()
        {
            AutoMapper.Mapper.CreateMap<ProductCategoryDTO, product_category>();
            AutoMapper.Mapper.CreateMap<product_category, ProductCategoryDTO>();

            MapObjectForProducts();

            AutoMapper.Mapper.CreateMap<staff, StaffDTO>();
            AutoMapper.Mapper.CreateMap<StaffDTO, staff>();

            MapObjectForCustomers();

            MapObjectForSettings();

            MapObjectForMasters();
        }

        #region Map Object

        public static void Map<T, U>(T sourceObject, U destObject)
        {
            AutoMapper.Mapper.Map(sourceObject, destObject);
        }

        private void MapObjectForProducts()
        {
            ////Maps ProductDTO object with product object
            AutoMapper.Mapper.CreateMap<product, ProductDTO>();
            AutoMapper.Mapper.CreateMap<ProductDTO, product>();

            ////Maps ProductStatusDTO object with product_status object
            AutoMapper.Mapper.CreateMap<product_status, ProductStatusDTO>();
            AutoMapper.Mapper.CreateMap<ProductStatusDTO, product_status>();
        }

        private void MapObjectForSettings()
        {
            ////Maps ShopSetting object with shop_info object
            AutoMapper.Mapper.CreateMap<shop_info, ShopSettingDTO>();
            AutoMapper.Mapper.CreateMap<ShopSettingDTO, shop_info>();

            //Maps PromotionalOffer object with promotioal_offer object
            AutoMapper.Mapper.CreateMap<promotional_offer, PromotionalOfferDTO>();
            AutoMapper.Mapper.CreateMap<PromotionalOfferDTO, promotional_offer>();

            //Maps WasteManagement object with WasteManagementDTO object
            AutoMapper.Mapper.CreateMap<WasteManagement, WasteManagementDTO>();
            AutoMapper.Mapper.CreateMap<WasteManagementDTO, WasteManagement>();
        }

        private void MapObjectForCustomers()
        {
            AutoMapper.Mapper.CreateMap<customer, CustomerDTO>();
            AutoMapper.Mapper.CreateMap<CustomerDTO, customer>();

            AutoMapper.Mapper.CreateMap<customer_status, CustomerStatusDTO>();
            AutoMapper.Mapper.CreateMap<CustomerStatusDTO, customer_status>();

            AutoMapper.Mapper.CreateMap<customer_type, CustomerTypeDTO>();
            AutoMapper.Mapper.CreateMap<CustomerTypeDTO, customer_type>();

        }

        private void MapObjectForMasters()
        {
            ////Maps CountryDTO object with country object
            AutoMapper.Mapper.CreateMap<country, CountryDTO>();
            AutoMapper.Mapper.CreateMap<CountryDTO, country>();

            ////Maps TownCityDTO object with town_city object
            AutoMapper.Mapper.CreateMap<town_city, TownCityDTO>();
            AutoMapper.Mapper.CreateMap<TownCityDTO, town_city>();

            ////Maps TownCityDTO object with town_city object
            AutoMapper.Mapper.CreateMap<locality, LocalityDTO>();
            AutoMapper.Mapper.CreateMap<LocalityDTO, locality>();

            ////Maps TownCityDTO object with town_city object
            AutoMapper.Mapper.CreateMap<street, StreetDTO>();
            AutoMapper.Mapper.CreateMap<StreetDTO, street>();

            ////Maps PostCodeDTO object with postcode object
            AutoMapper.Mapper.CreateMap<postcode, PostCodeDTO>();
            AutoMapper.Mapper.CreateMap<PostCodeDTO, postcode>();

            ////Maps PostCodeDTO object with address object
            AutoMapper.Mapper.CreateMap<address, AddressDTO>();
            AutoMapper.Mapper.CreateMap<AddressDTO, address>();

            ////Maps PostCodeDTO object with address object
            AutoMapper.Mapper.CreateMap<measure_unit, MeasureUnitDTO>();
            AutoMapper.Mapper.CreateMap<MeasureUnitDTO, measure_unit>();
        }

        #endregion
    }
}