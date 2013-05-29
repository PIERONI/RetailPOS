using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using RetailPOS.CommonLayer.DataTransferObjects;

namespace RetailPOS.Usercontrols
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : UserControl
    {
        public delegate void CallWindow();
        public event CallWindow OpenNewWin;

        public Categories()
        {
            InitializeComponent();
            BindCategory();
        }

        private void BindCategory()
        {
            var CategoryList = new List<Cateogory>();
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "Red" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "Blue" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "Yellow" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "AliceBlue" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "Red" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "Blue" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "Yellow" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "AliceBlue" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "Red" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "Blue" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "Yellow" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "AliceBlue" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "Red" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "Blue" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "Yellow" });
            CategoryList.Add(new Cateogory { Name = "test", ColorName = "AliceBlue" });

            LstCategories.ItemsSource = CategoryList;
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            if (OpenNewWin != null)
                OpenNewWin();
        }

        private void GetCategories()
        {
            IList<ProductCategoryDTO> lstCategories = new List<ProductCategoryDTO>();
            //lstCategories = 
        }
    }

    public class Cateogory
    {
        public string Name { get; set; }
        public string ColorName { get; set; }
    }
}