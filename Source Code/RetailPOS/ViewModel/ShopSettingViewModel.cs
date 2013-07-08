#region Using directives

using System;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using AddressDTO = RetailPOS.RetailPOSService.AddressDTO;
using CountryDTO = RetailPOS.RetailPOSService.CountryDTO;
using PostCodeDTO = RetailPOS.RetailPOSService.PostCodeDTO;
using TownCityDTO = RetailPOS.RetailPOSService.TownCityDTO;

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

        private ObservableCollection<TownCityDTO> _lstTownCity;
        private ObservableCollection<LocalityDTO> _lstLocality;
        private ObservableCollection<StreetDTO> _lstStreet;
        public ObservableCollection<PostCodeDTO> _lstPostalCode;

        private Visibility _visible;

        private string _code;
        private string _name;
        private string _phone;
        private string _email;
        private string _fax;
        private string _website;
        private string _address;
        private string _currency;
        private decimal _taxRate;

        private string _buildingName;
        private string _houseNo;
        private StreetDTO _selectedStreet;
        private LocalityDTO _selectedLocality;
        private CountryDTO _selectedCountry;
        private TownCityDTO _selectedTownCity;
        private PostCodeDTO _selectedPostalCode;

        #endregion

        #region Public Properties

        public ObservableCollection<TownCityDTO> LstTownCity
        {
            get { return _lstTownCity; }
            set
            {
                _lstTownCity = value;
                RaisePropertyChanged("LstTownCity");
            }
        }

        public ObservableCollection<LocalityDTO> LstLocality
        {
            get { return _lstLocality; }
            set
            {
                _lstLocality = value;
                RaisePropertyChanged("LstLocality");
            }
        }

        public ObservableCollection<StreetDTO> LstStreet
        {
            get { return _lstStreet; }
            set
            {
                _lstStreet = value;
                RaisePropertyChanged("LstStreet");
            }
        }

        public ObservableCollection<PostCodeDTO> LstPostalCode
        {
            get { return _lstPostalCode; }
            set
            {
                _lstPostalCode = value;
                RaisePropertyChanged("LstPostalCode");
            }
        }

        public Visibility VisibleTimePicker
        {
            get { return _visible; }
            set
            {
                _visible = value;
                RaisePropertyChanged("VisibleTimePicker");
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                RaisePropertyChanged("Code");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
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

        public string Curreny
        {
            get { return _currency; }
            set
            {
                _currency = value;
                RaisePropertyChanged("Curreny");
            }
        }

        public decimal TaxRate
        {
            get { return _taxRate; }
            set
            {
                _taxRate = value;
                RaisePropertyChanged("TaxRate");
            }
        }

        public string BuildingName
        {
            get { return _buildingName; }
            set
            {
                _buildingName = value;
                RaisePropertyChanged("BuildingName");
            }
        }

        public string HouseNo
        {
            get { return _houseNo; }
            set
            {
                _houseNo = value;
                RaisePropertyChanged("HouseNo");
            }
        }

        public CountryDTO SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                _selectedCountry = value;
                RaisePropertyChanged("SelectedCountry");

                if (SelectedCountry != null)
                {
                    ////Get Town cities based on selected country
                    GetTownByContryId();
                }
            }
        }

        public TownCityDTO SelectedTownCity
        {
            get { return _selectedTownCity; }
            set
            {
                _selectedTownCity = value;
                RaisePropertyChanged("SelectedTownCity");

                if (SelectedTownCity != null)
                {
                    ////Get Localities based on selected towncity
                    GetLocalityByTownCity();
                }
            }
        }

        public LocalityDTO SelectedLocality
        {
            get
            {
                return _selectedLocality;
            }
            set
            {
                _selectedLocality = value;
                RaisePropertyChanged("SelectedLocality");

                if (SelectedLocality != null)
                {
                    ////Get street details based on selected locality
                    GetStreetByLocality();

                    ////Get postal code based on selected locality
                    GetPostalCodeByLocality();
                }
            }
        }

        public StreetDTO SelectedStreet
        {
            get { return _selectedStreet; }
            set
            {
                _selectedStreet = value;
                RaisePropertyChanged("SelectedStreet");
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

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopSettingViewModel"/> class.
        /// </summary>
        public ShopSettingViewModel()
        {
            LstCountry = new ObservableCollection<CountryDTO>();
            LstTownCity = new ObservableCollection<TownCityDTO>();
            LstLocality = new ObservableCollection<LocalityDTO>();
            LstStreet = new ObservableCollection<StreetDTO>();
            LstPostalCode = new ObservableCollection<PostCodeDTO>();

            ////Get all active country details
            GetCountryDetails();

            SaveShopSetting = new RelayCommand(SaveSetting);
            CancelShopSetting = new RelayCommand(CancelSetting);
            IsScheduledCheck = new RelayCommand<int>(ShowTimer);
            VisibleTimePicker = Visibility.Collapsed;
        }

        #endregion

        #region Private Methods

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
        /// Saves shop setting details.
        /// </summary>
        private void SaveSetting()
        {
            var shopSettingDetails = InitializeShopSettingDetails();
            ServiceFactory.ServiceClient.SaveShopSetting(shopSettingDetails);
        }

        private ShopSettingDTO InitializeShopSettingDetails()
        {
            return new ShopSettingDTO
            {
                Code = Code,
                Name = Name,
                Phone = Phone,
                Fax = Fax,
                Email = Email,
                Website = Website,
                Tax_rate = Convert.ToDecimal(TaxRate),
                Currency = Curreny,
                Address = InitializeAddressDetails()
            };
        }

        private AddressDTO InitializeAddressDetails()
        {
            return new AddressDTO
            {
                Id = 0,
                Building_name = BuildingName,
                House_No = HouseNo,
                Country_Id = SelectedCountry.Id,
                Town_City_Id = SelectedTownCity.Id,
                Locality_Id = SelectedLocality.Id,
                Street_Id = SelectedStreet.Id,
                PostCode_Id = SelectedPostalCode.Id
            };
        }

        /// <summary>
        /// Get all active country details
        /// </summary>
        private void GetCountryDetails()
        {
            LstCountry = new ObservableCollection<CountryDTO>(ServiceFactory.ServiceClient.GetCountryDetails());
        }

        /// <summary>
        /// Get Town cities based on selected country
        /// </summary>
        private void GetTownByContryId()
        {
            LstTownCity = new ObservableCollection<TownCityDTO>(ServiceFactory.ServiceClient.GetTownCityDetails(SelectedCountry.Id));
        }

        /// <summary>
        /// Get Localities based on selected towncity
        /// </summary>
        private void GetLocalityByTownCity()
        {
            LstLocality = new ObservableCollection<LocalityDTO>(ServiceFactory.ServiceClient.GetLocalityDetails(SelectedTownCity.Id));

            if (LstLocality.Count > 0)
            {
                SelectedLocality = LstLocality[0];
            }
        }

        /// <summary>
        /// Get street details based on selected locality
        /// </summary>
        private void GetStreetByLocality()
        {
            LstStreet = new ObservableCollection<StreetDTO>(ServiceFactory.ServiceClient.GetStreetDetails(SelectedLocality.Id));

            if (LstStreet.Count > 0)
            {
                SelectedStreet = LstStreet[0];
            }
        }

        /// <summary>
        /// Get postal code based on selected locality
        /// </summary>
        private void GetPostalCodeByLocality()
        {
            LstPostalCode = new ObservableCollection<PostCodeDTO>(ServiceFactory.ServiceClient.GetPostalCodeDetails(SelectedLocality.Id));

            if (LstLocality.Count > 0)
            {
                SelectedPostalCode = LstPostalCode[0];
            }
        }

        #endregion
    }
}