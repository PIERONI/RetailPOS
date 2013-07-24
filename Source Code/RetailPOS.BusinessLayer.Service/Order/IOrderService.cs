using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.CommonLayer.DataTransferObjects.Order;

namespace RetailPOS.BusinessLayer.Service.Order
{
    public interface IOrderService
    {
        /// <summary>
        /// Save Order details in database
        /// </summary>
        /// <param name="orderDetails">ordermaster object to be saved</param>
        /// <returns>returns boolean value indicating if the records are saved in database</returns>
        bool SaveOrderDetail(OrderMasterDTO orderDetail);

        /// <summary>
        /// Get set aside orders by customer Id
        /// </summary>
        /// <returns>returns list of set aside orders by customer Id</returns>
        IList<OrderMasterDTO> GetSetAsideOrders(int customerId);

        /// <summary>
        /// Get all orders in queue from database
        /// </summary>
        /// <returns>returns list of orders in queue</returns>  
        IList<OrderMasterDTO> GetOrdersInQueue();

        /// <summary>
        /// Get all order items contained within an order Id
        /// </summary>
        /// <returns>returns list of child order items by order Id</returns>
        IList<OrderChildDTO> GetOrderItemsByOrderId(long orderId);

        /// <summary>
        /// Get all order items whose status is 3
        /// </summary>
        /// <returns>returns list of  order items whose status is 3</returns>
        IList<OrderMasterDTO> GetOrderItemByStatus();
    }
}