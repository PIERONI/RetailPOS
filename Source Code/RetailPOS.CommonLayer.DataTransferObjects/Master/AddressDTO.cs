using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetailPOS.CommonLayer.DataTransferObjects.Master
{
    class AddressDTO
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
