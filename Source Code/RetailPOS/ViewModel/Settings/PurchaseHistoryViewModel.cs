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
        private string _firstName;
        private int _id;
        private Nullable<DateTime> _selectedDate;
        private IList<CustomerDTO> _lstSearchCustomer;
        private CustomerDTO _selectedcustomer;
        #endregion

        #region Public Properties

        public Nullable<DateTime>  SelectedDate
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
            LstPurchaseHistory = new List<PurchaseHistoryDTO>();
            SearchPurchaseHistory = new RelayCommand(GetPurchaseHistoryDetailsOnclick);
            LstPurchaseHistory = GetPurchaseHistoryDetails();
            LstSearchCustomer = new List<CustomerDTO>();

            //get all invoices
            GetPurchaseHistoryDetails();
            SelectedDate = null;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get Purchase history details from database
        /// </summary>
        private void GetPurchaseHistoryDetailsOnclick()
        {
            LstPurchaseHistory = GetPurchaseHistoryDetails();
            //LstSearchCustomer = new ObservableCollection<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
            //                                                          select item).ToList();
        }


        private ObservableCollection<PurchaseHistoryDTO>  GetPurchaseHistoryDetails()
        {
            LstSearchCustomer = new ObservableCollection<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
                                                                      select item).ToList();
           
          ObservableCollection<PurchaseHistoryDTO>  lstPurchaseHistory = new ObservableCollection<PurchaseHistoryDTO>(from item in ServiceFactory.ServiceClient.GetPurchaseHistoryDetails()
                                                                              select item);
          if (SelectedDate != null)
          {
              lstPurchaseHistory = new ObservableCollection<PurchaseHistoryDTO>(from item in LstPurchaseHistory
                                                                                where item.Purchase_Date.Date == SelectedDate.Value.Date
                                                                                select item);
          }           
          

            if (!string.IsNullOrEmpty(Invoice_No))
            {
                lstPurchaseHistory = new ObservableCollection<PurchaseHistoryDTO>(from item in LstPurchaseHistory
                                                                                  where item.Invoice_No == Invoice_No
                                                                                  select item);
            }

            if (Id!=0)
            {
                lstPurchaseHistory = new ObservableCollection<PurchaseHistoryDTO>(from item in LstPurchaseHistory
                                                                                  where item.Supplier_Id == Id
                                                                                  select item);
            }
            return lstPurchaseHistory;
        }

        #endregion
    }
}