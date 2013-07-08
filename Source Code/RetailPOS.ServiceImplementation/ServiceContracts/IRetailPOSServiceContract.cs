#region Using directives

using System.Collections.Generic;
using System.ServiceModel;
using RetailPOS.CommonLayer.DataTransferObjects.Category;
using RetailPOS.CommonLayer.DataTransferObjects.Customer;
using RetailPOS.CommonLayer.DataTransferObjects.Product;
using RetailPOS.CommonLayer.DataTransferObjects.User;
using RetailPOS.CommonLayer.DataTransferObjects.Settings;
using RetailPOS.CommonLayer.DataTransferObjects.Master;
using RetailPOS.CommonLayer.DataTransferObjects.PromotionalOffer;

#endregion

namespace RetailPOS.ServiceImplementation.ServiceContracts
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    interface IRetailPOSServiceContract
    {
        #region Categories

        [OperationContract]
        IList<ProductCategoryDTO> GetCategories();

        #endregion

        #region Products

        [OperationContract]
        IList<ProductDTO> GetProductByCategory(int categoryId);

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns>returns list of all products present in database</returns>
        [OperationContract]
        IList<ProductDTO> GetAllProducts();

        /// <summary>
        /// Get all Commonly Used Products
        /// </summary>
        /// <returns>returns list of all Commonly Used  products present in database</returns>
        [OperationContract]
        IList<ProductDTO> GetCommonProduct();

        

        #endregion

        #region Users

        [OperationContract]
        IList<StaffDTO> GetStaffDetails();

        [OperationContract]
        bool ValidateUserCredentials(string userName, string password);

        #endregion

        #region Customers

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>returns list of all active customers present in database</returns>
        [OperationContract]
        IList<CustomerDTO> GetAllCustomers();

        #endregion

        #region Settings

        /// <summary>
        /// Save Shop setting details in database
        /// </summary>
        /// <param name="shopSettingDetails">Shopsetting object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        [OperationContract]
        bool SaveShopSetting(ShopSettingDTO shopSettingDetails);

        #endregion

        #region Masters

        /// <summary>
        /// Retrieves available country details from database
        /// </summary>
        /// <returns>returns list of country else empty list</returns>
        [OperationContract]
        IList<CountryDTO> GetCountryDetails();

        /// <summary>
        /// Retrieves available TownCity details from database
        /// </summary>
        /// <returns>returns list of TownCity else empty list</returns>
        [OperationContract]
        IList<TownCityDTO> GetTownCityDetails(int countryId);

        /// <summary>
        /// Retrieves available Locality details from database
        /// </summary>
        /// <returns>returns list of Locality else empty list</returns>
        [OperationContract]
        IList<LocalityDTO> GetLocalityDetails(int townCityId);

        /// <summary>
        /// Retrieves available Street details from database
        /// </summary>
        /// <returns>returns list of Street else empty list</returns>
        [OperationContract]
        IList<StreetDTO> GetStreetDetails(int localityId);

        /// <summary>
        /// Retrieves available Postalcode details from database
        /// </summary>
        /// <returns>returns list of Postalcode else empty list</returns>
        [OperationContract]
        IList<PostCodeDTO> GetPostalCodeDetails(int localityId);

        #endregion

        #region PromotionalOffer
        /// <summary>
        /// Retrieves available PromotionalOffer details from database
        /// </summary>
        /// <returns>returns list of PromotioanlOffer else empty list</returns>
        [OperationContract]
        IList<PromotionalOfferDTO> GetPromotionalOfferDetail();       
        
        #endregion
    }
}