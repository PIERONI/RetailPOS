#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using RetailPOS.Utility;
using RetailPOS.View;
using RetailPOS.Constants;
using System.ComponentModel;

#endregion

namespace RetailPOS.ViewModel
{
    public class ProductGridViewModel : ViewModelBase
    {       
        #region Declare Public and Private Data member

        public IList<DiscountType> LstDiscountType { get; private set; }
        public IList<CustomerDTO> LstSearchCustomer { get; private set; }

        public static List<int> LstSelectedItem { get; set; }

        public RelayCommand ExitCommand { get; private set; }
        public RelayCommand LogOutCommand { get; private set; }
        public RelayCommand<object> SelectProductCommand { get; private set; }
        public RelayCommand ClearProduct { get; private set; }
        public RelayCommand DeleteSelectedItem { get; private set; }
        public RelayCommand OpenEditProductEntryPopUp { get; private set; }
        public RelayCommand EditProductCommand { get; private set; }
        public RelayCommand NewOrderCommand { get; private set; }
        public RelayCommand SaveOrderInQueueCommand { get; private set; }
        public RelayCommand AddDiscount { get; private set; }
        public RelayCommand OpenDiscountentryPopUp { get; private set; }
        /// <summary>
        /// To Make New Customer Field Visible For Creating New User
        /// </summary>
        public RelayCommand ShowHideAddCustomerCommand { get; private set; }

        /// <summary>
        /// To save The Data for Order Detail in OrderMaster
        /// </summary>
        public RelayCommand SaveSetAsideOrderCommand { get; private set; }

        /// <summary>
        /// For SetAsideOrder Button
        /// </summary>
        public RelayCommand OpenSetAsideCustomerPopUp { get; private set; }

        /// <summary>
        /// Detail Of New Customer To be Saved
        /// </summary>
        public RelayCommand AddNewCustomerCommand { get; private set; }

        /// <summary>
        /// To Bind the product grid on selecting the customer for Open Order
        /// </summary>
        public RelayCommand<CustomerDTO> BindProductGridForOpenOrder { get; private set; }

        /// <summary>
        /// To Bind the product grid on selecting the orders saved in queue
        /// </summary>
        public RelayCommand<OrderMasterDTO> OrderInQueueCommand { get; private set; }
      
        private DiscountType _selectedDiscount;
        private ProductDTO _selectedProduct;

        private IList<OrderMasterDTO> _lstOrderMasterType;
        private IList<OrderChildDTO> _lstOrderItems;
        private ObservableCollection<ProductDTO> _productDetails;
        private ObservableCollection<CustomerDTO> _customerDetail;
        
        private decimal _total;
        private decimal _totalDiscount;
        private string _productName;
        private decimal _productQuantity;
        private decimal _productDiscount;
        private bool _isEditProductEntryPopupOpen;
        private bool _isDiscountEntryPopUp;
        /// <summary>
        /// To make textblock visibility true or false on add new customer button click
        /// </summary>
        private Visibility _isTextBoxVisible;
        private Visibility _isVisibleOnAddNewCustomerClick;
        private Visibility _isErrorForDiscountVisible;
        private decimal _customerBalance;
        
        private string _mobileNumber;
        private string _customerName;
        private Visibility _isVisibleCustomerInfo;
        
        private string _code;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _newMobileNumber;
        private decimal _discount;

        private CustomerDTO _selectedCustomer;

        /// <summary>
        /// To open SetAsideOrder Customer Popup
        /// </summary>
        private bool _isSetAsidePopUpOpen;

        bool IsRefersh { get; set; }

        #endregion

        #region Public Properties

        public OrderMasterDTO SelectedOrder { get; set; }
        public ProductDTO CurrentProduct { get; set; }

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

        public DiscountType SelectedDiscountType
        {
            get { return _selectedDiscount; }
            set
            {
                _selectedDiscount = value;
                RaisePropertyChanged("SelectedDiscountType");
            }
        }

