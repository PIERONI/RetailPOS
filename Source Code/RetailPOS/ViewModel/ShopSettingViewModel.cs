#region Using directives

using System;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.CommonLayer.DataTransferObjects.Master;
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
        private ObservableCollection<PostCodeDTO> _lstPostalCode;

        private string _name;
        private string _phone;
        private string _fax;
        private string _email;
        private string _website;
        private string _address;
        private decimal _rate;

        private Visibility _visible;
        private CountryDTO _selectedCountry;
        private TownCityDTO _selectedTownCity;
        private PostCodeDTO _selectedPostalCode;
        private string _code;
        private string _currency;
        private string _buildingName;
        private string _houseNo;
        private LocalityDTO _selectedLocality;
        private StreetDTO _selectedStreet;
        public ShopSettingDTO ShopSettingDetails { get; set; }

        #endregion

        #region Public Properties

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
                return _visible;
            }
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

        public string Curreny
        {
            get { return _currency; }
            set
            {
                _currency = value;
                RaisePropertyChanged("Curreny");
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

        public string BuildingName
        {
            get { return _buildingName; }
            set
            {
                _buildingName = value;
                RaisePropertyChanged("BuildingName");

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

                if (SelectedCountry != null)
                {
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
                    GetPostalCodeByTownCityId(_selectedTownCity.Id);
                }
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

        public StreetDTO SelectedStreet
        {
            get { return _selectedStreet; }
            set
            {
                _selectedStreet = value;
                RaisePropertyChanged("SelectedStreet");
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

        #endregion

        #region Constructor

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
        /// Saves the setting.
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
                                         Tax_rate = Convert.ToDecimal(Rate),
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
                                     Country_Id = SelectedCountry.Id,
                                     House_No = HouseNo,
                                     Locality_Id = SelectedLocality.Id,
                                     PostCode_Id = SelectedPostalCode.Id,
                                     Street_Id = SelectedStreet.Id,
                                     Town_City_Id = SelectedTownCity.Id
                                 };
        }

        private void GetCountryDetails()
        {
            LstCountry = new ObservableCollection<CountryDTO>(ServiceFactory.ServiceClient.GetCountryDetails());
        }

        private void GetTownByContryId()
        {
            ////Gets Cities based on selected country
            LstTownCity = new ObservableCollection<TownCityDTO>(ServiceFactory.ServiceClient.GetTownCityDetails(SelectedCountry.Id));

            if (LstTownCity.Count > 0)
            {
                SelectedTownCity = LstTownCity[0];
            }
        }

        private void GetPostalCodeByTownCityId(int towncityId)
        {
            LstPostalCode = new ObservableCollection<PostCodeDTO>(ServiceFactory.ServiceClient.GetPostalCodeDetail(towncityId));
        }

        #endregion
    }
}