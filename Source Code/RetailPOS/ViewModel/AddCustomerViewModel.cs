using System;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using RetailPOS.RetailPOSService;
using RetailPOS.Core;

namespace RetailPOS.ViewModel
{
   public class AddCustomerViewModel : ViewModelBase
    {
       #region Declare Public and private Data member

       public ObservableCollection<CStatusModel> lstStatus { get; private set; }
       public ObservableCollection<CTypeModel> lstype { get; private set; }
       public ObservableCollection<CPaymentGatewayModel> lstPaymentGateway { get; private set; }
       public ObservableCollection<COpenIDModel> lstOpenId { get; private set; }

       public ObservableCollection<CountryDTO> LstCountry { get; private set; }
       private ObservableCollection<TownCityDTO> _lstTownCity;
       private ObservableCollection<LocalityDTO> _lstLocality;
       private ObservableCollection<StreetDTO> _lstStreet;
       public ObservableCollection<PostCodeDTO> _lstPostalCode;

       public RelayCommand SaveCustomerDetail { get; set; }

       private CTypeModel _selectedType;
       private COpenIDModel _selectedOpenId;
       private CPaymentGatewayModel _selectedGateway;
       private CStatusModel _selectedStatus;
       
       private string _customerCode;
       private string _firstName;
       private string _lastName;
       private string _password;
       private string _phone;
       private string _mobile;
       private decimal _balance;
       private string _address;
       private string _openId;
       private string _filePath;
       private string _email;
       private DateTime _date;
       private decimal _creditLimit;

       private string _buildingName;
       private string _houseNo;

       private StreetDTO _selectedStreet;
       private LocalityDTO _selectedLocality;
       private CountryDTO _selectedCountry;
       private TownCityDTO _selectedTownCity;
       private PostCodeDTO _selectedPostalCode;

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

       public string Password
       {
           get
           {
               return _password;
           }
           set
           {
               _password = value;
               RaisePropertyChanged("Password");
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

       public decimal Balance
       {
           get
           {
               return _balance;
           }
           set
           {
               _balance = value;
               RaisePropertyChanged("Balance");
           }
       }

       public string Address
       {
           get
           {
               return _address;
           }
           set
           {
               _address = value;
               RaisePropertyChanged("Address");
           }
       }

       public string OpenId
       {
           get
           {
               return _openId;
           }
           set
           {
               _openId = value;
               RaisePropertyChanged("OpenId");
           }
       }

       public string FilePath
       {
           get
           {
               return _filePath;
           }
           set
           {
               _filePath = value;
               RaisePropertyChanged("FilePath");
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

       public DateTime PaymentPeriod 
       {
           get
           {
               return _date;
           }
           set
           {
               _date = value;
               RaisePropertyChanged("PaymentPeriod");
           }
       }

       public decimal CreditLimit
       {
           get
           {
               return _creditLimit;
           }
           set
           {
               _creditLimit = value;
               RaisePropertyChanged("CreditLimit");
           }
       }

       public CTypeModel SelectedType
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

       public COpenIDModel SelectedOpenId
       {
           get
           {
               return _selectedOpenId;
           }
           set
           {
               _selectedOpenId = value;
               RaisePropertyChanged("SelectedOpenId");
           }
       }

       public CPaymentGatewayModel SelectedGateway
       {
           get
           {
               return _selectedGateway;
           }
           set
           {
               _selectedGateway = value;
               RaisePropertyChanged("SelectedGateway");
           }
       }

       public CStatusModel SelectedStatus
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

       #endregion

       /// <summary>
       /// Initializes a new instance of the <see cref="AddCustomerViewModel"/> class.
       /// </summary>
       public AddCustomerViewModel()
       {
           lstStatus = new ObservableCollection<CStatusModel>();
           lstype = new ObservableCollection<CTypeModel>();
           lstPaymentGateway = new ObservableCollection<CPaymentGatewayModel>();
           lstOpenId = new ObservableCollection<COpenIDModel>();
           LstCountry = new ObservableCollection<CountryDTO>();
           LstTownCity = new ObservableCollection<TownCityDTO>();
           LstLocality = new ObservableCollection<LocalityDTO>();
           LstStreet = new ObservableCollection<StreetDTO>();
           LstPostalCode = new ObservableCollection<PostCodeDTO>();

           ////Get all active country details
           GetCountryDetails();

           SaveCustomerDetail = new RelayCommand(SaveCustomerDet);
           BindLists();
       }
       /// <summary>
       /// Saves Customer details.
       /// </summary>
       private void SaveCustomerDet()
       {
           var customerdetail = InitializeSaveCustomerDetail();
           ServiceFactory.ServiceClient.SaveCustomerDetail(customerdetail);
       }

       private CustomerDTO InitializeSaveCustomerDetail()
       {
           return new CustomerDTO
           {
               Code=CustomerCode,
               Type_Id=new CTypeModel().TypeId,
               Last_Name=LastName,
               First_Name=FirstName,
               Phone =Phone,
               Mobile=Mobile,
               Email=Email,
               Credit_Limit=CreditLimit,
               Status_Id=new CStatusModel().StatusId,               
               Address=InitializeAddressDetails()
               
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
           lstStatus.Add(new CStatusModel { StatusId = 0, StatusName = "Active" });
           lstStatus.Add(new CStatusModel { StatusId = 1, StatusName = "Deactive" });

           lstype.Add(new CTypeModel { TypeId = 0, TypeName = "test" });
           lstype.Add(new CTypeModel { TypeId = 1, TypeName = "test1" });


           lstPaymentGateway.Add(new CPaymentGatewayModel { Id = 0, GatewayName = "PayPal" });
           lstPaymentGateway.Add(new CPaymentGatewayModel { Id = 1, GatewayName = "CreditS" });

           lstOpenId.Add(new COpenIDModel { Id = 0, Name = "Yahoo" });
           lstOpenId.Add(new COpenIDModel { Id = 1, Name = "Google" });
       }
    }

   public class CStatusModel
   {
       public int StatusId{ get; set; }
       public String StatusName { get; set; }
   }

   public class CTypeModel
   {
       public int TypeId { get; set; }
       public String TypeName { get; set; }
   }

   public class CPaymentGatewayModel
   {
       public int Id { get; set; }
       public String GatewayName { get; set; }
   }

   public class COpenIDModel
   {
       public int Id { get; set; }
       public String Name { get; set; }
   }
}