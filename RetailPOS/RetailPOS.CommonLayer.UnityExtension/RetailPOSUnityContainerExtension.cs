#region Using directives

using Microsoft.Practices.Unity;
using RetailPOS.BusinessLayer.Service.Masters;
using RetailPOS.CommonLayer.Mapper;
using RetailPOS.CommonLayer.Unity;
using RetailPOS.PersistenceLayer.EF.Impl;
using RetailPOS.PersistenceLayer.Repository.Interfaces;
using RetailPOS.BusinessLayer.ServiceImpl.Admin;
using RetailPOS.BusinessLayer.Service.Admin;

#endregion

namespace RetailPOS.CommonLayer.UnityExtension
{
    public class RetailPOSUnityContainerExtension
    {
        /// <summary>
        /// The purpose of this class is to define the object registration activity for Unity Container
        /// In this class all application level object get registered
        /// </summary>
        public static void InitializeContainer()
        {
            RetailPOSUnityContainer.Container = new UnityContainer();

            //call method to register business services
            RegisterBusinessServices();

            //call method to register the services of persistence layer
            RegisterPersistenceRepository();
        }

        /// <summary>
        /// This method is used to register the business services for dependency injection.
        /// </summary>
        private static void RegisterBusinessServices()
        {
            #region Registration of Persistence Layer Repository Classes

            RetailPOSUnityContainer.Register<ICategoryService, CategoryServiceImpl>();
            RetailPOSUnityContainer.Register<IProductService, ProductServiceImpl>();

            #endregion
        }

        /// <summary>
        /// This method is used to register the persistence layer repository for dependency injection.
        /// </summary>
        private static void RegisterPersistenceRepository()
        {
            #region Registration of Persistence Layer Repository Classes

            RetailPOSUnityContainer.Register<IObjectMapper, ObjectMapper>();
            RetailPOSUnityContainer.Register(typeof(IGenericRepository<>), typeof(GenericRepositoryImpl<>));

            #endregion
        }
    }
}