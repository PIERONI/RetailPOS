using RetailPOS.BusinessLayer.Service.Users;
using RetailPOS.CommonLayer.DataTransferObjects;
using RetailPOS.CommonLayer.Mapper;

namespace RetailPOS.BusinessLayer.ServiceImpl.Users
{
    public class UserServiceImpl : UserBaseService, IUserService
    {
        /// <summary>
        /// Validate user credentials by verifying from database
        /// </summary>
        /// <param name="userName">username to validate</param>
        /// <param name="password">password to validate</param>
        /// <returns>returns boolean value indicating whether user credentials are verified or not</returns>
        bool IUserService.ValidateUserCredentials(string userName, string password)
        {
            UserDTO userDetails = new UserDTO();
            ObjectMapper.Map(base.UserRepository.GetSingle(item => item.UserName == userName
                && item.Password == password), userDetails);

            bool result = userDetails.Id > 0 ? true : false;
            return result;
        }
    }
}