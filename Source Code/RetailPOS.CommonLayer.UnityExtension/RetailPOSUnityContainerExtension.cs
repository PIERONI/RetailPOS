#region Using directives

using Microsoft.Practices.Unity;
using RetailPOS.BusinessLayer.Service.Admin;
using RetailPOS.BusinessLayer.Service.Customer;
using RetailPOS.BusinessLayer.ServiceImpl.Admin;
using RetailPOS.BusinessLayer.ServiceImpl.Customer;
using RetailPOS.CommonLayer.Mapper;
using RetailPOS.CommonLayer.Unity;
using RetailPOS.PersistenceLayer.EF.Impl;
using RetailPOS.PersistenceLayer.Repository.Interfaces;
using RetailPOS.BusinessLayer.Service.User;
using RetailPOS.BusinessLayer.ServiceImpl.User;
using RetailPOS.BusinessLayer.Service.Setting;
using RetailPOS.BusinessLayer.ServiceImpl.Setting;

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

            #region Category Services

            RetailPOSUnityContainer.Register<ICategoryService, CategoryServiceImpl>();

            #endregion

            #region Product Services

            RetailPOSUnityContainer.Register<IProductService, ProductServiceImpl>();

            #endregion

            #region User Services

            RetailPOSUnityContainer.Register<IStaffService, StaffServiceImpl>();
            RetailPOSUnityContainer.Register<IUserService, UserServiceImpl>();

            #endregion

            #region Customer Services

            RetailPOSUnityContainer.Register<ICustomerService, CustomerServiceImpl>();
            
            #endregion

            #region Shop Setting Services
            
            RetailPOSUnityContainer.Register<ISettingService, ShopSettingServiceImpl>();

            #endregion

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