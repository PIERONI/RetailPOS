namespace RetailPOS.BusinessLayer.Service.Users
{
    public interface IUserService
    {
        /// <summary>
        /// Validate user credentials by verifying from database
        /// </summary>
        /// <returns>returns boolean value for </returns>
        bool ValidateUserCredentials(string userName, string password);
    }
}