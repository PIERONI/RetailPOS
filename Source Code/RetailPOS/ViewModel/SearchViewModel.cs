#region Using directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using RetailPOS.Utility;


#endregion

namespace RetailPOS.ViewModel
{
   public class SearchViewModel : ViewModelBase
    {
       #region Declare Public and Private Data member

       public List<ProductDTO> LstSearchProduct { get; private set; }
       public IList<CustomerDTO> LstSearchCustomer { get; private set; }
       
       /// <summary>
       /// Detail Of New Customer To be Saved
       /// </summary>
       public RelayCommand AddNewCustomer { get; private set; }    
       
       private bool _IsProductPopupOpen;
     
       private string _customerName;
       private string _customerFirstName;
       private string _customerLastName;
       private string _email;
       private string _mobileNumber;
       private string _mobileNumberNewCustomer;
       private decimal _customerBalance;
       private string _customerCode;
       private Visibility _isVisibleCustomerInfo;
       
       private CustomerDTO _selectedCustomer;
       private CustomerDTO _customer;
       private ProductDTO _product;
       private ProductDTO _selectedProduct;
       
       private string _productName;
       private string _productCode;
       private decimal _productPrice;
       private int _productQuantity;
       private string _productDescription;
       private int _id;
       /// <summary>
       /// To make textblock visibility true or false on add new customer button click
       /// </summary>
       private string _isTextBoxVisible;

       #endregion

       #region Public Properties

       public int Id
       {
           get { return _id; }
           set
           {
               _id = value;
               RaisePropertyChanged("Id");
           }
       }

       public string ProductName
       {
           get { return _productName; }
           set
           {
               _productName = value;
               RaisePropertyChanged("ProductName");
           }
       }

       public string ProductCode
       {
           get { return _productCode; }
           set
           {
               _productCode = value;
               RaisePropertyChanged("ProductCode");
           }
       }

       public decimal ProductPrice
       {
           get { return _productPrice; }
           set
           {
               _productPrice = value;
               RaisePropertyChanged("ProductPrice");
           }
       }

       public int ProductQuantity
       {
           get { return _productQuantity; }
           set
           {
               _productQuantity = value;
               RaisePropertyChanged("ProductQuantity");

               if (ProductQuantity > 0)
               {
                   SelectedProduct.Quantity = ProductQuantity;
                   Mediator.NotifyColleagues("SetSelectedProduct", SelectedProduct);
               }
           }
       }

       public string ProductDescription
       {
           get { return _productDescription; }
           set
           {
               _productDescription = value;
               RaisePropertyChanged("ProductDescription");
           }
       }

       public Visibility isVisibleCustomerInfo
       {
           get { return _isVisibleCustomerInfo; }
           set
           {
               _isVisibleCustomerInfo = value;
               RaisePropertyChanged("isVisibleCustomerInfo");
           }
       }

       public CustomerDTO SelectedCustomer
       {
           get { return _selectedCustomer; }
           set
           {
               _selectedCustomer = value;
               RaisePropertyChanged("SelectedCustomer");
               BindCustomer();
           }
       }

       public bool IsProductPopupOpen
       {
           get { return _IsProductPopupOpen; }
           set
           {
               _IsProductPopupOpen = value;
               RaisePropertyChanged("IsProductPopupOpen");
           }
       }

       public CustomerDTO Customer
       {
           get { return _customer; }
           set
           {
               _customer = value;

               if (Customer == null)
               {
                   SelectedCustomer = null;
               }

               if (SelectedCustomer == null && Customer != null)
               {
                   SelectedCustomer = Customer;
               }
           }
       }

       public ProductDTO SelectedProduct
       {
           get { return _selectedProduct; }
           set
           {
               _selectedProduct = value;
               BindProduct();               
           }
       }

       public ProductDTO Product
       {
           get { return _product; }
           set
           {
               _product = value;

               if (Product != null)
               {
                   IsProductPopupOpen = true;
                   SelectedProduct = Product;
               }
           }
       }

       public string CustomerName
       {
           get { return _customerName; }
           set
           {
               _customerName = value;
               RaisePropertyChanged("CustomerName");
           }
       }

       public string CustomerFirstName
       {
           get { return _customerFirstName; }
           set
           {
               _customerFirstName = value;
               RaisePropertyChanged("CustomerFirstName");
           }
       }

