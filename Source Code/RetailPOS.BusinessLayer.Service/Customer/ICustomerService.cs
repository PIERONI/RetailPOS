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
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        bool SaveCustomerDetail(CustomerDTO customerDetails);

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
    }
}