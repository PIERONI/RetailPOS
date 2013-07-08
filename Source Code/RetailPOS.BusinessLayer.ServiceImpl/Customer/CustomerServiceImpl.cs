#region Using directives

using System.Collections.Generic;
using System.Linq;
using RetailPOS.BusinessLayer.Service.Customer;
using RetailPOS.CommonLayer.DataTransferObjects.Customer;
using RetailPOS.CommonLayer.Mapper;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Customer
{
    public partial class CustomerServiceImpl : CustomerBaseService, ICustomerService
    {
        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>returns list of all customers present in database</returns>
        IList<CustomerDTO> ICustomerService.GetAllCustomers()
        {
            IList<CustomerDTO> lstCustomers = new List<CustomerDTO>();
            ObjectMapper.Map(base.CustomerRepository.GetList(item => item.status_id == 10).ToList(), lstCustomers);
            return lstCustomers;
        }
    }
}