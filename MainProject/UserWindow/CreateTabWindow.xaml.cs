using MainProject.CustomControl;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MainProject.UserWindow
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CreateTabWindow : Window
    {
        public string tabTitle;

        MainWindow mainWindow;

        public CreateTabWindow(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
        }

        private void CloseCreateTabButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CreateTabButton_Clicked(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tabTitletb.Text))
            {
                MessageBox.Show("Nhập tên tab!");
                return;
            }
            TabItem tabItem = new TabItem { Header = new CloseableHeader { Title = tabTitletb.Text } };
            MainWindow.tabItems.Add(tabItem);
            MainWindow.currentTabIndex = MainWindow.tabItems.IndexOf(tabItem) + 1;
            this.Close();
        }
    }
}
