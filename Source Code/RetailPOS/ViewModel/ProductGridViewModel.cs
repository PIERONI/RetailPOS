using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.View;
using System.ComponentModel;
using System.Windows.Data;
using RetailPOS.Utility;

namespace RetailPOS.ViewModel
{
    public class ProductGridViewModel : ViewModelBase
    {
        #region Declare Public and private Data member

        private ObservableCollection<ProductDetails> _ProductDetials;
        public ObservableCollection<ProductDetails> lstProductDetails
        {
            get { return _ProductDetials; }
            set { _ProductDetials = value; RaisePropertyChanged("lstProductDetails"); }
        }
        public RelayCommand ExitCommand { get; private set; }
        public RelayCommand LogOutCommand { get; private set; }
        private ICollectionView _productCollection;
        private ProductDetails _product;
        private string _total;
        public RelayCommand<object> SelectProductCommand { get; private set; }
        public RelayCommand ClearProduct { get; private set; }
        public RelayCommand DeleteSelectedItem { get; private set; }
        public static ClsProductUtility Product { get; set; }
        bool IsRefersh { get; set; }
       

       

        public ProductDetails SelectedProduct
        {
            get
            {
                IsRefersh = false;
                return _product;
            }
            set
            {
                _product = value;
                IsRefersh = true;
                RaisePropertyChanged("SelectedProduct");
                UpdateProduct();
            }
        }

        private void UpdateProduct()
        {

            if (SelectedProduct == null) return;
            SelectedProduct.IsSelected = true;
            var found = SelectedProduct;
            int i = lstProductDetails.IndexOf(found);
            
            lstProductDetails[i] =  SelectedProduct;

            if (IsRefersh)
                CollectionViewSource.GetDefaultView(this.lstProductDetails).Refresh();       
        }

        public string Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
                RaisePropertyChanged("Total");
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductGridViewModel"/> class.
        /// </summary>
        public ProductGridViewModel()
        {
            lstProductDetails = new ObservableCollection<ProductDetails>();
            ExitCommand = new RelayCommand(CloseApplication);
            LogOutCommand = new RelayCommand(LogoutApplication);
            ClearProduct = new RelayCommand(ClearGridProduct);
            SelectProductCommand = new RelayCommand<object>(BindProductDetails);
            DeleteSelectedItem = new RelayCommand(DeleteItem);          
        }


        private void DeleteItem()
        {
            if (SelectedProduct != null)
                lstProductDetails.Remove(SelectedProduct);
        }

        private void ClearGridProduct()
        {
            lstProductDetails.Clear(); 
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
            lstProductDetails.Add(new ProductDetails { Id = ClsProductUtility.Id, ProductName = ClsProductUtility.ProductName, ProductQuantity = ClsProductUtility.ProductQuantity, Amount = ClsProductUtility.ProductPrice, Rate = (ClsProductUtility.ProductQuantity * ClsProductUtility.ProductPrice)});
            var amount = lstProductDetails.Select(u => u.Amount).Sum();
            Total = "Total : " + amount.ToString();

        }


    }

    public class ProductDetails : ViewModelBase
   {
       public int Id { get; set; }
       public string ProductName { get; set; }
       public double ProductQuantity { get; set; }
       public decimal Rate { get; set; }
       public decimal Amount { get; set; }
       private bool _isSelected;
       public bool IsSelected
       {
           get
           {
               return _isSelected;
           }
           set
           {
               _isSelected = value;
               RaisePropertyChanged("IsSelected");
           }
       }
       
   }
}
