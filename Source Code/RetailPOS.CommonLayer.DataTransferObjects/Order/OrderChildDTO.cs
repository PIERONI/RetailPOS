using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetailPOS.CommonLayer.DataTransferObjects.Order
{
   public  class OrderChildDTO:BaseDTO
    {
       public long Order_id { get; set; }
       public short Product_id { get; set; }
       public short Quantity { get; set; }
       public short Measure_unit_id { get; set; }
       public decimal Amount { get; set; }
       public int Taxed { get; set; }
    }
}
