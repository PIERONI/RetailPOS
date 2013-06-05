#region Using directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;

#endregion

namespace RetailPOS.ViewModel
{
   public class SearchViewModel : ViewModelBase
    {
       #region Declare Public and private Data member

       public List<ProductDTO> lstSearchProduct { get; private set; }
       public IList<CustomerDTO> lstSearchCustomer { get; private set; }

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
       }

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

       #endregion
    }
}