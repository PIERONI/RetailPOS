using System.Windows;

namespace RetailPOS
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public static Dashboard _Dashboard
        {
            get;
            set;
        }

        public Dashboard()
        {
            _Dashboard = this;
            InitializeComponent();
        }
    }
}