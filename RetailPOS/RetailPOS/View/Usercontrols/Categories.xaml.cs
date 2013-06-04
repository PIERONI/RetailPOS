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

namespace RetailPOS.View.Usercontrols
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : UserControl
    {
       
        public Categories()
        {
            InitializeComponent();
        }

        private void myPopup_Opened(object sender, EventArgs e)
        {

        }

       
    }

    public class Cateogory
    {
        public string Name { get; set; }
        public string ColorName { get; set; }
    }
}