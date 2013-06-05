#region Using directives

using Microsoft.Practices.Unity;
using RetailPOS.PersistenceLayer.Repository.Entities;
using RetailPOS.PersistenceLayer.Repository.Interfaces;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Users
{
    public class UserBaseService
    {
        /// <summary>
        /// Property to inject the persistence layer implementation class for users
        /// </summary>
        [Dependency]
        public IGenericRepository<staff> StaffRepository { get; set; }

        /// <summary>
        /// Property to inject the persistence layer implementation class for users
        /// </summary>
        [Dependency]
        public IGenericRepository<user> UserRepository { get; set; }
    }
}