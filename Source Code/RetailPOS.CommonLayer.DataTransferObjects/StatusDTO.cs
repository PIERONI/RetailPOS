namespace RetailPOS.CommonLayer.DataTransferObjects
{
    public class StatusDTO : BaseDTO
    {
        public short Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}