#region Using directives

using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.Customer;

#endregion

namespace RetailPOS.BusinessLayer.Service.Customer
{
    public interface ICustomerService
    {
        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>returns list of all customers present in database</returns>
        IList<CustomerDTO> GetAllCustomers();

        /// <summary>
        /// Save Customer details in database
        /// </summary>
        /// <param name="shopSettingDetails">Customer object to be saved</param>
        /// <returns>returns integer value as identity value for the new customer record entered in database</returns>
        int SaveCustomerDetail(CustomerDTO customerDetails);

        /// <summary>
        /// Get customer status from database
        /// </summary>
        /// <returns>returns list of all customer status present in database else empty list</returns>
        IList<CustomerStatusDTO> GetCustomerStatus();

        /// <summary>
        /// Get customer types from database
        /// </summary>
        /// <returns>returns list of all customer types present in database</returns>
        IList<CustomerTypeDTO> GetCustomerTypes();

        /// <summary>
        /// Update Customer details (Balance) in database based on Payment done
        /// </summary>
        /// <param name="shopSettingDetails">Customer object to be Updated</param>
        /// <returns>returns boolean value indicating if the records are Updated in database</returns>
        bool UpdateCustomerDetail(CustomerDTO customerDetails);

       
    }
}