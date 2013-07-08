namespace RetailPOS.CommonLayer.DataTransferObjects.Master
{
    public class TownCityDTO : BaseDTO
    {
        public short Id { get; set; }
        public string Town_City1 { get; set; }
        public int countryID { get; set; }
    }
}