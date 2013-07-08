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
            SimpleIoc.Default.Register<SettingViewModel>();
            SimpleIoc.Default.Register<ShopSettingViewModel>();
            SimpleIoc.Default.Register<RightPanelPaymentDetailViewModel>();
            SimpleIoc.Default.Register<AddCustomerViewModel>();
            SimpleIoc.Default.Register<AddProductViewModel>();
            SimpleIoc.Default.Register<MenuControlViewModel>();
            SimpleIoc.Default.Register<WasteManagementViewModel>();
            SimpleIoc.Default.Register<PromotionalOfferViewModel>();
            SimpleIoc.Default.Register<AddCategoryViewModel>();
        }

        /// <summary>
        /// Gets the setting VM.
        /// </summary>
        /// <value>
        /// The setting VM.
        /// </value>
        public SettingViewModel SettingVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingViewModel>();
            }
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

        /// <summary>
        /// Gets the shop setting VM.
        /// </summary>
        /// <value>
        /// The shop setting VM.
        /// </value>
        public ShopSettingViewModel ShopSettingVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ShopSettingViewModel>();
            }
        }

        /// <summary>
        /// Gets the shop Right Panel Payment Detail View Model.
        /// </summary>
        /// <value>
        /// The shop setting VM.
        /// </value>
        public RightPanelPaymentDetailViewModel RightPanelPaymentDetailVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RightPanelPaymentDetailViewModel>();
            }
        }

        /// <summary>
        /// Gets the shop Add Customer View Model.
        /// </summary>
        /// <value>
        /// The shop setting VM.
        /// </value>
        public AddCustomerViewModel CustomerVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddCustomerViewModel>();
            }
        }

        /// <summary>
        /// Gets the shop setting Add Product View Model.
        /// </summary>
        /// <value>
        /// The Add Product View Model.
        /// </value>
        public AddProductViewModel ProductVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddProductViewModel>();
            }
        }

        public MenuControlViewModel MenuControlVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MenuControlViewModel>();
            }
        }

        /// <summary>
        /// Gets the Wastemanagement View Model.
        /// </summary>
        /// <value>
        /// The Waste Management view model.
        /// </value>
        public WasteManagementViewModel WasteManagementVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WasteManagementViewModel>();
            }
        }

        /// <summary>
        /// Gets the PromotionalOffer View Model.
        /// </summary>
        /// <value>
        /// The PromotionalOffer view model.
        /// </value>
        public PromotionalOfferViewModel PromotionalOfferVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PromotionalOfferViewModel>();
            }
        }

        /// <summary>
        /// Gets the Add Category View Model.
        /// </summary>
        /// <value>
        /// The Add Category view model.
        /// </value>
        public AddCategoryViewModel AddCategoryVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddCategoryViewModel>();
            }
        }

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        public static void Cleanup()
        {  
            SimpleIoc.Default.Unregister<CategoryViewModel>();
            SimpleIoc.Default.Unregister<LoginViewModel>();
            SimpleIoc.Default.Unregister<SearchViewModel>();
            SimpleIoc.Default.Unregister<UserInfoViewModel>();
            SimpleIoc.Default.Unregister<ProductGridViewModel>();
            SimpleIoc.Default.Unregister<SettingViewModel>();
            SimpleIoc.Default.Unregister<ShopSettingViewModel>();
            SimpleIoc.Default.Unregister<RightPanelPaymentDetailViewModel>();
            SimpleIoc.Default.Register<AddCustomerViewModel>();
            SimpleIoc.Default.Register<AddProductViewModel>();
            SimpleIoc.Default.Register<MenuControlViewModel>();
            SimpleIoc.Default.Register<WasteManagementViewModel>();
            SimpleIoc.Default.Register<PromotionalOfferViewModel>();
            SimpleIoc.Default.Register<MenuControlViewModel>();
            SimpleIoc.Default.Register<AddProductViewModel>();
        }
    }
}