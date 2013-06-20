namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService
    {
        /// <summary>
        /// Users: This service implementation class is used to get staff details from repository
        /// </summary>
        /// <returns>return list of product by category</returns>
        /// <remarks></remarks>
        public bool ValidateUserCredentials(string userName, string password)
        {
            return UserService.ValidateUserCredentials(userName, password);
        }
    }
}