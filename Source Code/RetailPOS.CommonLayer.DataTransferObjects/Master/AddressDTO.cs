namespace RetailPOS.CommonLayer.DataTransferObjects.Master
{
    public class AddressDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Building_name { get; set; }
        public string House_No { get; set; }
        public int Street_Id { get; set; }
        public int Locality_Id { get; set; }
        public int Town_City_Id { get; set; }
        public int Country_Id { get; set; }
        public int PostCode_Id { get; set; }
    }
}