using System;

namespace RetailPOS.CommonLayer.DataTransferObjects.Master
{
    public class AddressDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Building_name { get; set; }
        public string House_No { get; set; }
        public Nullable<short> Country_Id { get; set; }
        public Nullable<short> Town_City_Id { get; set; }
        public Nullable<long> Locality_Id { get; set; }
        public int Street_Id { get; set; }
        public int PostCode_Id { get; set; }
    }
}