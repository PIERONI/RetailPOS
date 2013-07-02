namespace RetailPOS.CommonLayer.DataTransferObjects.Master
{
    public class PostCodeDTO : BaseDTO
    {
        public int Id { get; set; }
        public string PostCode { get; set; }
        public short TownCityId { get; set; }
    }
}