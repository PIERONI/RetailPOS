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
    }
}