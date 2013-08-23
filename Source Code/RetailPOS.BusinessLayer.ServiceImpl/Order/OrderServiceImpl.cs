#region Using directives

using System.Collections.Generic;
using System.Linq;
using RetailPOS.BusinessLayer.Service.Order;
using RetailPOS.CommonLayer.DataTransferObjects.Order;
using RetailPOS.CommonLayer.Mapper;
using RetailPOS.PersistenceLayer.Repository.Entities;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Order
{
    public class OrderServiceImpl : OrderBaseService, IOrderService
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
        /// Get set aside orders by customer Id
        /// </summary>
        /// <returns>returns list of set aside orders by customer Id</returns>
        IList<OrderMasterDTO> IOrderService.GetSetAsideOrders(int customerId)
        {
            IList<OrderMasterDTO> lstOrderMaster = new List<OrderMasterDTO>();
            ObjectMapper.Map(base.OrderMasterRepository.GetList(item => 
                item.customer_id == customerId && item.Status == 2).ToList(), lstOrderMaster);
            return lstOrderMaster;
        }

        /// <summary>
        /// Get all orders in queue from database
        /// </summary>
        /// <returns>returns list of orders in queue</returns>  
        IList<OrderMasterDTO> IOrderService.GetOrdersInQueue()
        {
            IList<OrderMasterDTO> lstOrderMaster = new List<OrderMasterDTO>();
            lstOrderMaster = (from orderMaster in base.OrderMasterRepository.GetList(item => item.Status == 3).ToList()
                              join orderChild in base.OrderChildRepository.GetList().ToList()
                              on orderMaster.id equals orderChild.order_id
                              orderby orderMaster.id descending
                              group orderChild by orderChild.order_id into groupByItem
                              select new OrderMasterDTO
                              {
                                  Id = groupByItem.Key,
                                  TotalQuantity = groupByItem.Count(),
                                  TotalAmount = groupByItem.Sum(sum => sum.amount)
                              }).ToList();
            
            return lstOrderMaster;
        }

        /// <summary>
        /// Get all order items contained within an order Id
        /// </summary>
        /// <returns>returns list of child order items by order Id</returns>
        IList<OrderChildDTO> IOrderService.GetOrderItemsByOrderId(long orderId)
        {
            IList<OrderChildDTO> lstOrderChild = new List<OrderChildDTO>();
            ObjectMapper.Map(base.OrderChildRepository.GetList(item => item.order_id == orderId).ToList(), lstOrderChild);
            
            return lstOrderChild;
        }

        /// <summary>
        /// Get all order items matched with status parameter
        /// </summary>
        /// <param name="status">status to get order items</param>
        /// <returns>returns list of  order items with the selected status</returns>
        IList<OrderMasterDTO> IOrderService.GetOrderItemByStatus(int status)
        {
            IList<OrderMasterDTO> lstOrder = new List<OrderMasterDTO>();
            lstOrder = (from orderMaster in base.OrderMasterRepository.GetList().ToList()
                        join customerItem in base.CustomerRepository.GetList().ToList()
                        on orderMaster.customer_id equals customerItem.id
                        where orderMaster.Status == status
                        select new OrderMasterDTO
                        {
                            Id = orderMaster.id,
                            Order_No = orderMaster.order_no,
                            Order_Date = orderMaster.order_date,
                            Customer_Id = orderMaster.customer_id,
                            CustomerName = customerItem.first_name + " " + customerItem.last_name,
                            Shop_Code = orderMaster.shop_code,
                            Invoice_Id = orderMaster.invoice_id,
                            Print_Receipt_Copies = orderMaster.print_receipt_copies
                        }).ToList();

            return lstOrder;
        }
    }
}