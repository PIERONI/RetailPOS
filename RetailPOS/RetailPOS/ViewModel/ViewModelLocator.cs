using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace RetailPOS.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<CategoryViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<SearchViewModel>();
            SimpleIoc.Default.Register<UserInfoViewModel>();
            SimpleIoc.Default.Register<ProductGridViewModel>();
        }

        /// <summary>
        /// Represents Category View Model
        /// </summary>
        public CategoryViewModel CategoryVM
        {
            get
            {
               return ServiceLocator.Current.GetInstance<CategoryViewModel>();
            }
        }

        /// <summary>
        /// Represents Category View Model
        /// </summary>
        public LoginViewModel LoginVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }


        /// <summary>
        /// Gets the search VM.
        /// </summary>
        /// <value>
        /// The search VM.
        /// </value>
        public SearchViewModel SearchVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SearchViewModel>();
            }
        }

        /// <summary>
        /// Gets the user info VM.
        /// </summary>
        /// <value>
        /// The user info VM.
        /// </value>
        public UserInfoViewModel UserInfoVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserInfoViewModel>();
            }
        }

        /// <summary>
        /// Gets the product grid VM.
        /// </summary>
        /// <value>
        /// The product grid VM.
        /// </value>
        public ProductGridViewModel ProductGridVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProductGridViewModel>();
            }
        }
        
        public static void Cleanup()
        {  
            SimpleIoc.Default.Unregister<CategoryViewModel>();
            SimpleIoc.Default.Unregister<LoginViewModel>();
            SimpleIoc.Default.Unregister<SearchViewModel>();
            SimpleIoc.Default.Unregister<UserInfoViewModel>();
            SimpleIoc.Default.Unregister<ProductGridViewModel>();
        }
    }
}