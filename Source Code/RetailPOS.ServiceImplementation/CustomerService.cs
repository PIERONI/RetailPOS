using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.Customer;

namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService
    {
        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>returns list of all active customers present in database</returns>
        public IList<CustomerDTO> GetAllCustomers()
        {
            return CustomerService.GetAllCustomers();
        }

        /// Save Customer details in database
        /// </summary>
        /// <param name="shopSettingDetails">Customer object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        /// <summary>
        public bool SaveCustomerDetail(CustomerDTO customerDetails)
        {
            return CustomerService.SaveCustomerDetail(customerDetails);
        }

        /// Update Customer details in database
        /// </summary>
        /// <param name="shopSettingDetails">Customer object to be updated</param>
        /// <returns>returns boolean value indicating if the records are updated in database</returns>
        /// <summary>

        public bool UpdateCustomerDetail(CustomerDTO customerDetail)
        {
            return CustomerService.UpdateCustomerDetail(customerDetail);
        }
       


        /// <summary>
        /// Get customer status from database
        /// </summary>
        /// <returns>returns list of all customer status present in database else empty list</returns>
        public IList<CustomerStatusDTO> GetCustomerStatus()
        {
            return CustomerService.GetCustomerStatus();
        }

        /// <summary>
        /// Get customer types from database
        /// </summary>
        /// <returns>returns list of all customer types present in database</returns>
        public IList<CustomerTypeDTO> GetCustomerTypes()
        {
            return CustomerService.GetCustomerTypes();
        }
    }
}