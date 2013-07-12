using System;

namespace RetailPOS.CommonLayer.DataTransferObjects.Settings
{
    public class PurchaseHistoryDTO : BaseDTO
    {
        public int Id { get; set; }
        public DateTime Purchase_Date { get; set; }
        public Nullable<short> Supplier_Id { get; set; }
        public string Shop_Code { get; set; }
        public string Invoice_No { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Grand_Total { get; set; }
        public decimal Cash { get; set; }
        public decimal Credit { get; set; }
    }
}