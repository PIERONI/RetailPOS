namespace RetailPOS.CommonLayer.DataTransferObjects.Master
{
    public class PostCodeDTO : BaseDTO
    {
        public int Id { get; set; }
        public short TownCityId { get; set; }
        public string PostCode1 { get; set; }
    }
}