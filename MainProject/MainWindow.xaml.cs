using MainProject.CustomControl;
using MainProject.UserWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MainProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<TabItem> tabItems = new ObservableCollection<TabItem>();

        public static int currentTabIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            tabControl.ItemsSource = tabItems;
        }

        private void CreateTabButton_Clicked(object sender, RoutedEventArgs e)
        {
            var createTabWindow = new CreateTabWindow(this);
            createTabWindow.Owner = this;
            createTabWindow.Show();
            tabControl.SelectedIndex = currentTabIndex;
        }

        private void CreateTaskButton_Clicked(object sender, RoutedEventArgs e)
        {
            var createTabWindow = new ManageTaskWindow(this);
            createTabWindow.Owner = this;
            createTabWindow.Show();
        }
    }
}
