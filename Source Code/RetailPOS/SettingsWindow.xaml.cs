using System.Windows;

namespace RetailPOS
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public static SettingsWindow SettingWindow
        {
            get;
            set;
        }

        public SettingsWindow()
        {
            InitializeComponent();
            SettingWindow = this;
        }
    }
}