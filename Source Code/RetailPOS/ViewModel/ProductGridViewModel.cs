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

        private ObservableCollection<ProductDTO> _productDetails;
        public static List<int> LstSelectedItem { get; set; }

        public RelayCommand ExitCommand { get; private set; }
        public RelayCommand LogOutCommand { get; private set; }
        public RelayCommand<object> SelectProductCommand { get; private set; }
        public RelayCommand ClearProduct { get; private set; }
        public RelayCommand DeleteSelectedItem { get; private set; }

        private ICollectionView _productCollection;
        private ProductDTO _selectedProduct;
        private string _total;
        
        //public static ClsProductUtility Product { get; set; }
        bool IsRefersh { get; set; }

        #endregion

        #region Public Properties

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

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductGridViewModel"/> class.
        /// </summary>
        public ProductGridViewModel()
        {
            LstProductDetails = new ObservableCollection<ProductDTO>();

            Mediator.Register("SetSelectedProduct", SetSelectedProduct);

            ExitCommand = new RelayCommand(CloseApplication);
            LogOutCommand = new RelayCommand(LogoutApplication);
            ClearProduct = new RelayCommand(ClearGridProduct);
            SelectProductCommand = new RelayCommand<object>(BindProductDetails);
            DeleteSelectedItem = new RelayCommand(DeleteItem);
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

        void _productCollection_CurrentChanged(object sender, System.EventArgs e)
        {
        }

        private void LogoutApplication()
        {  
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            MainWindow._MainWindow.Close();
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        private void CloseApplication()
        {
            MainWindow._MainWindow.Close();
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
                    Amount = (CurrentProduct.Quantity * CurrentProduct.Retail_Price)
                });
            }
            else
            {
                var found = LstProductDetails.FirstOrDefault(x => x.Id == CurrentProduct.Id);
                int i = LstProductDetails.IndexOf(found);
                var quantity = CurrentProduct.Quantity + found.Quantity;
                LstProductDetails[i].Quantity = quantity;

                LstProductDetails[i].Amount = found.Retail_Price * quantity;
                CollectionViewSource.GetDefaultView(this.LstProductDetails).Refresh();
            }
            
            var amount = LstProductDetails.Select(u => u.Amount).Sum();
            Total = "Total : " + amount.ToString();

            Mediator.NotifyColleagues("ClosePopUpWindow", false);
        }

        #endregion
    }
}