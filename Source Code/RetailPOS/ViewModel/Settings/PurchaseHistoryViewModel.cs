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
        public RelayCommand SearchPurchaseHistoryCommand { get; private set; }
        public RelayCommand CancelPurchaseHistorySearchCommand { get; private set; }

        private string _invoiceNo;
        private string _firstName;
        private int _id;
        private Nullable<DateTime> _selectedDate;

        private IList<CustomerDTO> _lstCustomer;
        private CustomerDTO _selectedcustomer;

        #endregion

        #region Public Properties

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
                RaisePropertyChanged("Invoice_No");
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

        /// <summary>
        /// For Fetching Customer Id
        /// </summary>
        public string First_Name
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged("First_Name");
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
        ///Bind the data grid according to selected customer Id from autoextender
        /// </summary>
        /// <value>
        /// The List of customerdetail.
        /// </value>
        public CustomerDTO SelectedCustomer
        {
            get { return _selectedcustomer; }
            set
            {
                _selectedcustomer = value;
                RaisePropertyChanged("SelectedCustomer");

                if (SelectedCustomer != null)
                {
                    Id = SelectedCustomer.Id;
                }
                else if (SelectedCustomer == null)
                {
                    Id = 0;
                }
            }
        }

        #endregion

        #region Constructor

        public PurchaseHistoryViewModel()
        {
            LstPurchaseHistory = new ObservableCollection<PurchaseHistoryDTO>();
            LstCustomer = new ObservableCollection<CustomerDTO>();

            SearchPurchaseHistoryCommand = new RelayCommand(SearchPurchaseHistory);
            CancelPurchaseHistorySearchCommand = new RelayCommand(CancelPurchaseHistorySearch);
            
            ////Get all invoices
            GetPurchaseHistoryDetails();

            ////Get all active customer details from database
            GetCustomerDetails();
            
            ////Clear all controls
            ClearControls();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get Purchase history details from database
        /// </summary>
        private void SearchPurchaseHistory()
        {
            ////Get Purchase History details from database
            GetPurchaseHistoryDetails();
        }

        private void CancelPurchaseHistorySearch()
        {
            ////Clear the controls
            ClearControls();

            GetPurchaseHistoryDetails();
        }

        /// <summary>
        /// Clear the controls
        /// </summary>
        private void ClearControls()
        {
            First_Name = string.Empty;
            Invoice_No = string.Empty;
            SelectedDate = null;
        }

        /// <summary>
        /// Get all active customer details from database
        /// </summary>
        private void GetCustomerDetails()
        {
            LstCustomer = new ObservableCollection<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
                                                                      select item).ToList();
        }

        /// <summary>
        /// Get Purchase History details from database
        /// </summary>
        private void GetPurchaseHistoryDetails()
        {
            LstPurchaseHistory = new ObservableCollection<PurchaseHistoryDTO>(from item in ServiceFactory.ServiceClient.GetPurchaseHistoryDetails()
                                                                              select item);
            if (SelectedDate != null)
            {
                LstPurchaseHistory = new ObservableCollection<PurchaseHistoryDTO>(from item in LstPurchaseHistory
                                                                                  where item.Purchase_Date.Date == SelectedDate.Value.Date
                                                                                  select item);
            }

            if (!string.IsNullOrEmpty(Invoice_No))
            {
                LstPurchaseHistory = new ObservableCollection<PurchaseHistoryDTO>(from item in LstPurchaseHistory
                                                                                  where item.Invoice_No == Invoice_No
                                                                                  select item);
            }

            if (Id != 0)
            {
                LstPurchaseHistory = new ObservableCollection<PurchaseHistoryDTO>(from item in LstPurchaseHistory
                                                                                  where item.Supplier_Id == Id
                                                                                  select item);
            }
        }

        #endregion
    }
}