       public string CustomerLastName
       {
           get { return _customerLastName; }
           set
           {
               _customerLastName = value;
               RaisePropertyChanged("CustomerLastName");
           }
       }

       public string CustomerEmail
       {
           get { return _email; }
           set
           {
               _email = value;
               RaisePropertyChanged("CustomerEmail");
           }
       }

       public string MobileNumber
       {
           get { return _mobileNumber; }
           set
           {
               _mobileNumber = value;
               RaisePropertyChanged("MobileNumber");
           }
       }

       public string MobileNumberNewCustomer
       {
           get { return _mobileNumberNewCustomer; }
           set
           {
               _mobileNumberNewCustomer = value;
               RaisePropertyChanged("MobileNumberNewCustomer");
           }
       }

       public decimal CustomerBalance
       {
           get { return _customerBalance; }
           set
           {
               _customerBalance = value;
               RaisePropertyChanged("CustomerBalance");
           }
       }

       public string CustomerCode
       {
           get { return _customerCode; }
           set
           {
               _customerCode = value;
               RaisePropertyChanged("CustomerCode");
           }
       }

       /// <summary>
       /// To make textblock visibility true or false on add new customer button click
       /// </summary>
       public string IsTextBoxVisible
       {
           get { return _isTextBoxVisible; }
           set
           {
               _isTextBoxVisible = value;
               RaisePropertyChanged("IsTextBoxVisible");
           }
       }


       #endregion

       #region Declare Constructor
      
       /// <summary>
       /// Initializes a new instance of the <see cref="SearchViewModel"/> class.
       /// </summary>
       public SearchViewModel()
       {
           LstSearchProduct = new List<ProductDTO>();
           LstSearchCustomer = new List<CustomerDTO>();
           AddNewCustomer = new RelayCommand(AddNewCustomerDetail);          
           Mediator.Register("ClosePopUpWindow", CloseProductPopUpWindow);
           GetSearchAttributes();
           isVisibleCustomerInfo = Visibility.Collapsed;
       }
     
       /// <summary>
       /// Fills the list search.
       /// </summary>
       private void GetSearchAttributes()
       {
           LstSearchProduct = new ObservableCollection<ProductDTO>(from item in ServiceFactory.ServiceClient.GetAllProducts()
                                                                   select item).ToList();

           LstSearchCustomer = new ObservableCollection<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
                                                                     select item).ToList();
       }

       private void CloseProductPopUpWindow(object args)
       {
           IsProductPopupOpen = false;
       }

       /// <summary>
       /// Binds the customer.
       /// </summary>
       private void BindCustomer()
     {
           if (SelectedCustomer == null)
           {
               isVisibleCustomerInfo = Visibility.Collapsed;
               return;
           }
          
           isVisibleCustomerInfo = Visibility.Visible;
           CustomerBalance = SelectedCustomer.Balance;
           MobileNumber = SelectedCustomer.Mobile;
           CustomerName = SelectedCustomer.First_Name + " " + SelectedCustomer.Last_Name;
           
       }

       /// <summary>
       /// Binds the product.
       /// </summary>
       private void BindProduct()
       {
           Id = SelectedProduct.Id;
           ProductName = SelectedProduct.Name;
           ProductCode = SelectedProduct.BarCode;
           ProductPrice = SelectedProduct.Retail_Price.HasValue ? SelectedProduct.Retail_Price.Value : 0;
           SelectedProduct.Quantity = ProductQuantity = 0;
           SelectedProduct.Discount = 0;
           ProductDescription = SelectedProduct.Description;

       }

       /// <summary>
       /// Initialize customer details to be saved to database
       /// </summary>
       /// <returns></returns>
       
       private void AddNewCustomerDetail()
       {
           var customerDetail = InitializwSaveCustomerDetail();
           ServiceFactory.ServiceClient.SaveCustomerDetail(customerDetail);
       }

       ///
       private CustomerDTO InitializwSaveCustomerDetail()
       {
           return new CustomerDTO
           {
               Code = CustomerCode,              
               First_Name = CustomerFirstName,
               Last_Name = CustomerLastName,
               Email = CustomerEmail,
               Mobile = MobileNumberNewCustomer,
               Status_Id = 1,
               Payment_Period = 0,
               Credit_Limit = 0,
               Balance = 0
           };
       }
       #endregion
    }
}