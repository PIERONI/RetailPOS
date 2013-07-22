using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.CommonLayer.DataTransferObjects.Order;

namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService
    {
        /// <summary>
        /// Save Order details in database
        /// </summary>
        /// <param name="orderDetails">ordermaster object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
      public bool SaveOrderDetail(OrderMasterDTO orderDetail)
      {
          return OrderService.SaveOrderDetail(orderDetail);
      }
        /// <summary>
        /// Get orderMasterDetail By customer Id
        /// </summary>
        /// <returns>returns list of orderMasterDetail by customerId</returns>  
      public IList<OrderMasterDTO> GetOrderByCustomerId(int customerId)
      {
          return OrderService.GetOrderByCustomerId(customerId);
      }
        /// <summary>
        /// Get orderChildDetail By Order Id
        /// </summary>
        /// <returns>returns list of orderChildDetail by Order Id</returns>
      public IList<OrderChildDTO> GetOrderChildByOrderId(int orderId)
      {
          return OrderService.GetOrderChildByOrderId(orderId);
      }
    }
}
