using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using RetailPOS.RetailPOSService;

namespace RetailPOS.Core
{
    /// <summary>
    /// This class is used to hold the service proxy client information
    /// </summary>
    public class ServiceFactory
    {
        /// <summary>
        /// This pricate static member is used to hold the service proxy cleint instance
        /// </summary>
        private static RetailPOSServiceContractClient serviceClient;
        
        /// <summary>
        /// .ctor
        /// </summary>
        public ServiceFactory()
        {   
        }

        /// <summary>
        /// This method is used to instantiate the service proxy class instance
        /// </summary>
        /// <param name="serviceURL">service url</param>
        public static void InitializeServiceFactory(string serviceURL)
        {
            serviceClient = new RetailPOSServiceContractClient("*", serviceURL);
        }

        /// <summary>
        /// This property is used to hold the service proxy client object
        /// </summary>
        public static RetailPOSServiceContractClient ServiceClient
        {
            get { return serviceClient; }
            set
            {
                serviceClient = value;
            }
        }

        /// <summary>
        /// This method is used to register the object instances in unity container
        /// </summary>
        /// <typeparam name="T">generic type</typeparam>
        /// <param name="instance">instance</param>
        /// <param name="name">key name</param>
        public static void RegisterObjectInstance<T>(T instance, string name)
        {
            ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterInstance<T>(name, instance);
        }

        /// <summary>
        /// This method is used to get the registed instance from unity container
        /// </summary>
        /// <typeparam name="T">generic type</typeparam>
        /// <param name="name">key name</param>
        /// <returns>returns instance</returns>
        public static T GetRegisteredInstance<T>(string name)
        {
            return ServiceLocator.Current.GetInstance<IUnityContainer>().Resolve<T>(name, new ResolverOverride[] { });
        }

        /// <summary>
        /// This method is used to provide the linkage between Rad Window Content Data Context and Rad Window Content
        /// </summary>
        /// <typeparam name="T">DataContext Generic Type</typeparam>
        /// <typeparam name="TIterface">Interface Generic Type</typeparam>
        /// <typeparam name="TIterface">View Generic Type</typeparam>
        public static void CreateModelDialogModules<T, TIterface, Tview>() 
        {
            //call service locator method to register view and interface
            ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterType(typeof(TIterface), typeof(Tview), new InjectionMember[] { });
            
            //call service locator method to resolve data context class
            ServiceLocator.Current.GetInstance<IUnityContainer>().Resolve<T>();
        }
    }
}