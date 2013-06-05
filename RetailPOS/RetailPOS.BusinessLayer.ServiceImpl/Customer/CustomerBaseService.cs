#region Using directives

using Microsoft.Practices.Unity;
using RetailPOS.PersistenceLayer.Repository.Entities;
using RetailPOS.PersistenceLayer.Repository.Interfaces;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Customer
{
    public class CustomerBaseService
    {
        /// <summary>
        /// Property to inject the persistence layer implementation class for customers
        /// </summary>
        [Dependency]
        public IGenericRepository<customer> CustomerRepository { get; set; }
    }
}