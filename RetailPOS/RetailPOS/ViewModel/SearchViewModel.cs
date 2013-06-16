#region Using directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows;

#endregion

namespace RetailPOS.ViewModel
{
   public class SearchViewModel : ViewModelBase
    {
       #region Declare Public and private Data member

       public List<ProductDTO> lstSearchProduct { get; private set; }
       public IList<CustomerDTO> lstSearchCustomer { get; private set; }
     
       private string _customerName;
       private string _mobileNumber;
       private string _customerBalance;
       private Visibility _isVisibleCustomerInfo;
       private CustomerDTO _selectedCustomer;
       private CustomerDTO _customer;

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

       private RelayCommand _openFirstPopupCommand;
       private bool _firstPopupIsOpen;

       public RelayCommand OpenFirstPopupCommand
       {
           get { return _openFirstPopupCommand ?? (_openFirstPopupCommand = new RelayCommand(OpenFirstPopupClick)); }
       }

       public bool FirstPopupIsOpen
       {
           get { return _firstPopupIsOpen; }
           set
           {
               _firstPopupIsOpen = value;
               RaisePropertyChanged("FirstPopupIsOpen");
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
           
           GetSearchAttributes();
           isVisibleCustomerInfo = Visibility.Collapsed;
           //customerCollection = CollectionViewSource.GetDefaultView(lstSearchCustomer);
           //customerCollection.CurrentChanged += new System.EventHandler(customerCollection_CurrentChanged);
       }

       //void customerCollection_CurrentChanged(object sender, System.EventArgs e)
       //{
           
       //}

       

       /// <summary>
       /// Opens the first popup click.
       /// </summary>
       private void OpenFirstPopupClick()
       {
           FirstPopupIsOpen = true;
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

       #endregion



      
    }
}