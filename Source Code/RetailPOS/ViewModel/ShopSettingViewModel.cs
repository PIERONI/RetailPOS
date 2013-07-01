using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;

namespace RetailPOS.ViewModel
{
   public class ShopSettingViewModel : ViewModelBase
   {
       #region Declare Public and Private Memebers

       public ObservableCollection<CurrencyModel> LstCurrency { get; private set; }
       public ObservableCollection<CountryDTO> LstCountry { get; private set; }

       private string _shopName;
       private string _phone;
       private string _fax;
       private string _email;
       private string _website;
       private string _address;
       private decimal _rate;

       private Visibility _Visible;
       private CurrencyModel _selectedCurrency;
       private CountryDTO _selectedCountry;
       public ShopSettingDTO shopSettingDetails { get; set; }

       public RelayCommand SaveShopSetting { get; private set; }
       public RelayCommand CancelShopSetting { get; private set; }
       public RelayCommand <int> IsScheduledCheck { get; set; }

       public Visibility VisibleTimePicker
       {
           get
           {
               return _Visible;
           }
           set
           {
               _Visible = value;
               RaisePropertyChanged("VisibleTimePicker");
           }
        }

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

       public CountryDTO SelectedCountry
       {
           get { return _selectedCountry; }
           set
           {
               _selectedCountry = value;
               RaisePropertyChanged("SelectedCountry");
           }
       }  

       #endregion

       /// <summary>
       /// Initializes a new instance of the <see cref="ShopSettingViewModel"/> class.
       /// </summary>
       public ShopSettingViewModel()
       {
           LstCurrency = new ObservableCollection<CurrencyModel>();
           LstCountry = new ObservableCollection<CountryDTO>();

           AddCurrency();
           GetCountryDetails();

           SaveShopSetting = new RelayCommand(SaveSetting);
           CancelShopSetting = new RelayCommand(CancelSetting);
           IsScheduledCheck = new RelayCommand<int>(ShowTimer);
           VisibleTimePicker = Visibility.Collapsed;
       }

       /// <summary>
       /// Shows the timer.
       /// </summary>
       /// <param name="Obj">The obj.</param>
       private void ShowTimer(int Obj)
       {
           VisibleTimePicker = Obj == 0 ? Visibility.Collapsed : Visibility.Visible;
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
           ServiceFactory.ServiceClient.SaveShopSetting(shopSettingDetails);
       }

       private ShopSettingDTO InitializeShopSettingDetails()
       {
           ShopSettingDTO shopSettingDetails = new ShopSettingDTO();
           shopSettingDetails.Name = ShopName;
           shopSettingDetails.Phone = Phone;
           shopSettingDetails.Fax = Fax;
           shopSettingDetails.Email = Email;
           shopSettingDetails.Website = Website;
           shopSettingDetails.Tax_rate = Convert.ToDecimal(Rate);
           shopSettingDetails.Currency = Convert.ToInt16(SelectedCurrency.CurrencyId);
           shopSettingDetails.Address = InitializeAddressDetails();
           return shopSettingDetails;
       }

       private AddressDTO InitializeAddressDetails()
       {
           AddressDTO addressDetails = new AddressDTO();
           addressDetails.Id = 0;
           //addressDetails.Building_name=

           return addressDetails;
       }

       private void GetCountryDetails()
       {
           LstCountry = new ObservableCollection<CountryDTO>(ServiceFactory.ServiceClient.GetCountryDetails());
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

   public class AddressModel
   {
   }
}
