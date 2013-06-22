using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.View;
using System.ComponentModel;
using System.Windows.Data;
using RetailPOS.Utility;
using System.Collections.Generic;

namespace RetailPOS.ViewModel
{
    public class ProductGridViewModel : ViewModelBase
    {
        #region Declare Public and private Data member

        private ObservableCollection<ProductDetails> _ProductDetials;
        public static List<int> listSelectItem { get; set; }
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
            listSelectItem.Add(SelectedProduct.Id);

            (from item in lstProductDetails select item).Update(item => item.IsSelected = (from selectedItems in listSelectItem select true).ToObservableCollection();
                            
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
            var IsExist = lstProductDetails.Where(u => u.Id == ClsProductUtility.Id).FirstOrDefault();

            if (IsExist == null)
            {
                lstProductDetails.Add(new ProductDetails { Id = ClsProductUtility.Id, ProductName = ClsProductUtility.ProductName, ProductQuantity = ClsProductUtility.ProductQuantity, Rate = 3, Amount = (ClsProductUtility.ProductQuantity * ClsProductUtility.ProductPrice) });
            }
            else
            {
                var found = lstProductDetails.FirstOrDefault(x => x.Id == ClsProductUtility.Id);
                int i = lstProductDetails.IndexOf(found);
                var quantity = ClsProductUtility.ProductQuantity + found.ProductQuantity;
                lstProductDetails[i].ProductQuantity = quantity;

                lstProductDetails[i].Amount = found.Rate * quantity;
                CollectionViewSource.GetDefaultView(this.lstProductDetails).Refresh();
            }
            //lstProductDetails.Add(new ProductDetails { Id = ClsProductUtility.Id, ProductName = ClsProductUtility.ProductName, ProductQuantity = ClsProductUtility.ProductQuantity, Amount = ClsProductUtility.ProductPrice, Rate = (ClsProductUtility.ProductQuantity * ClsProductUtility.ProductPrice)});
            var amount = lstProductDetails.Select(u => u.Amount).Sum();
            Total = "Total : " + amount.ToString();

        }


    }

    public class ProductDetails : ViewModelBase
   {
       public int Id { get; set; }
       public string ProductName { get; set; }
       public decimal ProductQuantity { get; set; }
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
