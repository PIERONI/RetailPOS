using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace RetailPOS.ViewModel
{
   public class SettingViewModel : ViewModelBase
   {
       #region Declare Public and Private Data member
       
       private Visibility _isCategoryVisible;
       private Visibility _isCustomerVisible;
       private Visibility _isProductVisible;
       private Visibility _isShopSettingVisible;
       private Visibility _issearchPromotionalOfferVisible;
       #endregion

       #region Public Properties

       public RelayCommand OpenShopSettingCmd { get; private set; }
       public RelayCommand OpenCategorySettingCmd { get; private set; }
       public RelayCommand OpenCustomerCmd { get; private set; }
       public RelayCommand OpenProductWindowCmd { get; private set; }
       public RelayCommand OpenSettingWindowCmd { get; private set; }
       public RelayCommand BackToMainWindow { get; private set; }
       public RelayCommand OpenSearchPromotionalOffer { get; private set; }

       public Visibility IsCategoryVisible
       {
           get
           {
               return _isCategoryVisible;
           }
           set
           {
               _isCategoryVisible = value;
               RaisePropertyChanged("IsCategoryVisible");
           }
       }

       public Visibility IsCustomerVisible
       {
           get
           {
               return _isCustomerVisible;
           }
           set
           {
               _isCustomerVisible = value;
               RaisePropertyChanged("IsCustomerVisible");
           }
       }

       public Visibility IsProductVisible
       {
           get
           {
               return _isProductVisible;
           }
           set
           {
               _isProductVisible = value;
               RaisePropertyChanged("IsProductVisible");
           }
       }

       public Visibility IsShopSettingVisible
       {
           get
           {
               return _isShopSettingVisible;
           }
           set
           {
               _isShopSettingVisible = value;
               RaisePropertyChanged("IsShopSettingVisible");
           }
       }

       public Visibility IsSearchPromotionalOfferVisible
       {
           get
           {
               return _issearchPromotionalOfferVisible;
           }
           set
           {
               _issearchPromotionalOfferVisible = value;
               RaisePropertyChanged("IsSearchPromotionalOfferVisible");
           }
       }
       #endregion

       /// <summary>
       /// Initializes a new instance of the <see cref="SettingViewModel"/> class.
       /// </summary>
       public SettingViewModel()
       {
           HideSettings();

           OpenSettingWindowCmd = new RelayCommand(OpenSettingWindow);
           OpenShopSettingCmd = new RelayCommand(OpenShopSettingWindow);
           OpenCategorySettingCmd = new RelayCommand(OpenCategoryWindow);
           OpenCustomerCmd = new RelayCommand(OpenCustomerWindow);
           OpenProductWindowCmd = new RelayCommand(OpenProduct);
           OpenSearchPromotionalOffer = new RelayCommand(OpenSearchPromotionalWindow);

           BackToMainWindow = new RelayCommand(OpenMainWindow);
       }

       /// <summary>
       /// Hides the settings.
       /// </summary>
       private void HideSettings()
       {
           IsSearchPromotionalOfferVisible = Visibility.Collapsed;
           IsProductVisible = Visibility.Collapsed;
           IsShopSettingVisible = Visibility.Collapsed;
           IsCategoryVisible = Visibility.Collapsed;
           IsCustomerVisible = Visibility.Collapsed;
       }

       /// <summary>
       /// Opens the product.
       private void OpenProduct()
       {
           ////Hide Previous opened settings tab
           HideSettings();

           IsProductVisible = Visibility.Visible;
       }
      
       /// <summary>
       /// Opens the customer window.
       /// </summary>
       private void OpenCustomerWindow()
       {
           ////Hide Previous opened settings tab
           HideSettings();

           IsCustomerVisible = Visibility.Visible;
       }

       /// <summary>
       /// Opens the main window.
       /// </summary>
       private void OpenMainWindow()
       {
         
       }

       /// <summary>
       /// Checks for setting win close.
       /// </summary>
       private void CheckForSettingWinClose()
       {
       }

       /// <summary>
       /// Opens the category window.
       /// </summary>
       private void OpenCategoryWindow()
       {
           ////Hide Previous opened settings tab
           HideSettings();

           IsCategoryVisible = Visibility.Visible;
       }

       /// <summary>
       /// Opens the shop setting window.
       /// </summary>
       private void OpenShopSettingWindow()
       {
           ////Hide Previous opened settings tab
           HideSettings();

           IsShopSettingVisible = Visibility.Visible;
       }

       /// <summary>
       /// Opens the setting window.
       /// </summary>
       private void OpenSettingWindow()
       {
           Settings set = new Settings();
           set.Show();
           MainWindow._MainWindow.Close();
       }
       /// <summary>
       /// Opens the SearchpromotionalOffer window.
       /// </summary>
       private void OpenSearchPromotionalWindow()
       {
           HideSettings();
           IsSearchPromotionalOfferVisible = Visibility.Visible;
       }
    }
}
