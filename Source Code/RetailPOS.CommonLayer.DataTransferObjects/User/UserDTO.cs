namespace RetailPOS.CommonLayer.DataTransferObjects.User
{
    public class UserDTO : BaseDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}