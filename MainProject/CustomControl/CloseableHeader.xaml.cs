using MainProject.Model;
using MainProject.UserWindow;
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
        public TAB? closeableHeadTAB; 

        private TODOLIST db = new TODOLIST();

        public CloseableHeader()
        {
            InitializeComponent();
        }

        private void closeButton_Clicked(object sender, RoutedEventArgs e)
        {   
            TabItem deleteItem = (this.Parent as TabItem);

            db.TABs.Remove(closeableHeadTAB);

            MainWindow.tabItems.Remove(deleteItem);

            db.SaveChanges();
        }

        private void InfoButton_Clicked(object sender, RoutedEventArgs e)
        {
            TabItem infoItem = (this.Parent as TabItem);

            var tabInfoWindow = new CreateTabWindow { Title = "TAB INFO" };

            tabInfoWindow.Owner = Application.Current.MainWindow;

            tabInfoWindow.updatingTab = (infoItem.Header as CloseableHeader).closeableHeadTAB;

            tabInfoWindow.ThisTitle = tabInfoWindow.updatingTab.Title;

            tabInfoWindow.ShowDialog();

            Title = tabInfoWindow.updatingTab.Title;
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(CloseableHeader), new PropertyMetadata());

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
    }
}
