using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.CommonLayer.DataTransferObjects.Order;
using RetailPOS.CommonLayer.DataTransferObjects.Product;

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
        /// Get all order items matched with status parameter
        /// </summary>
        /// <param name="status">status to get order items</param>
        /// <returns>returns list of  order items with the selected status</returns>
        IList<OrderMasterDTO> GetOrderItemByStatus(int status);

        /// <summary>
        /// Get all active Products
        /// </summary>
        /// <returns>returns list of all products present in database</returns>
        IList<ProductDTO> GetAllProducts();


        /// <summary>
        /// Update Order details  in database based on Order in queue Item
        /// </summary>
        /// <param name="OrderInqueueDetail">Customer object to be Updated</param>
        /// <returns>returns boolean value indicating if the records are Updated in database</returns>
        bool UpdateOrderDetail(OrderMasterDTO orderDetails);

    
    }
}