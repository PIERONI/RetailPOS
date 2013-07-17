#region Using directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Utility;
using RetailPOS.View;
using RetailPOS.RetailPOSService;
using RetailPOS.Core;
using System.Windows;

#endregion

namespace RetailPOS.ViewModel
{
    public class ProductGridViewModel : ViewModelBase
    {
        #region Declare Public and private Data member

        public IList<DiscountType> LstDiscountType { get; private set; }

        private ObservableCollection<ProductDTO> _productDetails;
        public static List<int> LstSelectedItem { get; set; }

        public RelayCommand ExitCommand { get; private set; }
        public RelayCommand LogOutCommand { get; private set; }
        public RelayCommand<CustomerDTO> SelectProductCommand { get; private set; }
        public RelayCommand ClearProduct { get; private set; }
        public RelayCommand DeleteSelectedItem { get; private set; }
        public RelayCommand OpenEditProductEntryPopUp { get; private set; }
        public RelayCommand EditProductCommand { get; private set; }
        /// <summary>
        /// To Make New Customer Field Visible For Creating New User
        /// </summary>
        public RelayCommand IsVisibleCustomerField { get; private set; }
        /// <summary>
        /// To save The Data for Order Detail in OrderMaster
        /// </summary>
        public RelayCommand SaveSetAsideOrderDetail { get; private set; }
        /// <summary>
        /// For SetAsideOrder Button
        /// </summary>
        public RelayCommand OpenSetAsideCustomerPopUp { get; private set; }

        /// <summary>
        /// To save Order Detail with Items in Database
        /// </summary>
        public RelayCommand SaveNewOrder { get; private set; }
        /// <summary>
        /// Detail Of New Customer To be Saved
        /// </summary>
     
        public RelayCommand AddNewCustomer { get; private set; }    
    

      
        private DiscountType _selectedDiscount;
        private ProductDTO _selectedProduct;
        public IList<CustomerDTO> LstSearchCustomer { get; private set; }
        private string _total;
        private string _productName;
        private decimal _productQuantity;
        private decimal _productDiscount;
        private bool _isEditProductEntryPopupOpen;
        private bool _isEditErrorMessage;
        private string _mobileNumberNewCustomer;
        /// <summary>
        /// To make textblock visibility true or false on add new customer button click
        /// </summary>
        private string  _isTextBoxVisible;
        private string _isVisibleOnAddNewCustomerClick;
        //private CustomerDTO _selectedCustomer;
        private CustomerDTO _selectedCustomer1;
        private decimal _customerBalance;
        private string _customerCode;
        private string _mobileNumber;
        private Visibility _isVisibleCustomerInfo;
        private string _customerName;
        private string _customerFirstName;
        private string _customerLastName;
        private string _email;
        /// <summary>
        /// To open SetAsideOrder Customer Popup
        /// </summary>
        private bool _isSetAsidePopUpOpen;
        
        bool IsRefersh { get; set; }

        #endregion

        #region Public Properties

        ////public CustomerDTO SelectedCustomer
        ////{
        ////    get { return _selectedCustomer; }
        ////    set
        ////    {
        ////        _selectedCustomer = value;
        ////        RaisePropertyChanged("SelectedCustomer");
        ////    }
        ////}

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

        public ProductDTO CurrentProduct { get; set; }

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


