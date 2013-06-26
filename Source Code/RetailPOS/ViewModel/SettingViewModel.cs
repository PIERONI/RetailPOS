using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

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

       }

       /// <summary>
       /// Opens the product.
       /// </summary>
       private void OpenProduct()
       {
           AddProductWindow Apw = new AddProductWindow();
           Apw.Show();
           Settings.SettingWindow.Close();

       }

       /// <summary>
       /// Opens the customer window.
       /// </summary>
       private void OpenCustomerWindow()
       {
           CustomerWindow Cw = new CustomerWindow();
           Cw.Show();
           Settings.SettingWindow.Close();
       }

       /// <summary>
       /// Opens the main window.
       /// </summary>
       private void OpenMainWindow()
       {
           MainWindow MW = new MainWindow();
           MW.Show();
           CheckForSettingWinClose();
       }

       /// <summary>
       /// Checks for setting win close.
       /// </summary>
       private void CheckForSettingWinClose()
       {
           if (ShopSettingWindow._ShopSettingWindow != null)
               ShopSettingWindow._ShopSettingWindow.Close();
           if (CategorySettingWindow._AddCategoryWindow != null)
               CategorySettingWindow._AddCategoryWindow.Close();
           if (CustomerWindow._CustomerWindow != null)
               CustomerWindow._CustomerWindow.Close();
       }

       /// <summary>
       /// Opens the category window.
       /// </summary>
       private void OpenCategoryWindow()
       {
           CategorySettingWindow ACW = new CategorySettingWindow();
           ACW.Show();
           Settings.SettingWindow.Close();
       }

       /// <summary>
       /// Opens the shop setting window.
       /// </summary>
       private void OpenShopSettingWindow()
       {
           ShopSettingWindow Ssw = new ShopSettingWindow();
           Ssw.Show();
           Settings.SettingWindow.Close();

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
           
           MainWindow MW = new MainWindow();
           MW.Show();
           Settings.SettingWindow.Close();
       }

       /// <summary>
       /// Opens the setting window.
       /// </summary>
       private void OpenSettingWindow()
       {
           Settings.SettingWindow = new Settings();
           Settings.SettingWindow.Show();
           MainWindow._MainWindow.Close();

       }
    }
}
