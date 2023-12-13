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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainProject.CustomControl
{
    /// <summary>
    /// Interaction logic for CloseableHeader.xaml
    /// </summary>
    public partial class CloseableHeader : UserControl
    {
        public CloseableHeader()
        {
            InitializeComponent();
        }

        private void closeButton_Clicked(object sender, RoutedEventArgs e)
        {
            (this.Parent as TabItem).Visibility = Visibility.Collapsed;
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title",typeof(string),typeof(CloseableHeader),new PropertyMetadata("Tab Title"));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty,value) ; }
        }
    }
}
