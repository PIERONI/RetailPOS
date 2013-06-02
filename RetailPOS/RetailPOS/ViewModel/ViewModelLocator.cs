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
        
        public static void Cleanup()
        {  
            SimpleIoc.Default.Unregister<CategoryViewModel>();
            SimpleIoc.Default.Unregister<LoginViewModel>();
        }
    }
}