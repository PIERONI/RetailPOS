#region Using directives

using System;
using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.Customer;

#endregion

namespace RetailPOS.CommonLayer.DataTransferObjects.Order
{
    public class OrderMasterDTO : BaseDTO
    {
        public long Id { get; set; }
        public string Order_No { get; set; }
        public DateTime Order_Date { get; set; }
        public Nullable<int> Customer_Id { get; set; }
        public string CustomerName { get; set; }
        public string Shop_Code { get; set; }
        public Nullable<long> Invoice_Id { get; set; }
        public short Print_Receipt_Copies { get; set; }
        public Nullable<short> Status { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public IList<OrderChildDTO> OrderChilds { get; set; }
    }
}