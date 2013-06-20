using RetailPOS.BusinessLayer.Service.User;
using RetailPOS.CommonLayer.DataTransferObjects.User;
using RetailPOS.CommonLayer.Mapper;

namespace RetailPOS.BusinessLayer.ServiceImpl.User
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
            StaffDTO userDetails = new StaffDTO();
            ObjectMapper.Map(base.StaffRepository.GetSingle(item => item.username == userName
                && item.password == password), userDetails);

            bool result = userDetails.Id > 0 ? true : false;
            return result;
        }
    }
}