using MainProject.Model;
using MainProject.UserWindow;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MainProject.CustomControl
{
    /// <summary>
    /// Interaction logic for Task.xaml
    /// </summary>
    public partial class Task : UserControl
    {
        private TODOLIST db = new TODOLIST();

        public Task()
        {
            InitializeComponent();
            ObserColl = new ObservableCollection<TASK>();
            testGrid.ItemsSource = ObserColl;
        }

        private void DoneButton_Clicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            TASK item = (TASK)button.DataContext;

            db.TASKs.Remove(item);

            db.SaveChanges();

            ObserColl.Remove(item); 
        }

        private void EditButton_Clicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            TASK item = (TASK)button.DataContext;

            var manageTaskWindow = new ManageTaskWindow();

            manageTaskWindow.Owner = Application.Current.MainWindow;

            manageTaskWindow.ThisTitle = item.Title;
            
            manageTaskWindow.ThisDescription = item.Description;

            manageTaskWindow.updatingTask = item;

            manageTaskWindow.ShowDialog();
        }

        private void PrioritiesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            TASK item = (TASK)checkBox.DataContext;

            Task itemList = (Task)MainWindow.tabItems[MainWindow.currentTabIndex].Content;
            
            int currentIndex = itemList.ObserColl.IndexOf(item);

            if(item.Favorite == true)
            {
                itemList.ObserColl.Move(currentIndex,0);
            }
            else
            {
                itemList.ObserColl.Move(currentIndex, itemList.ObserColl.Count - 1);
            }

            db.TASKs.Attach(item);

            db.SaveChanges();
        }

        public static DependencyProperty ObserCollProperty = DependencyProperty.Register("ObserColl", typeof(ObservableCollection<TASK>), typeof(Task), new PropertyMetadata());

        public ObservableCollection<TASK> ObserColl
        {
            get { return (ObservableCollection<TASK>)GetValue(ObserCollProperty); }
            set { SetValue(ObserCollProperty, value); }
        }

        public static DependencyProperty TabIDProperty = DependencyProperty.Register("TabID", typeof(int), typeof(Task), new PropertyMetadata());

        public int TabID
        {
            get { return (int)GetValue(TabIDProperty); }
            set { SetValue(TabIDProperty, value); }
        }

    }
}
