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
    /// Interaction logic for ShopSettingWindow.xaml
    /// </summary>
    public partial class ShopSettingWindow : Window
    {
        /// <summary>
        /// Gets or sets the _ shop setting window.
        /// </summary>
        /// <value>
        /// The _ shop setting window.
        /// </value>
        public static ShopSettingWindow _ShopSettingWindow
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopSettingWindow"/> class.
        /// </summary>
        public ShopSettingWindow()
        {
            InitializeComponent();
            _ShopSettingWindow = this;
        }
    }
}