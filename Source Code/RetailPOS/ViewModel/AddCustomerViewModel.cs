#region Using directives

using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace RetailPOS.ViewModel
{
    public class AddCustomerViewModel : ViewModelBase
    {
        #region Declare Public and Private Data member

        public ObservableCollection<CustomerStatusDTO> LstStatus { get; private set; }
        public ObservableCollection<CustomerTypeDTO> LstType { get; private set; }
        public ObservableCollection<CountryDTO> LstCountry { get; private set; }

        public RelayCommand SaveCustomer { get; set; }
        public RelayCommand CancelCustomerSetting { get; set; }
        public RelayCommand CancelSearchCustomer { get; private set; }

        private ObservableCollection<TownCityDTO> _lstTownCity;
        private ObservableCollection<LocalityDTO> _lstLocality;
        private ObservableCollection<StreetDTO> _lstStreet;
        private ObservableCollection<PostCodeDTO> _lstPostalCode;

        private CustomerTypeDTO _selectedType;
        private CustomerStatusDTO _selectedStatus;
        private IList<CustomerDTO> _lstSearchCustomer;

        private string _customerCode;
        private string _firstName;
        private string _lastName;
        private string _phone;
        private string _mobile;
        private string _filePath;
        private string _email;
        private int _paymentPeriod;
        private decimal _creditLimit;

        private string _buildingName;
        private string _houseNo;
        private StreetDTO _selectedStreet;
        private LocalityDTO _selectedLocality;
        private CountryDTO _selectedCountry;
        private TownCityDTO _selectedTownCity;
        private PostCodeDTO _selectedPostalCode;
        private CustomerDTO _customerName;

        #endregion

        #region Public Properties

        public string CustomerCode
        {
            get
            {
                return _customerCode;
            }
            set
            {
                _customerCode = value;
                RaisePropertyChanged("CustomerCode");
            }
        }

        public CustomerTypeDTO SelectedType
        {
            get
            {
                return _selectedType;
            }
            set
            {
                _selectedType = value;
                RaisePropertyChanged("SelectedType");
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        public string Mobile
        {
            get
            {
                return _mobile;
            }
            set
            {
                _mobile = value;
                RaisePropertyChanged("Mobile");
            }
        }

        public CustomerStatusDTO SelectedStatus
        {
            get
            {
                return _selectedStatus;
            }
            set
            {
                _selectedStatus = value;
                RaisePropertyChanged("SelectedStatus");
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

        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                RaisePropertyChanged("FilePath");
            }
        }

        public int PaymentPeriod
        {
            get { return _paymentPeriod; }
            set
            {
                _paymentPeriod = value;
                RaisePropertyChanged("PaymentPeriod");
            }
        }

        public decimal CreditLimit
        {
            get { return _creditLimit; }
            set
            {
                _creditLimit = value;
                RaisePropertyChanged("CreditLimit");
            }
        }

        /// <summary>
        /// Gets or sets list of customer for search items
        /// </summary>
        /// <value>
        /// The list of customer.
        /// </value>
        public IList<CustomerDTO> LstSearchCustomer
        {
            get { return _lstSearchCustomer; }
            set
            {
                _lstSearchCustomer = value;
                RaisePropertyChanged("LstSearchCustomer");
            }
        }

        /// <summary>
        ///Bind the data grid according to selected customer from autoextender
        /// </summary>
        /// <value>
        /// The List of customerdetail.
        /// </value>
        public CustomerDTO SelectedCustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                RaisePropertyChanged("SelectedCategoryName");

                if (SelectedCustomerName != null)
                {
                    GetCustomer(SelectedCustomerName.First_Name);

                }
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCustomerViewModel"/> class.
        /// </summary>
        public AddCustomerViewModel()
        {
            LstStatus = new ObservableCollection<CustomerStatusDTO>();
            LstType = new ObservableCollection<CustomerTypeDTO>();
            LstCountry = new ObservableCollection<CountryDTO>();
            LstTownCity = new ObservableCollection<TownCityDTO>();
            LstLocality = new ObservableCollection<LocalityDTO>();
            LstStreet = new ObservableCollection<StreetDTO>();
            LstPostalCode = new ObservableCollection<PostCodeDTO>();
            LstSearchCustomer = new List<CustomerDTO>();

            ////Get all active country details
            GetCountryDetails();
            BindLists();

            SaveCustomer = new RelayCommand(SaveCustomerDetail);
            CancelCustomerSetting = new RelayCommand(CancelSetting);
            GetCustomer(string.Empty);
            CancelSearchCustomer = new RelayCommand(CancelCustomer);
        }

        #endregion

        #region Private Methods

        private void CancelSetting()
        {
            AddCustomerViewModel viewModel = new AddCustomerViewModel();
        }

        /// <summary>
        /// Cancel Customer for Search/view customer
        /// </summary>
        private void CancelCustomer()
        {
            FirstName = string.Empty;
            GetCustomer(string.Empty);
            //AddCategoryViewModel viewModel = new AddCategoryViewModel();
        }

        /// <summary>
        /// Saves Customer details.
        /// </summary>
        private void SaveCustomerDetail()
        {
            var customerdetail = InitializeSaveCustomerDetail();
            ServiceFactory.ServiceClient.SaveCustomerDetail(customerdetail);
        }

        /// <summary>
        /// Initialize customer details to be saved to database
        /// </summary>
        /// <returns></returns>
        private CustomerDTO InitializeSaveCustomerDetail()
        {
            return new CustomerDTO
            {
                Code = CustomerCode,
                Type_Id = SelectedType.Id,
                First_Name = FirstName,
                Last_Name = LastName,
                Email = Email,
                Phone = Phone,
                Mobile = Mobile,
                Status_Id = SelectedStatus.Id,
                Payment_Period = PaymentPeriod,
                Credit_Limit = CreditLimit,
                Address = InitializeAddressDetails()
            };
        }

        /// <summary>
        /// Initialized customer address details to be saved to database
        /// </summary>
        /// <returns></returns>
        private AddressDTO InitializeAddressDetails()
        {
            return new AddressDTO
            {
                Id = 0,
                Building_name = BuildingName,
                House_No = HouseNo,
                Country_Id = SelectedCountry.Id,
                Locality_Id = SelectedLocality.Id,
                PostCode_Id = SelectedPostalCode.Id,
                Street_Id = SelectedStreet.Id,
                Town_City_Id = SelectedTownCity.Id
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

        /// <summary>
        /// Binds the lists.
        /// </summary>
        private void BindLists()
        {
            ////Get available customer status from database
            GetCustomerStatus();

            ////Get available customer types from database
            GetCustomerType();
        }

        /// <summary>
        /// Get available customer status from database
        /// </summary>
        private void GetCustomerStatus()
        {
            LstStatus = new ObservableCollection<CustomerStatusDTO>(ServiceFactory.ServiceClient.GetCustomerStatus());

            if (LstStatus.Count > 0)
            {
                SelectedStatus = LstStatus[0];
            }
        }

        /// <summary>
        /// Get available customer types from database
        /// </summary>
        private void GetCustomerType()
        {
            LstType = new ObservableCollection<CustomerTypeDTO>(ServiceFactory.ServiceClient.GetCustomerTypes());

            if (LstType.Count > 0)
            {
                SelectedType = LstType[0];
            }
        }

        /// <summary>
        /// Get available customer from database
        /// </summary>
        private void GetCustomer(string customername)
        {
            LstSearchCustomer = new ObservableCollection<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
                                                                                 select item).ToList();
            LstSearchCustomer = LstSearchCustomer.Where(item => (customername == "" || customername == null ? item.First_Name == item.First_Name : item.First_Name == customername)).ToList();

            //if (!string.IsNullOrEmpty(categoryName))
            //{
            //    LstSearchCategoryName = LstSearchCategoryName.Where(item => item.Name.Contains(categoryName)).ToList();
            //}
        }

        #endregion
    }
}