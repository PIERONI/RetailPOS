using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.View;

namespace RetailPOS.ViewModel
{
    public class ProductGridViewModel : ViewModelBase
    {
        #region Declare Public and private Data member
        public ObservableCollection<ProductDetails> lstProductDetails { get; private set; }
        public RelayCommand ExitCommand { get; private set; }
        public RelayCommand LogOutCommand { get; private set; }
        private string _total;

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
            BindProductDetails();
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
        private void BindProductDetails()
        {
            lstProductDetails.Add(new ProductDetails { Id = 1, ProductName = "Coke Diet plus vitamins", ProductQuantity = 1, Amount = 55.23, Rate = 1.79 });
            lstProductDetails.Add(new ProductDetails { Id = 2, ProductName = "Coke Diet plus vitamins", ProductQuantity = 1, Amount = 55.23, Rate = 1.79 });
            lstProductDetails.Add(new ProductDetails { Id = 3, ProductName = "Coke Diet plus vitamins", ProductQuantity = 1, Amount = 55.23, Rate = 1.79 });
            lstProductDetails.Add(new ProductDetails { Id = 4, ProductName = "Coke Diet plus vitamins", ProductQuantity = 1, Amount = 55.23, Rate = 1.79 });
            lstProductDetails.Add(new ProductDetails { Id = 5, ProductName = "Coke Diet plus vitamins", ProductQuantity = 1, Amount = 55.23, Rate = 1.79 });

            var amount = lstProductDetails.Select(u => u.Amount).Sum();
            Total = "Total : " + amount.ToString(); 

        }


    }

   public class ProductDetails
   {
       public int Id { get; set; }
       public string ProductName { get; set; }
       public double ProductQuantity { get; set; }
       public double Rate { get; set; }
       public double Amount { get; set; }
   }
}
