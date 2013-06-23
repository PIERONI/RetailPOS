using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace RetailPOS.ViewModel
{
   public class ShopSettingViewModel : ViewModelBase
   {
       #region Declare Public and Private Memebers
       public ObservableCollection<CurrencyModel> LstCurrency { get; private set; }
       private string _shopName;
       private string _phone;
       private string _fax;
       private string _email;
       private string _website;
       private string _address;
       private decimal _rate;
       private CurrencyModel _selectedCurrency;
       public RelayCommand SaveShopSetting { get; private set; }
       public RelayCommand CancelShopSetting { get; private set; } 



       public string ShopName
       {
           get { return _shopName; }
           set
           {
               _shopName = value;
               RaisePropertyChanged("ShopName");
           }
       }
       public string Phone
       {
           get { return _phone; }
           set
           {
               _phone = value;
               RaisePropertyChanged("Phone");
           }
       }
       public string Fax
       {
           get { return _fax; }
           set
           {
               _fax = value;
               RaisePropertyChanged("Fax");
           }
       }
       public string Email
       {
           get { return _email; }
           set
           {
               _email = value;
               RaisePropertyChanged("Email");
           }
       }

       public string Website
       {
           get { return _website; }
           set
           {
               _website = value;
               RaisePropertyChanged("Website");
           }
       }
       public string Address
       {
           get { return _address; }
           set
           {
               _address = value;
               RaisePropertyChanged("Address");
           }
       }
       public decimal Rate
       {
           get { return _rate; }
           set
           {
               _rate = value;
               RaisePropertyChanged("Rate");
           }
       }
       public CurrencyModel SelectedCurrency
       {
           get { return _selectedCurrency; }
           set
           {
               _selectedCurrency = value;
               RaisePropertyChanged("SelectedCurrency");
           }
       }     

       #endregion

       /// <summary>
       /// Initializes a new instance of the <see cref="ShopSettingViewModel"/> class.
       /// </summary>
       public ShopSettingViewModel()
       {
           LstCurrency = new ObservableCollection<CurrencyModel>();
           AddCurrency();
           SaveShopSetting = new RelayCommand(SaveSetting);
           CancelShopSetting = new RelayCommand(CancelSetting);
       }

       /// <summary>
       /// Cancels the setting.
       /// </summary>
       private void CancelSetting()
       {
           ShopSettingViewModel vm = new ShopSettingViewModel();
       }

       /// <summary>
       /// Saves the setting.
       /// </summary>
       private void SaveSetting()
       {

       }

       private void AddCurrency()
       {
           LstCurrency.Add(new CurrencyModel { CurrencyId = 1, CurrencyName = "GDB" });
           LstCurrency.Add(new CurrencyModel { CurrencyId = 2, CurrencyName = "INR" });
           LstCurrency.Add(new CurrencyModel { CurrencyId = 3, CurrencyName = "USD" });
           LstCurrency.Add(new CurrencyModel { CurrencyId = 4, CurrencyName = "SHD" });
       }

    }

   public class CurrencyModel
   {
       public int CurrencyId { get; set; }
       public string CurrencyName { get; set; }

   }
}
