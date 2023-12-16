using MainProject.CustomControl;
using MainProject.Model;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MainProject.UserWindow
{
    /// <summary>
    /// Interaction logic for CreateTabWindow.xaml
    /// </summary>
    public partial class ManageTaskWindow : Window, INotifyPropertyChanged
    {
        public TODOLIST db = new TODOLIST();

        public TASK? updatingTask;

        public ManageTaskWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void TaskManageButton_Clicked(object sender, RoutedEventArgs e)
        {
            if(MainWindow.tabItems.Count == 0)
            {
                MessageBox.Show("Chưa có Tab nào được tạo ra!");
                return;
            }

            if (string.IsNullOrEmpty(TaskTitletb.Text) || string.IsNullOrEmpty(Descriptiontb.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
                return;
            }

            if (db.TASKs.Contains(updatingTask))
            {
                Task tabItemList = (Task)MainWindow.tabItems[MainWindow.currentTabIndex].Content;

                TASK tASK = updatingTask;

                tabItemList.ObserColl.Remove(tASK);

                updatingTask.Title = ThisTitle;
                updatingTask.Description = ThisDescription;

                tabItemList.ObserColl.Add(updatingTask);

                db.TASKs.Attach(updatingTask);

                db.SaveChanges();
            }
            else
            {
                Task tabItemList = (Task)MainWindow.tabItems[MainWindow.currentTabIndex].Content;

                TASK item = new TASK { Title = TaskTitletb.Text, Description = Descriptiontb.Text, TabId = tabItemList.TabID };

                tabItemList.ObserColl.Add(item);

                db.TASKs.Add(item);

                db.SaveChanges();
            }

            this.Close();
        }

        private void CloseTaskManageButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string? thisTitle;

        public string? ThisTitle
        {
            get
            {
                return thisTitle;
            }
            set
            {
                thisTitle = value;
                NotifyPropertyChanged(ThisTitle);
            }
        }

        public string? thisDescription;

        public string? ThisDescription
        {
            get
            {
                return thisDescription;
            }
            set
            {
                thisDescription = value;
                NotifyPropertyChanged(ThisDescription);
            }
        }


    }
}
