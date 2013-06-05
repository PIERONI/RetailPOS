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
    }
}