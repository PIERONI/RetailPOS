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

namespace RetailPOS.Usercontrols
{
    /// <summary>
    /// Interaction logic for ShowProduct.xaml
    /// </summary>
    public partial class ShowProduct : UserControl
    {
        public ShowProduct()
        {
            InitializeComponent();
            BindProduct();
        }

        private void BindProduct()
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

            LstProduct.ItemsSource = CategoryList;
        }
    }
}
