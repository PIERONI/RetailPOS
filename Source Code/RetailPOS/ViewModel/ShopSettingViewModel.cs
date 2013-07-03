﻿#region Using directives

using System;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using System.Windows.Data;

#endregion

namespace RetailPOS.ViewModel
{
    public class ShopSettingViewModel : ViewModelBase
    {
        #region Declare Public and Private Memebers

        public ObservableCollection<CountryDTO> LstCountry { get; private set; }
      
       

        public RelayCommand SaveShopSetting { get; private set; }
        public RelayCommand CancelShopSetting { get; private set; }
        public RelayCommand<int> IsScheduledCheck { get; set; }

        private string _shopName;
        private string _phone;
        private string _fax;
        private string _email;
        private string _website;
        private string _address;
        private decimal _rate;
        private ObservableCollection<TownCityDTO> _lstTownCity;
        private ObservableCollection<PostCodeDTO> _lstPostalCode;
        private Visibility _Visible;
        private CountryDTO _selectedCountry;
        private TownCityDTO _selectedTownCity;
        private PostCodeDTO _selectedPostalCode;
        public ShopSettingDTO shopSettingDetails { get; set; }


        public ObservableCollection<PostCodeDTO> LstPostalCode
        {
            get
            {
                return _lstPostalCode;
            }
            set
            {
                _lstPostalCode = value;
                RaisePropertyChanged("LstPostalCode");
            }
        }

        public ObservableCollection<TownCityDTO> LstTownCity 
        {
            get
            {
                return _lstTownCity;
            }
            set
            {
                _lstTownCity = value;
                RaisePropertyChanged("LstTownCity");
            }

        }
        
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

        public CountryDTO SelectedCountry
        {
            get
            {   
                return _selectedCountry;
            }
            set
            {
                _selectedCountry = value;
                RaisePropertyChanged("SelectedCountry");
                if(SelectedCountry!=null) GetTownByContryId();
            }
        }

        public TownCityDTO SelectedTownCity
        {
            get { return _selectedTownCity; }
            set
            {
                _selectedTownCity = value;
                RaisePropertyChanged("SelectedTownCity");

                if(SelectedTownCity!=null)  GetPostalCodeByTownCityId(_selectedTownCity.Id);
            }
        }

        public PostCodeDTO SelectedPostalCode
        {
            get { return _selectedPostalCode; }
            set
            {
                _selectedPostalCode = value;
                RaisePropertyChanged("SelectedPostalCode");
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopSettingViewModel"/> class.
        /// </summary>
        public ShopSettingViewModel()
        {
            LstCountry = new ObservableCollection<CountryDTO>();
            LstTownCity = new ObservableCollection<TownCityDTO>();
            LstPostalCode = new ObservableCollection<PostCodeDTO>();

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

        private void GetTownByContryId()
        {   
            ////Gets Cities based on selected country
            LstTownCity = new ObservableCollection<TownCityDTO>(ServiceFactory.ServiceClient.GetTownCityDetails(SelectedCountry.Id));

            //CollectionViewSource.GetDefaultView(this.LstTownCity).Refresh();

            if (LstTownCity.Count > 0)
            {
                SelectedTownCity = LstTownCity[0];
            }
        }

        private void GetPostalCodeByTownCityId(int towncityId)
        {
            LstPostalCode = new ObservableCollection<PostCodeDTO>(ServiceFactory.ServiceClient.GetPostalCodeDetail(towncityId));
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