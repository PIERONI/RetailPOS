#region Using directives

using Microsoft.Practices.Unity;
using RetailPOS.PersistenceLayer.Repository.Entities;
using RetailPOS.PersistenceLayer.Repository.Interfaces;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.Admin
{
    public class AdminBaseService
    {
        #region Public Properties

        /// <summary>
        /// Property to inject the persistence layer implementation class for category
        /// </summary>
        [Dependency]
        public IGenericRepository<product_category> CategoryRepository { get; set; }

        /// <summary>
        /// Property to inject the persistence layer implementation class for product
        /// </summary>
        [Dependency]
        public IGenericRepository<product> ProductRepository { get; set; }

        /// <summary>
        /// Property to inject the persistence layer implementation class for product status
        /// </summary>
        [Dependency]
        public IGenericRepository<product_status> ProductStatusRepository { get; set; }
        
        #endregion
    }
}