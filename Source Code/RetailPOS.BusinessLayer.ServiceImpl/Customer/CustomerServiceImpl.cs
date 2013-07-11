#region Using directives

using System.Collections.Generic;
using System.Linq;
using RetailPOS.BusinessLayer.Service.Customer;
using RetailPOS.CommonLayer.DataTransferObjects.Customer;
using RetailPOS.CommonLayer.Mapper;
using RetailPOS.PersistenceLayer.Repository.Entities;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Customer
{
    public class CustomerServiceImpl : CustomerBaseService, ICustomerService
    {
        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>returns list of all customers present in database</returns>
        IList<CustomerDTO> ICustomerService.GetAllCustomers()
        {
            IList<CustomerDTO> lstCustomers = new List<CustomerDTO>();
            ObjectMapper.Map(base.CustomerRepository.GetList(item => item.status_id == 1).ToList(), lstCustomers);

            return lstCustomers;
        }

        /// Save Customer details in database
        /// </summary>
        /// <param name="shopSettingDetails">Customer object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        /// <summary>
        bool ICustomerService.SaveCustomerDetail(CustomerDTO customerDetails)
        {
            customer customerEntity = new customer();

            ObjectMapper.Map(customerDetails, customerEntity);
            return CustomerRepository.Save(customerEntity);
        }

        /// <summary>
        /// Get customer status from database
        /// </summary>
        /// <returns>returns list of all customer status present in database else empty list</returns>
        IList<CustomerStatusDTO> ICustomerService.GetCustomerStatus()
        {
            IList<CustomerStatusDTO> lstCustomerStatus = new List<CustomerStatusDTO>();
            ObjectMapper.Map(base.CustomerStatusRepository.GetList().ToList(), lstCustomerStatus);

            return lstCustomerStatus;
        }

        /// <summary>
        /// Get customer types from database
        /// </summary>
        /// <returns>returns list of all customer types present in database</returns>
        IList<CustomerTypeDTO> ICustomerService.GetCustomerTypes()
        {
            IList<CustomerTypeDTO> lstCustomerType = new List<CustomerTypeDTO>();
            ObjectMapper.Map(base.CustomerTypeRepository.GetList().ToList(), lstCustomerType);

            return lstCustomerType;
        }

        /// <summary>
        /// Update Customer details (Balance) in database based on Payment done
        /// </summary>
        /// <param name="shopSettingDetails">Customer object to be Updated</param>
        /// <returns>returns boolean value indicating if the records are Updated in database</returns>
        bool ICustomerService.UpdateCustomerDetail(CustomerDTO customerDetail)
        {
            customer customerEntity = new customer();

            ObjectMapper.Map(customerDetail, customerEntity);
            return CustomerRepository.Update(customerEntity);
        }
    }
}