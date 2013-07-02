using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.CommonLayer.DataTransferObjects.Master;

namespace RetailPOS.CommonLayer.DataTransferObjects.Settings
{
    public class ShopSettingDTO : BaseDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public decimal Tax_rate { get; set; }
        public string  Currency { get; set; }
        public int AddressId { get; set; }
        public AddressDTO Address { get; set; }
    }
}