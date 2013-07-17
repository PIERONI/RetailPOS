using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.BusinessLayer.Service.Order;
using RetailPOS.CommonLayer.DataTransferObjects.Order;
using RetailPOS.PersistenceLayer.Repository.Entities;
using RetailPOS.CommonLayer.Mapper;

namespace RetailPOS.BusinessLayer.ServiceImpl.Order
{
   public  class OrderServiceImpl:OrderBaseService,IOrderService
    {
        /// <summary>
        /// Save Order details in database
        /// </summary>
        /// <param name="orderDetails">ordermaster object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
       bool IOrderService.SaveOrderDetail(OrderMasterDTO orderDetail)
       {
           ordermaster orderEntity = new ordermaster();
           ObjectMapper.Map(orderDetail, orderEntity);
           return OrderMasterRepository.Save(orderEntity);
       }
    }
}
