using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.BusinessLayer.Service.Setting;
using RetailPOS.CommonLayer.DataTransferObjects.Customer;
using RetailPOS.PersistenceLayer.Repository.Entities;
using RetailPOS.CommonLayer.Mapper;

namespace RetailPOS.BusinessLayer.ServiceImpl.Setting
{
    public partial class SettingServiceImpl
    {
        /// Save Customer details in database
        /// </summary>
        /// <param name="shopSettingDetails">Customer object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        /// <summary>
        bool ISettingService.SaveCustomerDetail(CustomerDTO customerDetails)
        {
            customer customerDetailEntity = new customer();
            ObjectMapper.Map(customerDetails, customerDetailEntity);

            return CustomerRepository.Save(customerDetailEntity);
        }
    }
}
