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
       #region Declare Public and private Data member

       public List<ProductDTO> lstSearchProduct { get; private set; }
       public IList<CustomerDTO> lstSearchCustomer { get; private set; }
       
       private bool _IsProductPopupOpen;
     
       private string _customerName;
       private string _mobileNumber;
       private string _customerBalance;
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

       public int Id
       {
           get
           {
               return _id;
           }
           set
           {
               _id = value;
               RaisePropertyChanged("Id");
           }
       }

       public string ProductName
       {
           get
           {
               return _productName;
           }
           set
           {
               _productName = value;
               RaisePropertyChanged("ProductName");
           }
       }

       public string ProductCode
       {
           get
           {
               return _productCode;
           }
           set
           {
               _productCode = value;
               RaisePropertyChanged("ProductCode");
           }
       }

       public decimal ProductPrice
       {
           get
           {
               return _productPrice;
           }
           set
           {
               _productPrice = value;
               RaisePropertyChanged("ProductPrice");
           }
       }

       public int ProductQuantity
       {
           get
           {
               return _productQuantity;
           }
           set
           {
               _productQuantity = value;
               RaisePropertyChanged("ProductQuantity");
               if (ProductQuantity > 0)
               {
                   BindProduct();
                   
               }
           }
       }

       public string ProductDescription
       {
           get
           {
               return _productDescription;
           }
           set
           {
               _productDescription = value;
               RaisePropertyChanged("ProductDescription");
           }
       }

       public Visibility isVisibleCustomerInfo
       {
           get
           {
               return _isVisibleCustomerInfo;
           }
           set
           {
               _isVisibleCustomerInfo = value;
               RaisePropertyChanged("isVisibleCustomerInfo");
           }
       }

       public CustomerDTO SelectedCustomer
       {
           get
           {
               return _selectedCustomer;
           }
           set
           {
               _selectedCustomer = value;
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
           get
           {
               return _customer;
           }
           set
           {
               _customer = value;
              
               if (Customer == null)
               {
                   SelectedCustomer = null;
               }
               if (SelectedCustomer == null && Customer !=null)
               {
                   SelectedCustomer = Customer;
               }
           }
       }

       public ProductDTO SelectedProduct
       {
           get
           {
               return _selectedProduct;
           }
           set
           {
               _selectedProduct = value;
               ProductQuantity = 0;
               BindProduct();
           }
       }

       public ProductDTO Product
       {
           get
           {
               return _product;
           }
           set
           {
               _product = value;
               if (Product != null )
               {
                   IsProductPopupOpen = true;
                   SelectedProduct = Product;
               }
           }
       }

       public string CustomerName
       {
           get
           {
               return _customerName;
           }
           set
           {
               _customerName = value;
               RaisePropertyChanged("CustomerName");              
           }
       }

       public string MobileNumber
       {
           get
           {
               return _mobileNumber;
           }
           set
           {
               _mobileNumber = value;
               RaisePropertyChanged("MobileNumber");
           }
       }

       public string CustomerBalance
       {
           get
           {
               return _customerBalance;
           }
           set
           {
               _customerBalance = value;
               RaisePropertyChanged("CustomerBalance");             
           }
       }   

       #endregion

       #region Deaclare Constructor
      
       /// <summary>
       /// Initializes a new instance of the <see cref="SearchViewModel"/> class.
       /// </summary>
       public SearchViewModel()
       {
           lstSearchProduct = new List<ProductDTO>();
           lstSearchCustomer = new List<CustomerDTO>();

           Mediator.Register("ClosePopUpWindow", CloseProductPopUpWindow);

           GetSearchAttributes();
           isVisibleCustomerInfo = Visibility.Collapsed;
       }  

       /// <summary>
       /// Fills the list search.
       /// </summary>
       private void GetSearchAttributes()
       {
           lstSearchProduct = new ObservableCollection<ProductDTO>(from item in ServiceFactory.ServiceClient.GetAllProducts()
                                                                   select item).ToList();

           lstSearchCustomer = new ObservableCollection<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
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
           CustomerName = SelectedCustomer.First_Name + " " + SelectedCustomer.Last_Name;
           CustomerBalance = SelectedCustomer.Credit_Limit.ToString();
           MobileNumber = SelectedCustomer.Mobile;           
       }

       /// <summary>
       /// Binds the product.
       /// </summary>
       private void BindProduct()
       {
           ClsProductUtility.ProductName = ProductName = SelectedProduct.Name;
           ClsProductUtility.ProductCode = ProductCode = SelectedProduct.BarCode;
           ClsProductUtility.ProductPrice = ProductPrice = SelectedProduct.WholesalePrice.HasValue ? SelectedProduct.WholesalePrice.Value : 0;
           ClsProductUtility.ProductQuantity = ProductQuantity;
           ClsProductUtility.ProductDescription = ProductDescription = SelectedProduct.Description;
           ClsProductUtility.Id = SelectedProduct.Id;           
       }

       #endregion
    }
}