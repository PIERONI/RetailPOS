#region Using directives

using System;

#endregion

namespace RetailPOS.CommonLayer.DataTransferObjects.Settings
{
    public class WasteManagementDTO : BaseDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Nullable<decimal> Weight { get; set; }
    }
}