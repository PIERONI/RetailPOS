#region Using directives

using System;
using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.Customer;

#endregion

namespace RetailPOS.CommonLayer.DataTransferObjects.Order
{
    public class OrderMasterDTO : BaseDTO
    {
        #region Primitive Properties

        public long Id { get; set; }
        public string Order_No { get; set; }
        public DateTime Order_Date { get; set; }
        public Nullable<int> Customer_Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerFirstName { get; set; }
        public string Shop_Code { get; set; }
        public Nullable<long> Invoice_Id { get; set; }
        public short Print_Receipt_Copies { get; set; }
        public Nullable<short> Status { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public IList<OrderChildDTO> OrderChilds { get; set; }

        #endregion

        #region Navigational Properties
        private CustomerDTO _customer;

        public CustomerDTO customer
        {
            get { return _customer; }
            set
            {
                if (!ReferenceEquals(_customer, value))
                {
                    var previousValue = _customer;
                    _customer = null;
                    CustomerName = value.First_Name + " " + value.Last_Name;
                    CustomerFirstName = value.First_Name;
                }
            }
        }
        #endregion
    }
}