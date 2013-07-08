namespace RetailPOS.CommonLayer.DataTransferObjects.Customer
{
    public class CustomerTypeDTO : BaseDTO
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}