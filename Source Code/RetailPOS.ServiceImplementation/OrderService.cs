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
        public IList<OrderMasterDTO> GetSetAsideOrders(int customerId)
        {
            return OrderService.GetSetAsideOrders(customerId);
        }

        /// <summary>
        /// Get all orders in queue from database
        /// </summary>
        /// <returns>returns list of orders in queue</returns>
        public IList<OrderMasterDTO> GetOrdersInQueue()
        {
            return OrderService.GetOrdersInQueue();
        }

        /// <summary>
        /// Get all order items contained within an order Id
        /// </summary>
        /// <returns>returns list of child order items by order Id</returns>
        public IList<OrderChildDTO> GetOrderItemsByOrderId(long orderId)
        {
            return OrderService.GetOrderItemsByOrderId(orderId);
        }

        /// <summary>
        /// Get all order items matched with status parameter
        /// </summary>
        /// <param name="status">status to get order items</param>
        /// <returns>returns list of  order items with the selected status</returns>
        public IList<OrderMasterDTO> GetOrderItemByStatus(int status)
        {
            return OrderService.GetOrderItemByStatus(status);
        }
    }
}