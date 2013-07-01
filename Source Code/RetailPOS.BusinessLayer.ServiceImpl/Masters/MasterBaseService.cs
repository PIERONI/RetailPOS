using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.PersistenceLayer.Repository.Interfaces;
using RetailPOS.PersistenceLayer.Repository.Entities;
using Microsoft.Practices.Unity;

namespace RetailPOS.BusinessLayer.ServiceImpl.Masters
{
    public class MasterBaseService
    {
        [Dependency]
        public IGenericRepository<country> CountryRepository
        {
            get;
            set;
        }
    }
}