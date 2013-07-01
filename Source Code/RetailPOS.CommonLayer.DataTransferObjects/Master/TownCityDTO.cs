namespace RetailPOS.CommonLayer.DataTransferObjects.Master
{
    public class TownCityDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Town_City { get; set; }
        public int countryID { get; set; }
    }
}