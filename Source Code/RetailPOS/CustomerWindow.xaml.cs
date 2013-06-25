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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        /// <summary>
        /// Gets or sets the _ customer window.
        /// </summary>
        /// <value>
        /// The _ customer window.
        /// </value>
        public static CustomerWindow _CustomerWindow
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerWindow"/> class.
        /// </summary>
        public CustomerWindow()
        {
            _CustomerWindow = this;
            InitializeComponent();
        }
    }
}
