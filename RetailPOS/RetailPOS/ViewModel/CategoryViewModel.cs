using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.ComponentModel;
using RetailPOS.CommonLayer.DataTransferObjects;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;

namespace RetailPOS.ViewModel
{
  public  class CategoryViewModel : ViewModelBase
  {

       #region Declare Public and private Data member
        public ObservableCollection<ProductCategoryDTO> lstCategories { get; private set; }
        public ObservableCollection<ProductDTO> _lstProduct;          
        private ICollectionView _categoryView;
        public RelayCommand<ProductCategoryDTO> SelectProductCommand { get; private set; }
        public ObservableCollection<ProductDTO> lstProduct
        {
            get { return _lstProduct; }
            set
            {
                _lstProduct = value;
                RaisePropertyChanged("lstProduct");
            }
        }

      #endregion


        public CategoryViewModel()
        {
            lstCategories = new ObservableCollection<ProductCategoryDTO>();
            lstProduct = new ObservableCollection<ProductDTO>();
            AddCategories();
            _categoryView = CollectionViewSource.GetDefaultView(lstCategories);
            _categoryView.CurrentChanged += new EventHandler(_categoryView_CurrentChanged);
            SelectProductCommand = new RelayCommand<ProductCategoryDTO>(FillProducts);
        }

        void _categoryView_CurrentChanged(object sender, EventArgs e)
        {
            
        }


        private void FillProducts(ProductCategoryDTO Dto)
        {
            lstProduct.Add(new ProductDTO { Name = "Chocalte", color="Red", CategoryId = 1});
            lstProduct.Add(new ProductDTO { Name = "VANILLA ICE CREAM", color = "Blue", CategoryId = 2 });
            lstProduct.Add(new ProductDTO { Name = "Orange Bar", color = "Blue", CategoryId = 2 });
            lstProduct.Add(new ProductDTO { Name = "Cream", color = "Red", CategoryId = 1 });

            
        }
        

        private void AddCategories()
        {
            try
            {
                lstCategories.Add(new ProductCategoryDTO { Color = "Red", Description = "", Id = 1, Name = "Confectionary" });
                lstCategories.Add(new ProductCategoryDTO { Color = "Blue", Description = "", Id = 2, Name = "Frozen" });
                lstCategories.Add(new ProductCategoryDTO { Color = "Yellow", Description = "", Id = 3, Name = "Diary" });
                lstCategories.Add(new ProductCategoryDTO { Color = "White", Description = "", Id = 4, Name = "Bakery" });
                lstCategories.Add(new ProductCategoryDTO { Color = "AliceBlue", Description = "", Id = 5, Name = "Gorcery" });
                
            }
            catch
            {                
                throw;
            }
        }




      
  }
}