        public string Total
        {
            get { return _total; }
            set
            {
                _total = value;
                RaisePropertyChanged("Total");
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

        public string MobileNumberNewCustomer
        {
            get { return _mobileNumberNewCustomer; }
            set
            {
                _mobileNumberNewCustomer = value;
                RaisePropertyChanged("MobileNumberNewCustomer");
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
        /// <summary>
        /// To make Fields visibility true or false on add new customer button click
        /// </summary>
        public string IsVisibleOnAddNewCustomerClick
        {
            get { return _isVisibleOnAddNewCustomerClick; }
            set
            {
                _isVisibleOnAddNewCustomerClick = value;
                RaisePropertyChanged("IsVisibleOnAddNewCustomerClick");
            }
        }

        public bool IsEditErrorMessage
        {
            get { return _isEditErrorMessage; }
            set
            {
                _isEditErrorMessage = value;
                RaisePropertyChanged("IsEditErrorMessage");
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
            get{return _productQuantity;}
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

        public bool IsSetAsdePopUpOpen
        {
            get { return _isSetAsidePopUpOpen; }
            set
            {
                _isSetAsidePopUpOpen = value;
                RaisePropertyChanged("IsSetAsdePopUpOpen");
            }
        }

        public CustomerDTO SelectedCustomer1
        {
            get { return _selectedCustomer1; }
            set
            {
                _selectedCustomer1 = value;
                RaisePropertyChanged("SelectedCustomer1");
                BindCustomer();
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

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductGridViewModel"/> class.
        /// </summary>
        public ProductGridViewModel()
        {
            LstProductDetails = new ObservableCollection<ProductDTO>();
            LstDiscountType = new ObservableCollection<DiscountType>();
            LstSearchCustomer = new List<CustomerDTO>();
            Mediator.Register("SetSelectedProduct", SetSelectedProduct);

            GetDiscountType();

            ExitCommand = new RelayCommand(CloseApplication);
            LogOutCommand = new RelayCommand(LogoutApplication);
            ClearProduct = new RelayCommand(ClearGridProduct);
            SelectProductCommand = new RelayCommand<CustomerDTO>(BindProductDetails);
            DeleteSelectedItem = new RelayCommand(DeleteItem);
            OpenEditProductEntryPopUp = new RelayCommand(OpenEditProductPopUp);
            EditProductCommand = new RelayCommand(EditDataGridCommand);
            OpenSetAsideCustomerPopUp = new RelayCommand(OpenSetAsidePopUp);
            SaveNewOrder = new RelayCommand (SaveOrderWithItems);
            AddNewCustomer = new RelayCommand(AddNewCustomerDetail);
            GetSearchAttributes();
            IsVisibleCustomerField = new RelayCommand(VisibleCustomerField);
            //SaveSetAsideOrderDetail = new RelayCommand(SaveOrderDetail);
        }

        /// <summary>
        /// To Make New Customer Field Visible For Creating New User
        /// </summary>

        private void VisibleCustomerField()
        {

            IsTextBoxVisible = "Visible";
            IsVisibleOnAddNewCustomerClick = "Collapsed";
        }       
    
        /// <summary>
        /// Fills the list search.
        /// </summary>
        private void GetSearchAttributes()
        {
           
            LstSearchCustomer = new ObservableCollection<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
                                                                      select item).ToList();
        }



        /// <summary>
        /// To Save Set aside order detail and customer detail in ordermaster and orderchild
        /// </summary>      
        private void SaveOrderWithItems()
        {
           // CustomerDTO selectedCustomer = (CustomerDTO)args;

            if (SelectedCustomer1 != null)
            {
                var OrderDetail = InitializeSaveOrderWithItems(SelectedCustomer1);
                ServiceFactory.ServiceClient.SaveOrderDetail(OrderDetail);
            }
        }

        private OrderMasterDTO InitializeSaveOrderWithItems(CustomerDTO SelectedCustomer1)
        {
            return new OrderMasterDTO
            {
                Order_no="0001",
                Order_date= System.DateTime.Now,
                Customer_id = SelectedCustomer1.Id,
                Shop_code = "PSD-01",
                Invoice_id=64,
                Print_receipt_copies=0,
                Orderchilds = InitializeOrderChildDetail()
            
            };
        }

        /// <summary>
        /// Initialized order child details to be saved to database
        /// </summary>
        /// <returns></returns>
        private List<OrderChildDTO> InitializeOrderChildDetail()
        {
            List<OrderChildDTO> lstOrderChildDetail=(from item in LstProductDetails select
                                                       new OrderChildDTO
                                                           {
                                                              Order_id=0,
                                                              Product_id=item.Id,
                                                              Quantity=1,
                                                              Measure_unit_id=3,
                                                              Amount=(decimal)item.Retail_Price,
                                                              Taxed=1                                                           
                                                           }).ToList();
            return lstOrderChildDetail;
        }


        /// <summary>
        /// To Save Set aside product detail and customer detail in ordermaster
        /// </summary>
        //private void SaveOrderDetail()
        //{
        //    var orderdetail = InitializeSaveOrderDetail();
        //    ServiceFactory.ServiceClient.(orderdetail);      
        
        //}

        private void EditDataGridCommand()
        {
            SelectedProduct.Quantity = ProductQuantity;
            decimal amount = (decimal)(SelectedProduct.Quantity * SelectedProduct.Retail_Price);

            if (SelectedDiscountType != null)
            {
                if (SelectedDiscountType.Id == 1)
                {
                    SelectedProduct.Discount = ProductDiscount;
                    amount -= ProductDiscount;
                }
                else if (SelectedDiscountType.Id == 2)
                {
                    decimal discountAmount = (decimal)(SelectedProduct.Amount * (ProductDiscount / 100));
                    SelectedProduct.Discount = discountAmount;
                    amount -= discountAmount;
                }
            }

            SelectedProduct.Amount = amount;

            var totalAmount = LstProductDetails.Select(u => u.Amount).Sum();
            Total = "Total : " + totalAmount.ToString();

            IsEditProductEntryPopupOpen = false;
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
            else
            {
                IsEditErrorMessage = true;
            }            
        }

        private void SetSelectedProduct(object args)
        {
            CurrentProduct = (ProductDTO)args;
        }

        private void DeleteItem()
        {
            if (SelectedProduct != null)
            {
                LstProductDetails.Remove(SelectedProduct);
            }
        }

        private void ClearGridProduct()
        {
            LstProductDetails.Clear(); 
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
            if (LstProductDetails != null)
            {
                IsSetAsdePopUpOpen = true;
                IsTextBoxVisible="Collapsed";
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
            Total = "Total : " + amount.ToString();

            Mediator.NotifyColleagues("ClosePopUpWindow", false);
        }
        /// <summary>
        /// Binds the customer.
        /// </summary>
        private void BindCustomer()
        {
            if (SelectedCustomer1 == null)
            {
                isVisibleCustomerInfo = Visibility.Collapsed;
                return;
            }

            isVisibleCustomerInfo = Visibility.Visible;
            CustomerBalance = SelectedCustomer1.balance;
            MobileNumber = SelectedCustomer1.Mobile;
            CustomerName = SelectedCustomer1.First_Name + " " + SelectedCustomer1.Last_Name;

        }


        /// <summary>
        /// Initialize customer details to be saved to database
        /// </summary>
        /// <returns></returns>

        private void AddNewCustomerDetail()
        {
            var customerDetail = InitializwSaveCustomerDetail();
            ServiceFactory.ServiceClient.SaveCustomerDetail(customerDetail);
            IsVisibleOnAddNewCustomerClick = "Visible";
            IsTextBoxVisible = "Collapsed";
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
                balance = 0
            };
        }


        #endregion
    }

    public class DiscountType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}