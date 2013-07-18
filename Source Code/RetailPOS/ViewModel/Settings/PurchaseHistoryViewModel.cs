using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using RetailPOS.RetailPOSService;
using RetailPOS.Core;
using GalaSoft.MvvmLight.Command;

namespace RetailPOS.ViewModel.Settings
{
    public class PurchaseHistoryViewModel : ViewModelBase
    {
        #region Public and Private Data Members
        private IList<PurchaseHistoryDTO> _lstPurchaseHistory { get; set; }
        /// <summary>
        /// To filter the datalist on searchbutton click
        /// </summary>
        public RelayCommand SearchPurchaseHistory { get; private set; }      

        private string _invoiceNo;
        private DateTime _selectedDate;
        private IList<CustomerDTO> _lstSearchCustomer;
        #endregion

        #region Public Properties

        public DateTime SelectedDate
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

        public IList<PurchaseHistoryDTO> LstPurchaseHistory
        {
            get { return _lstPurchaseHistory; }
            set
            {
                _lstPurchaseHistory = value;
                RaisePropertyChanged("LstPurchaseHistory");
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
    
        #endregion

        #region Constructor

        public PurchaseHistoryViewModel()
        {
            LstPurchaseHistory = new List<PurchaseHistoryDTO>();
            SearchPurchaseHistory = new RelayCommand(GetPurchaseHistoryDetailsOnclick);
            LstPurchaseHistory = GetPurchaseHistoryDetails();
            LstSearchCustomer = new List<CustomerDTO>();

            //get all invoices
            GetPurchaseHistoryDetails();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get Purchase history details from database
        /// </summary>
        private void GetPurchaseHistoryDetailsOnclick()
        {
            LstPurchaseHistory = GetPurchaseHistoryDetails();
            LstSearchCustomer = new ObservableCollection<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
                                                                      select item).ToList();
        }


        private ObservableCollection<PurchaseHistoryDTO>  GetPurchaseHistoryDetails()
        {
            LstSearchCustomer = new ObservableCollection<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
                                                                      select item).ToList();
           
          ObservableCollection<PurchaseHistoryDTO>  lstPurchaseHistory = new ObservableCollection<PurchaseHistoryDTO>(from item in ServiceFactory.ServiceClient.GetPurchaseHistoryDetails()
                                                                              select item);

            if (!string.IsNullOrEmpty(Invoice_No))
            {
                lstPurchaseHistory = new ObservableCollection<PurchaseHistoryDTO>(from item in LstPurchaseHistory
                                                                                  where item.Invoice_No == Invoice_No
                                                                                  select item);
            }
            return lstPurchaseHistory;
        }

        #endregion
    }
}