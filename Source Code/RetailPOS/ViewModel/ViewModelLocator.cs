#region Using directives

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using RetailPOS.ViewModel.MainWindow;
using RetailPOS.ViewModel.Settings;
using RetailPOS.Constants;

#endregion

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
            SimpleIoc.Default.Register<CustomerViewModel>();
            SimpleIoc.Default.Register<AddProductViewModel>();
            SimpleIoc.Default.Register<MenuControlViewModel>();
            SimpleIoc.Default.Register<WasteManagementViewModel>();
            SimpleIoc.Default.Register<PromotionalOfferViewModel>();
            SimpleIoc.Default.Register<AddCategoryViewModel>();
            SimpleIoc.Default.Register<ShowProductViewModel>();
            SimpleIoc.Default.Register<PurchaseHistoryViewModel>();
            SimpleIoc.Default.Register<AddressViewModel>();
            SimpleIoc.Default.Register<SetAsideOrderViewModel>();
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
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<CategoryViewModel>())
                {
                    SimpleIoc.Default.Register<CategoryViewModel>();
                }
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
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<SearchViewModel>())
                {
                    SimpleIoc.Default.Register<SearchViewModel>();
                }
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
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<ProductGridViewModel>())
                {
                    SimpleIoc.Default.Register<ProductGridViewModel>();
                }
                return ServiceLocator.Current.GetInstance<ProductGridViewModel>();
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
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<RightPanelPaymentDetailViewModel>())
                {
                    SimpleIoc.Default.Register<RightPanelPaymentDetailViewModel>();
                }
                return ServiceLocator.Current.GetInstance<RightPanelPaymentDetailViewModel>();
            }
        }

        /// <summary>
        /// Gets the menu control VM.
        /// </summary>
        /// <value>
        /// The menu control VM.
        /// </value>
        public MenuControlViewModel MenuControlVM
        {
            get
            {
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<MenuControlViewModel>())
                {
                    SimpleIoc.Default.Register<MenuControlViewModel>();
                }
                return ServiceLocator.Current.GetInstance<MenuControlViewModel>();
            }
        }

        /// <summary>
        /// Gets the Show Product View Model.
        /// </summary>
        /// <value>
        /// The Show Product view model.
        /// </value>
        public ShowProductViewModel ShowProductVM
        {
            get
            {
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<ShowProductViewModel>())
                {
                    SimpleIoc.Default.Register<ShowProductViewModel>();
                }
                return ServiceLocator.Current.GetInstance<ShowProductViewModel>();
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
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<ShopSettingViewModel>())
                {
                    SimpleIoc.Default.Register<ShopSettingViewModel>();
                }
                return ServiceLocator.Current.GetInstance<ShopSettingViewModel>();
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
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<AddCategoryViewModel>())
                {
                    SimpleIoc.Default.Register<AddCategoryViewModel>();
                }
                return ServiceLocator.Current.GetInstance<AddCategoryViewModel>();
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
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<AddProductViewModel>())
                {
                    SimpleIoc.Default.Register<AddProductViewModel>();
                }
                return ServiceLocator.Current.GetInstance<AddProductViewModel>();
            }
        }

        /// Gets the shop Add Customer View Model.
        /// </summary>
        /// <value>
        /// The shop setting VM.
        /// </value>
        public CustomerViewModel CustomerVM
        {
            get
            {
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<CustomerViewModel>())
                {
                    SimpleIoc.Default.Register<CustomerViewModel>();
                }
                return ServiceLocator.Current.GetInstance<CustomerViewModel>();
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
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<WasteManagementViewModel>())
                {
                    SimpleIoc.Default.Register<WasteManagementViewModel>();
                }
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
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<PromotionalOfferViewModel>())
                {
                    SimpleIoc.Default.Register<PromotionalOfferViewModel>();
                }
                return ServiceLocator.Current.GetInstance<PromotionalOfferViewModel>();
            }
        }

        /// <summary>
        /// Gets the Purchase History View Model.
        /// </summary>
        /// <value>
        /// The Purchase History view model.
        /// </value>
        public PurchaseHistoryViewModel PurchaseHistoryVM
        {
            get
            {
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<PurchaseHistoryViewModel>())
                {
                    SimpleIoc.Default.Register<PurchaseHistoryViewModel>();
                }
                return ServiceLocator.Current.GetInstance<PurchaseHistoryViewModel>();
            }
        }

        /// <summary>
        /// Gets the Address View Model.
        /// </summary>
        /// <value>
        /// The Address view model.
        /// </value>
        public AddressViewModel AddressVM
        {
            get
            {
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<AddressViewModel>())
                {
                    SimpleIoc.Default.Register<AddressViewModel>();
                }
                return ServiceLocator.Current.GetInstance<AddressViewModel>();
            }
        }
        /// <summary>
        /// Gets the SetAsideOrderViewModel View Model.
        /// </summary>
        /// <value>
        /// The SetAsideOrderViewModel view model.
        /// </value>
        public SetAsideOrderViewModel SetAsideVM
        {
            get
            {
                if (!((SimpleIoc)(ServiceLocator.Current)).IsRegistered<SetAsideOrderViewModel>())
                {
                    SimpleIoc.Default.Register<SetAsideOrderViewModel>();
                }
                return ServiceLocator.Current.GetInstance<SetAsideOrderViewModel>();
            }
        }

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        public static void Cleanup()
        {
            SimpleIoc.Default.Unregister<UserInfoViewModel>();
            SimpleIoc.Default.Unregister<LoginViewModel>();
            SimpleIoc.Default.Unregister<SettingViewModel>();
            SimpleIoc.Default.Unregister<SetAsideOrderViewModel>();
            
        }

        public static void Cleanup(ViewModelType viewModelType)
        {
            switch (viewModelType)
            {
                case ViewModelType.Settings:
                    UnRegisterSettingsViewModels();
                    break;

                case ViewModelType.MenuControl:
                    SimpleIoc.Default.Unregister<MenuControlViewModel>();
                    SimpleIoc.Default.Unregister<SearchViewModel>();
                    break;

                case ViewModelType.MainWindow:
                    UnRegisterMainWindowSettingsViewModels();
                    break;
            }
        }

        private static void UnRegisterMainWindowSettingsViewModels()
        {
            SimpleIoc.Default.Unregister<CategoryViewModel>();
            SimpleIoc.Default.Unregister<ProductGridViewModel>();
            SimpleIoc.Default.Unregister<RightPanelPaymentDetailViewModel>();
            SimpleIoc.Default.Unregister<ShowProductViewModel>();
        }

        private static void UnRegisterSettingsViewModels()
        {
            SimpleIoc.Default.Unregister<ShopSettingViewModel>();
            SimpleIoc.Default.Unregister<CustomerViewModel>();
            SimpleIoc.Default.Unregister<AddCategoryViewModel>();
            SimpleIoc.Default.Unregister<AddProductViewModel>();
            SimpleIoc.Default.Unregister<WasteManagementViewModel>();
            SimpleIoc.Default.Unregister<PromotionalOfferViewModel>();
            SimpleIoc.Default.Unregister<PurchaseHistoryViewModel>();
            SimpleIoc.Default.Unregister<AddressViewModel>();
            SimpleIoc.Default.Unregister<SetAsideOrderViewModel>();
        }
    }
}