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
        /// <summary>
        /// Get orderMasterDetail By customer Id
        /// </summary>
        /// <returns>returns list of orderMasterDetail by customerId</returns>  
       IList<OrderMasterDTO> IOrderService.GetOrderByCustomerId(int customerId)
       {
           IList < OrderMasterDTO > lstOrderMaster= new List<OrderMasterDTO>();
           ObjectMapper.Map(base.OrderMasterRepository.GetList(item=>item.customer_id==customerId),lstOrderMaster);
           return lstOrderMaster;
       }
        /// <summary>
        /// Get orderChildDetail By Order Id
        /// </summary>
        /// <returns>returns list of orderChildDetail by Order Id</returns>
       IList<OrderChildDTO> IOrderService.GetOrderChildByOrderId(int orderId)
       {
           IList<OrderChildDTO> lstOrderChild = new List<OrderChildDTO>();
           ObjectMapper.Map(base.OrderChildRepository.GetList(item=>item.order_id==orderId), lstOrderChild);
           return lstOrderChild;
       }
     
    }
}
