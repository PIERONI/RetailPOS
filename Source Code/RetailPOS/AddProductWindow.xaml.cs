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
using System.Windows.Shapes;

namespace RetailPOS
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        /// <summary>
        /// Gets or sets the _ add category window.
        /// </summary>
        /// <value>
        /// The _ add category window.
        /// </value>
        public static AddCategoryWindow _AddCategoryWindow
        {
            get;
            set;
        }

        public AddProductWindow()
        {
            InitializeComponent();
        }
    }
}
