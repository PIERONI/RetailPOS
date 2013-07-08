namespace RetailPOS.CommonLayer.DataTransferObjects.Customer
{
    public class CustomerStatusDTO : BaseDTO
    {
        public short Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}