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
       public RelayCommand OpenSettingWindowCmd { get; private set; }
       public RelayCommand BackToMainWindow { get; private set; }
       public RelayCommand <Object>  BackToSettingWindow { get; private set; }
       public RelayCommand OpenShopSettingCmd { get; private set; }
       public RelayCommand OpenCategorySettingCmd { get; private set; }
       public RelayCommand BackToMainWin { get; private set; }
       public RelayCommand OpenCustomerCmd { get; private set; }
       public RelayCommand OpenProductWindowCmd { get; private set; }
       private Visibility _isCategoryVisible;
       private Visibility _isCustomerVisible;
       private Visibility _isProductVisible;
       private Visibility _isShopSettingVisible;
      
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
       #endregion

       /// <summary>
       /// Initializes a new instance of the <see cref="SettingViewModel"/> class.
       /// </summary>
       public SettingViewModel()
       {
           OpenSettingWindowCmd = new RelayCommand(OpenSettingWindow);
           BackToMainWindow = new RelayCommand(BackToMain);
           BackToSettingWindow = new RelayCommand<Object>(BackToSetting);
           OpenShopSettingCmd = new RelayCommand(OpenShopSettingWindow);
           OpenCategorySettingCmd = new RelayCommand(OpenCategoryWindow);
           BackToMainWin = new RelayCommand(OpenMainWindow);
           OpenCustomerCmd = new RelayCommand(OpenCustomerWindow);
           OpenProductWindowCmd = new RelayCommand(OpenProduct);
           HideSettings();

       }

       /// <summary>
       /// Hides the settings.
       /// </summary>
       private void HideSettings()
       {
           IsProductVisible = Visibility.Collapsed;
           IsShopSettingVisible = Visibility.Collapsed;
           IsCategoryVisible = Visibility.Collapsed;
           IsCustomerVisible = Visibility.Collapsed;
       }

       /// <summary>
       /// Opens the product.
       /// </summary>
       private void OpenProduct()
       {
           IsProductVisible = Visibility.Visible;
           
       }

      


      
       /// <summary>
       /// Opens the customer window.
       /// </summary>
       private void OpenCustomerWindow()
       {
          
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
          
       }

       /// <summary>
       /// Opens the shop setting window.
       /// </summary>
       private void OpenShopSettingWindow()
       {
           

       }

       /// <summary>
       /// Backs to setting.
       /// </summary>
       private void BackToSetting(Object obj)
       {
           Settings.SettingWindow = new Settings();
           Settings.SettingWindow.Show();
           CheckForSettingWinClose();

       }

       /// <summary>
       /// Backs to main.
       /// </summary>
       private void BackToMain()
       {
           
         
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
    }
}
