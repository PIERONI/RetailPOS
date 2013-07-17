using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace RetailPOS.CommonLayer.DataTransferObjects.Order
{
  public  class OrderMasterDTO:BaseDTO
    {
      public short Id { get; set; }
      public string Order_no { get; set; }
      public DateTime Order_date { get; set; }
      public Nullable<int> Customer_id { get; set; }
      public string Shop_code { get; set; }
      public Nullable<long> Invoice_id { get; set; }
      public short Print_receipt_copies { get; set; }
      public IList<OrderChildDTO> Orderchilds { get; set; }
    }
}
