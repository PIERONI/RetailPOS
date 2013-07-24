#region Using directives

using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using System.Collections.Generic;
using System.Linq;
using System;

#endregion

namespace RetailPOS.ViewModel.Settings
{
    public class CustomerViewModel : ViewModelBase
    {
        #region Declare Public and Private Data member

        public ObservableCollection<CustomerStatusDTO> LstStatus { get; private set; }
        public ObservableCollection<CustomerTypeDTO> LstType { get; private set; }
        public ObservableCollection<CountryDTO> LstCountry { get; private set; }

        public RelayCommand SaveCustomerCommand { get; set; }
        public RelayCommand CancelCustomerCommand { get; set; }
        public RelayCommand SearchCustomerCommand { get; set; }
        public RelayCommand CancelSearchCommand { get; private set; }

        private ObservableCollection<TownCityDTO> _lstTownCity;
        private ObservableCollection<LocalityDTO> _lstLocality;
        private ObservableCollection<StreetDTO> _lstStreet;
        private ObservableCollection<PostCodeDTO> _lstPostalCode;

        private CustomerTypeDTO _selectedType;
        private CustomerStatusDTO _selectedStatus;
        private IList<CustomerDTO> _lstCustomer;

        private Nullable<DateTime> _selectedDate;
        private string _invoiceNo;
        private int _id;

        private string _customerCode;
        private string _first_Name;
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
            get{return _customerCode;}
            set
            {
                _customerCode = value;
                RaisePropertyChanged("CustomerCode");
            }
        }

        public CustomerTypeDTO SelectedType
        {
            get{return _selectedType;}
            set
            {
                _selectedType = value;
                RaisePropertyChanged("SelectedType");
            }
        }

        public string First_Name
        {
            get{return _first_Name;}
            set
            {
                _first_Name = value;
                RaisePropertyChanged("First_Name");
            }
        }

        public string LastName
        {
            get{return _lastName;}
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        public string Email
        {
            get{return _email;}
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string Phone
        {
            get{return _phone;}
            set
            {
                _phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        public string Mobile
        {
            get{return _mobile;}
            set
            {
                _mobile = value;
                RaisePropertyChanged("Mobile");
            }
        }

        public CustomerStatusDTO SelectedStatus
        {
            get{return _selectedStatus;}
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
            get{return _selectedLocality;}
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
        public IList<CustomerDTO> LstCustomer
        {
            get { return _lstCustomer; }
            set
            {
                _lstCustomer = value;
                RaisePropertyChanged("LstCustomer");
            }
        }

        /// <summary>
        ///Bind the data grid according to selected customer from autoextender
        /// </summary>
        /// <value>
        /// The List of customerdetail.
        /// </value>
        public CustomerDTO SelectedCustomer
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                RaisePropertyChanged("SelectedCustomer");

                if (SelectedCustomer != null)
                {
                    GetCustomer(SelectedCustomer.First_Name);
                }
            }
        }

        public Nullable<DateTime> SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                RaisePropertyChanged("SelectedDate");
            }
        }

        public string Invoice_No
        {
            get { return _invoiceNo; }
            set
            {
                _invoiceNo = value;
                RaisePropertyChanged("InvoiceNo");
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }
        
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerViewModel"/> class.
        /// </summary>
        public CustomerViewModel()
        {
            LstStatus = new ObservableCollection<CustomerStatusDTO>();
            LstType = new ObservableCollection<CustomerTypeDTO>();
            LstCountry = new ObservableCollection<CountryDTO>();
            LstTownCity = new ObservableCollection<TownCityDTO>();
            LstLocality = new ObservableCollection<LocalityDTO>();
            LstStreet = new ObservableCollection<StreetDTO>();
            LstPostalCode = new ObservableCollection<PostCodeDTO>();
            LstCustomer = new ObservableCollection<CustomerDTO>();

            ////Get all active country details
            GetCountryDetails();

            ////Get available customer status from database
            GetCustomerStatus();

            ////Get available customer types from database
            GetCustomerType();

            ////Get available customer from database
            GetCustomer(string.Empty);

            ////Clear the controls
            ClearControls();

            SaveCustomerCommand = new RelayCommand(SaveCustomerDetail);
            CancelCustomerCommand = new RelayCommand(CancelSetting);
            SearchCustomerCommand = new RelayCommand(SearchCustomer);
            CancelSearchCommand = new RelayCommand(CancelSearch);
        }

        #endregion

        #region Private Methods

        private void CancelSetting()
        {
            CustomerViewModel viewModel = new CustomerViewModel();
        }

        private void CancelPurchaseHistorySearch()
        {
            SelectedDate = null;
            Invoice_No = string.Empty;
            Id = 0;
        }

        private void SearchCustomer()
        {
            ////Get available customer from database filtered by first name
            GetCustomer(First_Name);
        }

        /// <summary>
        /// Cancel Customer for Search/view customer
        /// </summary>
        private void CancelSearch()
        {
            First_Name = string.Empty;
            
            ////Get available customer from database
            GetCustomer(string.Empty);
        }

        /// <summary>
        /// Saves Customer details.
        /// </summary>
        private void SaveCustomerDetail()
        {
            var customerdetail = InitializeSaveCustomerDetail();
            ServiceFactory.ServiceClient.SaveCustomerDetail(customerdetail);

            GetCustomer(string.Empty);

            ////Clear the controls
            ClearControls();
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
                First_Name = First_Name,
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
        /// Clear the controls
        /// </summary>
        private void ClearControls()
        {
            CustomerCode = string.Empty;
            SelectedType = null;
            First_Name = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Mobile = string.Empty;
            SelectedStatus = null;
            PaymentPeriod = 0;
            CreditLimit = 0;
            BuildingName = string.Empty;
            HouseNo = string.Empty;
            SelectedCountry = null;
            SelectedTownCity = null;
            SelectedLocality = null;
            SelectedStreet = null;
            SelectedPostalCode = null;
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
        }

        /// <summary>
        /// Get street details based on selected locality
        /// </summary>
        private void GetStreetByLocality()
        {
            LstStreet = new ObservableCollection<StreetDTO>(ServiceFactory.ServiceClient.GetStreetDetails(SelectedLocality.Id));
        }

        /// <summary>
        /// Get postal code based on selected locality
        /// </summary>
        private void GetPostalCodeByLocality()
        {
            LstPostalCode = new ObservableCollection<PostCodeDTO>(ServiceFactory.ServiceClient.GetPostalCodeDetails(SelectedLocality.Id));
        }

        /// <summary>
        /// Get available customer status from database
        /// </summary>
        private void GetCustomerStatus()
        {
            LstStatus = new ObservableCollection<CustomerStatusDTO>(ServiceFactory.ServiceClient.GetCustomerStatus());
        }

        /// <summary>
        /// Get available customer types from database
        /// </summary>
        private void GetCustomerType()
        {
            LstType = new ObservableCollection<CustomerTypeDTO>(ServiceFactory.ServiceClient.GetCustomerTypes());
        }

        /// <summary>
        /// Get available customer from database
        /// </summary>
        private void GetCustomer(string customername)
        {
            LstCustomer = new ObservableCollection<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
                                                                select item).ToList();

            if (!string.IsNullOrEmpty(customername))
            {
                LstCustomer = LstCustomer.Where(item => item.First_Name.Contains(customername)).ToList();
            }
        }

        #endregion
    }
}