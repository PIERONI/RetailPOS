#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using RetailPOS.PersistenceLayer.Repository.Entities;
using RetailPOS.PersistenceLayer.Repository.Interfaces;

#endregion

namespace RetailPOS.BusinessLayer.ServiceImpl.PromotionalOffer
{
   public  class PromotionalBaseService
    {
        /// <summary>
        /// Property to inject the persistence layer implementation class for customers
        /// </summary>
       [Dependency]
       public IGenericRepository<promotional_offer> PromotionalOfferRepository { get; set; }

    }
}
