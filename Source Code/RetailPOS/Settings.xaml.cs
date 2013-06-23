using System.Windows;

namespace RetailPOS
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public static Settings SettingWindow
        {
            get;
            set;
        }

        public Settings()
        {
            InitializeComponent();
            SettingWindow = this;
        }
    }
}