        public ObservableCollection<ProductDTO> LstProductDetails
        {
            get { return _productDetails; }
            set
            {
                _productDetails = value;
                RaisePropertyChanged("LstProductDetails");
            }
        }

        /// <summary>
        /// For entering customerId in ordermaster table
        /// </summary>
        public ObservableCollection<CustomerDTO> LstCustomerDetail
        {
            get { return _customerDetail; }
            set
            {
                _customerDetail = value;
                RaisePropertyChanged("LstCustomerDetail");
            }
        }

        public ProductDTO SelectedProduct
        {
            get
            {
                IsRefersh = false;
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                IsRefersh = true;
                RaisePropertyChanged("SelectedProduct");

                UpdateProduct();
            }
        }

        private void UpdateProduct()
        {
            if (SelectedProduct == null) return;
            //listSelectItem.Add(SelectedProduct.Id);

            //(from item in lstProductDetails select item).Update(item => item.IsSelected = (from selectedItems in listSelectItem join item1 in lstProductDetails
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

        public decimal CustomerBalance
        {
            get { return _customerBalance; }
            set
            {
                _customerBalance = value;
                RaisePropertyChanged("CustomerBalance");
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

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                RaisePropertyChanged("CustomerName");
            }
        }

        public decimal Total
        {
            get { return _total; }
            set
            {
                _total = value;
                RaisePropertyChanged("Total");
            }
        }

        public decimal TotalDiscount
        {
            get { return _totalDiscount; }
            set
            {
                _totalDiscount = value;
                RaisePropertyChanged("TotalDiscount");
            }
        }

     

        public bool IsEditProductEntryPopupOpen
        {
            get { return _isEditProductEntryPopupOpen; }
            set
            {
                _isEditProductEntryPopupOpen = value;
                RaisePropertyChanged("IsEditProductEntryPopupOpen");
            }
        }

        public string NewMobileNumber
        {
            get { return _newMobileNumber; }
            set
            {
                _newMobileNumber = value;
                RaisePropertyChanged("NewMobileNumber");
            }
        }

        /// <summary>
        /// To make textblock visibility true or false on add new customer button click
        /// </summary>
        public Visibility IsTextBoxVisible
        {
            get { return _isTextBoxVisible; }
            set
            {
                _isTextBoxVisible = value;
                RaisePropertyChanged("IsTextBoxVisible");
            }
        }

        /// <summary>
        /// To make Error visibility true or false if discount is greater than total
        /// </summary>
        public Visibility IsErrorMessageVisible
        {
            get { return _isErrorForDiscountVisible; }
            set
            {
                _isErrorForDiscountVisible = value;
                RaisePropertyChanged("IsErrorMessageVisible");
            }
        }

        /// <summary>
        /// To make Fields visibility true or false on add new customer button click
        /// </summary>
        public Visibility IsVisibleOnAddNewCustomerClick
        {
            get { return _isVisibleOnAddNewCustomerClick; }
            set
            {
                _isVisibleOnAddNewCustomerClick = value;
                RaisePropertyChanged("IsVisibleOnAddNewCustomerClick");
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

        public decimal ProductQuantity
        {
            get { return _productQuantity; }
            set
            {
                _productQuantity = value;
                RaisePropertyChanged("ProductQuantity");
            }
        }

        public decimal ProductDiscount
        {
            get { return _productDiscount; }
            set
            {
                _productDiscount = value;
                RaisePropertyChanged("ProductDiscount");
            }
        }

        public bool IsSetAsidePopUpOpen
        {
            get { return _isSetAsidePopUpOpen; }
            set
            {
                _isSetAsidePopUpOpen = value;
                RaisePropertyChanged("IsSetAsidePopUpOpen");
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                RaisePropertyChanged("Code");
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        /// <summary>
        /// Gets or sets list of ordermaster to bind the datagrid
        /// </summary>
        /// <value>
        /// The list of ordermaster.
        /// </value>
        public IList<OrderMasterDTO> LstOrderMasterType
        {
            get { return _lstOrderMasterType; }
            set
            {
                _lstOrderMasterType = value;
                RaisePropertyChanged("LstOrderMasterType");
            }
        }

        /// <summary>
        /// Gets or sets list of orderchild to bind the datagrid
        /// </summary>
        /// <value>
        /// The list of orderchild.
        /// </value>
        public IList<OrderChildDTO> LstOrderItems
        {
            get { return _lstOrderItems; }
            set
            {
                _lstOrderItems = value;
                RaisePropertyChanged("LstOrderItems");
            }
        }

        /// <summary>
        /// To bind discount text box
        /// </summary>
        public decimal Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                RaisePropertyChanged("Discount");
            }
        }

        /// <summary>
        /// True for opening discount pop up
        /// </summary>
        public bool IsDiscountPopupOpen
        {
            get { return _isDiscountEntryPopUp; }
            set
            {
                _isDiscountEntryPopUp = value;
                RaisePropertyChanged("IsDiscountPopupOpen");
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductGridViewModel"/> class.
        /// </summary>
        public ProductGridViewModel()
        {
            LstProductDetails = new ObservableCollection<ProductDTO>();
            LstCustomerDetail = new ObservableCollection<CustomerDTO>();
            LstDiscountType = new ObservableCollection<DiscountType>();
            LstSearchCustomer = new List<CustomerDTO>();
            LstOrderMasterType = new List<OrderMasterDTO>();
            LstOrderItems = new List<OrderChildDTO>();

            Mediator.Register("SetSelectedProduct", SetSelectedProduct);
            Mediator.Register("SetSelectedCustomer", SetSelectedCustomer);
            Mediator.Register("SetSelectedOrder", SetSelectedOrder);

            GetDiscountType();

            ExitCommand = new RelayCommand(CloseApplication);
            LogOutCommand = new RelayCommand(LogoutApplication);
            ClearProduct = new RelayCommand(ClearGridProduct);
            SelectProductCommand = new RelayCommand<object>(BindProductDetails);
            DeleteSelectedItem = new RelayCommand(DeleteItem);
            OpenEditProductEntryPopUp = new RelayCommand(OpenEditProductPopUp);
            EditProductCommand = new RelayCommand(EditDataGridCommand);
            OpenSetAsideCustomerPopUp = new RelayCommand(OpenSetAsidePopUp);
            SaveSetAsideOrderCommand = new RelayCommand(SaveOrderWithItems);
            AddNewCustomerCommand = new RelayCommand(AddNewCustomer);
            BindProductGridForOpenOrder = new RelayCommand<CustomerDTO>(BindProductGridOnSelectCustomer);
            ShowHideAddCustomerCommand = new RelayCommand(ShowHideAddCustomerFields);
            NewOrderCommand = new RelayCommand(ResetControls);
            SaveOrderInQueueCommand = new RelayCommand(SaveOrderInQueue);
            OrderInQueueCommand = new RelayCommand<OrderMasterDTO>(BindProductGridWithOrdersInQueue);
            AddDiscount = new RelayCommand(addDiscount);
            OpenDiscountentryPopUp = new RelayCommand(OpenDiscountentryPopUpClick);      
            GetSearchAttributes();

            IsVisibleOnAddNewCustomerClick = Visibility.Visible;
            IsErrorMessageVisible = Visibility.Hidden;
            ClearControls();
        }

        #endregion

        #region Private Methods     
        /// <summary>
        /// To Make New Customer Field Visible For Creating New User
        /// </summary>
        private void ShowHideAddCustomerFields()
        {
            IsTextBoxVisible = Visibility.Visible;
            IsVisibleOnAddNewCustomerClick = Visibility.Collapsed;

            Code = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            NewMobileNumber = string.Empty;
            Email = string.Empty;
        }

        /// <summary>
        /// Fills the list search.
        /// </summary>
        private void GetSearchAttributes()
        {
            LstSearchCustomer = new ObservableCollection<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
                                                                      select item).ToList();
        }

        private void EditDataGridCommand()
        {
            SelectedProduct.Quantity = ProductQuantity;
            SelectedProduct.Amount = (decimal)(SelectedProduct.Quantity * SelectedProduct.Retail_Price);
            bool showErrorMessage = false;

            if (SelectedDiscountType != null)
            {
                if (SelectedDiscountType.Id == 1 && ProductDiscount < SelectedProduct.Amount)
                {
                    SelectedProduct.Discount = ProductDiscount;
                    SelectedProduct.Amount -= ProductDiscount;
                }
                else if (SelectedDiscountType.Id == 2)
                {
                    decimal discountAmount = (decimal)(SelectedProduct.Amount * (ProductDiscount / 100));
                    if (discountAmount < SelectedProduct.Amount)
                    {
                        SelectedProduct.Discount = discountAmount;
                        SelectedProduct.Amount -= discountAmount;
                    }
                    else
                    {
                        showErrorMessage = true;
                        
                    }
                }
                else
                {
                    showErrorMessage = true;
                }
            }

            if (!showErrorMessage)
            {
                var totalAmount = LstProductDetails.Select(u => u.Amount).Sum();
                var totalDiscount = LstProductDetails.Select(u => u.Discount).Sum();
                Total = (decimal)totalAmount;
                TotalDiscount = (decimal)totalDiscount;
                IsEditProductEntryPopupOpen = false;
            }
            else
            {
                IsErrorMessageVisible = Visibility.Visible;
            }
            //SelectedProduct.Amount = Amount
        }

        private void GetDiscountType()
        {
            LstDiscountType = new ObservableCollection<DiscountType>();
            LstDiscountType.Add(new DiscountType
            {
                Id = 1,
                TypeName = "AMT"
            });

            LstDiscountType.Add(new DiscountType
            {
                Id = 2,
                TypeName = "PER"
            });
        }

        private void OpenEditProductPopUp()
        {
            if (SelectedProduct != null)
            {
                IsEditProductEntryPopupOpen = true;
                ProductName = SelectedProduct.Name;
                ProductQuantity = SelectedProduct.Quantity;
                ProductDiscount = 0;  
              
            }
        }

        private void SetSelectedProduct(object args)
        {
            CurrentProduct = (ProductDTO)args;
        }

        private void SetSelectedCustomer(object args)
        {
            SelectedCustomer = (CustomerDTO)args;
        }

        private void SetSelectedOrder(object args)
        {
            SelectedOrder = (OrderMasterDTO)args;
        }

        //To delete selected item from datagrid

        private void DeleteItem()
        {
            if (SelectedProduct != null)
            {
                Total = Total - (decimal)SelectedProduct.Amount;
                if (SelectedProduct.Discount > 0)
                {
                    TotalDiscount -= SelectedProduct.Discount;
                    //Discount -= (decimal)SelectedProduct.Discount;
                }
                LstProductDetails.Remove(SelectedProduct);           
          
            }
        }

        private void ClearGridProduct()
        {
            LstProductDetails.Clear();
            TotalDiscount = (decimal) 0.0;
            Total = (decimal)0.0;           
        }

        private void LogoutApplication()
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            Dashboard._Dashboard.Close();
        }

        /// <summary>
        /// Open PopUp for Searching Customer
        /// </summary>
        private void OpenSetAsidePopUp()
        {
            if (LstProductDetails.Count > 0)
            {
                IsSetAsidePopUpOpen = true;
                IsTextBoxVisible = Visibility.Collapsed;
                IsVisibleOnAddNewCustomerClick = Visibility.Visible;
            }
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        private void CloseApplication()
        {
            Dashboard._Dashboard.Close();
        }

        /// <summary>
        /// Binds the product details.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void BindProductDetails(object product)
        {
            var isExist = LstProductDetails.Where(u => u.Id == CurrentProduct.Id).FirstOrDefault();

            if (isExist == null)
            {
                LstProductDetails.Add(new ProductDTO
                {
                    Id = CurrentProduct.Id,
                    Name = CurrentProduct.Name,
                    Quantity = CurrentProduct.Quantity,
                    Retail_Price = CurrentProduct.Retail_Price,
                    Discount = CurrentProduct.Discount,
                    Amount = (CurrentProduct.Quantity * CurrentProduct.Retail_Price)
                });
            }
            else
            {
                var found = LstProductDetails.FirstOrDefault(x => x.Id == CurrentProduct.Id);
                int i = LstProductDetails.IndexOf(found);
                var quantity = CurrentProduct.Quantity + found.Quantity;
                LstProductDetails[i].Quantity = quantity;

                LstProductDetails[i].Amount = (found.Retail_Price * quantity) - found.Discount;
                CollectionViewSource.GetDefaultView(this.LstProductDetails).Refresh();
            }

            var amount = LstProductDetails.Select(u => u.Amount).Sum();
             var totalDiscount = LstProductDetails.Select(u => u.Discount).Sum();          
            TotalDiscount = (decimal)totalDiscount;
            Total = (decimal)amount;

            Mediator.NotifyColleagues("CloseProductPopUpWindow", false);
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
        /// Reset Controls to their original position    
        /// </summary>
        private void ResetControls()
        {
            IsSetAsidePopUpOpen = false;
            LstProductDetails.Clear();
            LstCustomerDetail.Clear();
            ClearControls();

            ViewModelLocator.Cleanup(ViewModelType.MenuControl);
        }

        private void ClearControls()
        {
            Total = (decimal)0.0;         
            TotalDiscount = (decimal)0.0;
          }

        /// <summary>
        /// Initialize customer details to be saved to database
        /// </summary>
        /// <returns></returns>
        private void AddNewCustomer()
        {
            if (SelectedCustomer == null)
            {
                var customerDetail = InitializwSaveCustomerDetail();
                int customerId = ServiceFactory.ServiceClient.SaveCustomerDetail(customerDetail);

                var OrderDetail = InitializeOrderItems(customerId, OrderStatus.SetAsideOrder);
                ServiceFactory.ServiceClient.SaveOrderDetail(OrderDetail);

                ////Reset Controls to their original position
                ResetControls();
            }
        }

        /// <summary>
        /// To Save order in Queue and process next order
        /// </summary>
        private void SaveOrderInQueue()
        {
            if (LstProductDetails.Count>0)
            {
                var OrderDetail = InitializeOrderItems(0, OrderStatus.OrderInQueue);
                ServiceFactory.ServiceClient.SaveOrderDetail(OrderDetail);

                ////Reset Controls to their original position
                ResetControls();
            }
        }

        /// <summary>
        /// To Save Set aside order detail and customer detail in ordermaster and orderchild
        /// </summary>
        private void SaveOrderWithItems()
        {
            if (SelectedCustomer != null)
            {
                var OrderDetail = InitializeOrderItems(SelectedCustomer.Id, OrderStatus.SetAsideOrder);
                ServiceFactory.ServiceClient.SaveOrderDetail(OrderDetail);

                ////Reset Controls to their original position
                ResetControls();
            }
        }

        private OrderMasterDTO InitializeOrderItems(int customerId, OrderStatus orderStatus)
        {
            return new OrderMasterDTO
            {
                Order_No = "0001",
                Order_Date = DateTime.Now,
                Customer_Id = customerId,
                Shop_Code = "PSD-01",
                Invoice_Id = 64,
                Print_Receipt_Copies = 0,
                Status = (short)orderStatus,
                Discount_total=TotalDiscount,
                OrderChilds = InitializeOrderItemDetails()
            };
        }

        /// <summary>
        /// Initialized order child details to be saved to database
        /// </summary>
        /// <returns></returns>
        private List<OrderChildDTO> InitializeOrderItemDetails()
        {
            List<OrderChildDTO> lstOrderChildDetail = (from item in LstProductDetails
                                                       select new OrderChildDTO
                                                       {
                                                           Order_Id = 0,
                                                           Product_Id = item.Id,
                                                           Quantity = item.Quantity,
                                                           Measure_Unit_Id = 3,
                                                           Amount = (decimal)item.Amount,
                                                           Discount = item.Discount,
                                                           Taxed = 1,
                                                           Retail_price=item.Retail_Price
                                                       }).ToList();
            return lstOrderChildDetail;
        }


        ///To save new customer detail
        private CustomerDTO InitializwSaveCustomerDetail()
        {
            return new CustomerDTO
            {
                Code = Code,
                First_Name = FirstName,
                Last_Name = LastName,
                Email = Email,
                Mobile = NewMobileNumber,
                Status_Id = 1,
                Payment_Period = 0,
                Credit_Limit = 0,
                Balance = 0
            };
        }

        private void BindProductGridWithOrdersInQueue(object orderDetails)
        {
            if (SelectedOrder != null)
            {
                LstOrderItems = ServiceFactory.ServiceClient.GetOrderItemsByOrderId(((OrderMasterDTO)SelectedOrder).Id);


                LstProductDetails = new ObservableCollection<ProductDTO>(from item in LstOrderItems
                                                                         select new ProductDTO
                                                                         {
                                                                             Id = item.Product_Id,
                                                                             Name = item.ProductName,
                                                                             Quantity = item.Quantity,
                                                                             Retail_Price = item.Retail_price,
                                                                             Discount = item.Discount ?? 0,
                                                                             Amount = item.Amount - (item.Discount ?? 0)
                                                                         });

                var amount = LstProductDetails.Select(u => u.Amount).Sum();
                Total = (decimal)amount;
                var totalDiscount = LstProductDetails.Select(u => u.Discount).Sum();          
                TotalDiscount = (decimal)totalDiscount;
                Mediator.NotifyColleagues("CloseOrderInQueuePopUpWindow", false);
            }
        }

        ///To add discount on Payment detail
        private void addDiscount()
        {
            if (Total > Discount)
            {
                TotalDiscount += Discount;
                Total -= Discount;

                IsErrorMessageVisible = Visibility.Hidden;
                Discount = (Decimal)0.0;
                IsDiscountPopupOpen = false;
            }
            else

                {
                    IsDiscountPopupOpen = true;
                    IsErrorMessageVisible = Visibility.Visible;
                    return;
                }               
        }

        /// <summary>
        /// To bind product grid on selecting customer in open order
        /// </summary>
        private void BindProductGridOnSelectCustomer(object customerDetails)
        {
            if (SelectedCustomer != null)
            {
                LstOrderMasterType = ServiceFactory.ServiceClient.GetSetAsideOrders(((CustomerDTO)SelectedCustomer).Id);
                if (LstOrderMasterType.Count > 0)
                {

                    LstProductDetails = new ObservableCollection<ProductDTO>(from item in LstOrderMasterType[0].OrderChilds
                                                                             select new ProductDTO
                                                                             {
                                                                                 Id = item.Product_Id,
                                                                                 Name = item.ProductName,
                                                                                 Quantity = item.Quantity,
                                                                                 Retail_Price = item.Amount,
                                                                                 Discount = item.Discount ?? 0,
                                                                                 Amount = item.Amount - (item.Discount ?? 0)
                                                                             });
                    var amount = LstProductDetails.Select(u => u.Amount).Sum();
                    Total = (decimal)amount;
                    var totalDiscount = LstProductDetails.Select(u => u.Discount).Sum();
                    TotalDiscount = (decimal)totalDiscount;
                    Mediator.NotifyColleagues("CloseSetAsideOrderPopUpWindow", false);

                }
                else
                {
                    Mediator.NotifyColleagues("CloseSetAsideOrderPopUpWindow", false);
                }
            }
            else
            {
                Mediator.NotifyColleagues("CloseSetAsideOrderPopUpWindow", false);
            }
        }

            

        ///To open popup for entering discount
        private void OpenDiscountentryPopUpClick()
        {
            if (Total > 0)
            {
                IsDiscountPopupOpen = true;
                IsErrorMessageVisible = Visibility.Hidden;
                Discount = (Decimal)0.0;
              
            }
        }


        #endregion
    }

    public class DiscountType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }

    
}