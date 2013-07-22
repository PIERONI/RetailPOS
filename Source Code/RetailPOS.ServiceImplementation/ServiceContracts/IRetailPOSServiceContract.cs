#region Using directives

using System.Collections.Generic;
using System.ServiceModel;
using RetailPOS.CommonLayer.DataTransferObjects.Category;
using RetailPOS.CommonLayer.DataTransferObjects.Customer;
using RetailPOS.CommonLayer.DataTransferObjects.Master;
using RetailPOS.CommonLayer.DataTransferObjects.Product;
using RetailPOS.CommonLayer.DataTransferObjects.Settings;
using RetailPOS.CommonLayer.DataTransferObjects.User;
using RetailPOS.CommonLayer.DataTransferObjects.Order;

#endregion

namespace RetailPOS.ServiceImplementation.ServiceContracts
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    interface IRetailPOSServiceContract
    {
        #region Categories

        [OperationContract]
        IList<ProductCategoryDTO> GetCategories();

        /// <summary>
        /// Save Category details in database
        /// </summary>
        /// <param name="categoryDetails">Category details to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        [OperationContract]
        bool SaveCategoryDetails(ProductCategoryDTO categoryDetails);

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

        /// <summary>
        /// Get product status from database
        /// </summary>
        /// <returns>returns list of all status present in database for product, else empty list</returns>
        [OperationContract]
        IList<ProductStatusDTO> GetProductStatus();

        /// <summary>
        /// Save Product details in database
        /// </summary>
        /// <param name="productDetails">Product details to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        [OperationContract]
        bool SaveProductDetails(ProductDTO productDetails);

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

        /// Save Customer details in database
        /// </summary>
        /// <param name="shopSettingDetails">Customer object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        /// <summary>
        [OperationContract]
        bool SaveCustomerDetail(CustomerDTO customerDetails);

        /// Update Customer details in database
        /// </summary>
        /// <param name="shopSettingDetails">Customer object to be updated</param>
        /// <returns>returns boolean value indicating if the records are updated in database</returns>
        /// <summary>
        [OperationContract]
        bool UpdateCustomerDetail(CustomerDTO customerDetail);

        /// <summary>
        /// Get customer status from database
        /// </summary>
        /// <returns>returns list of all customer status present in database else empty list</returns>
        [OperationContract]
        IList<CustomerStatusDTO> GetCustomerStatus();

        /// <summary>
        /// Get customer types from database
        /// </summary>
        /// <returns>returns list of all customer types present in database</returns>
        [OperationContract]
        IList<CustomerTypeDTO> GetCustomerTypes();

        #endregion

        #region Settings

        /// <summary>
        /// Save Shop setting details in database
        /// </summary>
        /// <param name="shopSettingDetails">Shopsetting object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        [OperationContract]
        bool SaveShopSetting(ShopSettingDTO shopSettingDetails);

        /// <summary>
        /// Retrieves available PromotionalOffer details from database
        /// </summary>
        /// <returns>returns list of PromotioanlOffer else empty list</returns>
        [OperationContract]
        IList<PromotionalOfferDTO> GetPromotionalOfferDetail();

        /// <summary>
        /// Save Waste management setting in database
        /// </summary>
        /// <param name="wasteManagementDetails">Waste Management setting object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        [OperationContract]
        bool SaveWasteManagement(WasteManagementDTO wasteManagementDetails);

        /// <summary>
        /// Save Promotional offer details in database
        /// </summary>
        /// <param name="promitonalOfferDetails">Promotional offer object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        [OperationContract]
        bool SavePromotionalOffer(PromotionalOfferDTO promotionalOfferDetails);

        /// <summary>
        /// Retrieves available Purchase History details from database
        /// </summary>
        /// <returns>returns list of Purchase History else empty list</returns>
        [OperationContract]
        IList<PurchaseHistoryDTO> GetPurchaseHistoryDetails();

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

        /// <summary>
        /// Retrieves available Measure unit details from database
        /// </summary>
        /// <returns>returns list of Measure unit else empty list</returns>
        [OperationContract]
        IList<MeasureUnitDTO> GetMeasureUnitDetails();

        #endregion

        #region Order
        [OperationContract]
        /// <summary>
        /// Save Order details in database
        /// </summary>
        /// <param name="orderDetails">ordermaster object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        bool SaveOrderDetail(OrderMasterDTO orderDetail);
    
          /// <summary>
        /// Get orderMasterDetail By customer Id
        /// </summary>
        /// <returns>returns list of orderMasterDetail by customerId</returns>  
        [OperationContract]
        IList<OrderMasterDTO> GetOrderByCustomerId(int customerId);
         /// <summary>
        /// Get orderChildDetail By Order Id
        /// </summary>
        /// <returns>returns list of orderChildDetail by Order Id</returns>
        [OperationContract]
        IList<OrderChildDTO> GetOrderChildByOrderId(int orderId);
     
        #endregion
    }
}