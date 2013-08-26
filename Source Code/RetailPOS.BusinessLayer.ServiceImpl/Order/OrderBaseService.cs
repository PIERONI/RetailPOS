using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.PersistenceLayer.Repository.Interfaces;
using RetailPOS.PersistenceLayer.Repository.Entities;
using Microsoft.Practices.Unity;

namespace RetailPOS.BusinessLayer.ServiceImpl.Order
{
    public class OrderBaseService
    {
        /// <summary>
        /// Property to inject the persistence layer implementation class for OrderMaster
        /// </summary>        
        [Dependency]
        public IGenericRepository<ordermaster> OrderMasterRepository { get; set; }

        /// <summary>
        /// Property to inject the persistence layer implementation class for OrderMaster
        /// </summary>
        [Dependency]
        public IGenericRepository<orderchild> OrderChildRepository { get; set; }

        /// <summary>
        /// Property to inject the persistence layer implementation class for customers
        /// </summary>
        [Dependency]
        public IGenericRepository<customer> CustomerRepository { get; set; }

        /// <summary>
        /// Property to inject the persistence layer implementation class for product
        /// </summary>
        [Dependency]
        public IGenericRepository<product> ProductRepository { get; set; }

    }
}