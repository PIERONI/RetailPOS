using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.ComponentModel;
using RetailPOS.CommonLayer.DataTransferObjects;
using System.Windows.Data;

namespace RetailPOS.ViewModel
{
  public  class CategoryViewModel : ViewModelBase
    {
        public ObservableCollection<ProductCategoryDTO> lstCategories { get; set; }
        private ICollectionView _categoryView;

        public CategoryViewModel()
        {
            lstCategories = new ObservableCollection<ProductCategoryDTO>();
            AddCategories();
            _categoryView = CollectionViewSource.GetDefaultView(lstCategories);
            _categoryView.CurrentChanged += new EventHandler(_categoryView_CurrentChanged);
        }

        void _categoryView_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        

        private void AddCategories()
        {
            try
            {
                lstCategories.Add(new ProductCategoryDTO { Color = "Red", Description = "", Id = 1, Name = "test3" });
                lstCategories.Add(new ProductCategoryDTO { Color = "Blue", Description = "", Id = 2, Name = "test32" });
                lstCategories.Add(new ProductCategoryDTO { Color = "Yellow", Description = "", Id = 3, Name = "test33" });
                lstCategories.Add(new ProductCategoryDTO { Color = "White", Description = "", Id = 4, Name = "test43" });
                lstCategories.Add(new ProductCategoryDTO { Color = "AliceBlue", Description = "", Id = 5, Name = "test53" });
                lstCategories.Add(new ProductCategoryDTO { Color = "AliceBlue", Description = "", Id = 5, Name = "test53" });
            }
            catch
            {                
                throw;
            }
        }



    }
}
