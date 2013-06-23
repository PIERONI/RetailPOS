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
           if (ShopSettingWindow._ShopSettingWindow != null)
               ShopSettingWindow._ShopSettingWindow.Close();


       }

       /// <summary>
       /// Backs to main.
       /// </summary>
       private void BackToMain()
       {
           Settings.SettingWindow.Close();
           MainWindow MW = new MainWindow();
           MW.Show();
       }

       /// <summary>
       /// Opens the setting window.
       /// </summary>
       private void OpenSettingWindow()
       {
           Settings.SettingWindow.Show();
           MainWindow._MainWindow.Close();

       }
    }
}
