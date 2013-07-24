#region Using directives

using System;
using RetailPOS.CommonLayer.DataTransferObjects.Master;

#endregion

namespace RetailPOS.CommonLayer.DataTransferObjects.Customer
{
    public class CustomerDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Nullable<short> Type_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public int Status_Id { get; set; }
        public string OpenId_Id { get; set; }
        public Nullable<short> OpenId_Server_Id { get; set; }
        public string Password { get; set; }
        public int Payment_Period { get; set; }
        public decimal Credit_Limit { get; set; }
        public decimal Balance { get; set; }
        public string Image_Path { get; set; }
        public Nullable<long> Address_Id { get; set; }
        public AddressDTO Address { get; set; }
    }
}