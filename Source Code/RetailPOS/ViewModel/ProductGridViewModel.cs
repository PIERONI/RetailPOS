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
        public RelayCommand<object> SelectProductCommand { get; private set; }
        public RelayCommand ClearProduct { get; private set; }
        public RelayCommand DeleteSelectedItem { get; private set; }
        public RelayCommand OpenEditProductEntryPopUp { get; private set; }
        public RelayCommand EditProductCommand { get; private set; }

        private DiscountType _selectedDiscount;
        private ProductDTO _selectedProduct;
        private string _total;
        private string _productName;
        private decimal _productQuantity;
        private decimal _productDiscount;
        private bool _isEditProductEntryPopupOpen;
        private bool _isEditErrorMessage;
        
        bool IsRefersh { get; set; }

        #endregion

        #region Public Properties

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
        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductGridViewModel"/> class.
        /// </summary>
        public ProductGridViewModel()
        {
            LstProductDetails = new ObservableCollection<ProductDTO>();
            LstDiscountType = new ObservableCollection<DiscountType>();

            Mediator.Register("SetSelectedProduct", SetSelectedProduct);

            GetDiscountType();

            ExitCommand = new RelayCommand(CloseApplication);
            LogOutCommand = new RelayCommand(LogoutApplication);
            ClearProduct = new RelayCommand(ClearGridProduct);
            SelectProductCommand = new RelayCommand<object>(BindProductDetails);
            DeleteSelectedItem = new RelayCommand(DeleteItem);
            OpenEditProductEntryPopUp = new RelayCommand(OpenEditProductPopUp);
            EditProductCommand = new RelayCommand(EditDataGridCommand);
        }

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

        #endregion
    }

    public class DiscountType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}