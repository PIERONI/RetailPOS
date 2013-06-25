using System;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace RetailPOS.ViewModel
{
   public class AddCustomerViewModel : ViewModelBase
    {
       #region Declare Public and private Data member
       public ObservableCollection<CStatusModel> lstStatus { get; private set; }
       public ObservableCollection<CTypeModel> lstype { get; private set; }
       public ObservableCollection<CPaymentGatewayModel> lstPaymentGateway { get; private set; }
       public ObservableCollection<COpenIDModel> lstOpenId { get; private set; }
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
       private DateTime _date;
       private decimal _creditLimit;

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
           BindLists();
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
