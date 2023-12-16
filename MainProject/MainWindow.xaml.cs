using MainProject.CustomControl;
using MainProject.Model;
using MainProject.UserWindow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace MainProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<TabItem> tabItems = new ObservableCollection<TabItem>();

        public static int currentTabIndex;

        public TODOLIST db = new TODOLIST();

        public MainWindow()
        {
            InitializeComponent();
            tabControl.ItemsSource = tabItems;
            db.TABs.Load();
            db.TASKs.Load();

            foreach (TAB tAB in db.TABs.Local.ToList())
            {
                tabItems.Add(new TabItem
                {
                    Header = new CloseableHeader {Title = tAB.Title, closeableHeadTAB = tAB},
                    Content = new Task { ObserColl = new ObservableCollection<TASK>(db.TASKs.Where(e => e.TabId == tAB.TabId)),TabID = tAB.TabId }
                });
            }
        }

        private void CreateTabButton_Clicked(object sender, RoutedEventArgs e)
        {
            var createTabWindow = new CreateTabWindow();
            createTabWindow.Owner = this;
            createTabWindow.ShowDialog();
            tabControl.SelectedIndex = currentTabIndex;
        }

        private void CreateTaskButton_Clicked(object sender, RoutedEventArgs e)
        {
            var createTabWindow = new ManageTaskWindow();
            createTabWindow.Owner = this;
            createTabWindow.ShowDialog();
        }

        private void TabChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTabIndex = tabControl.SelectedIndex;
        }
    }
}
