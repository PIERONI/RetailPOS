using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using RetailPOS.CommonLayer.DataTransferObjects;

namespace RetailPOS.ServiceImplementation.ServiceContracts
{
    [ServiceContract]
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

        #endregion

        #region Users

        [OperationContract]
        IList<StaffDTO> GetStaffDetails();

        [OperationContract]
        bool ValidateUserCredentials(string userName, string password);

        #endregion
    }
}