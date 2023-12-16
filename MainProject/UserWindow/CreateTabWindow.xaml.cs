using MainProject.CustomControl;
using MainProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
    public partial class CreateTabWindow : Window,INotifyPropertyChanged
    {
        private TODOLIST db = new TODOLIST();

        public TAB? updatingTab;

        public CreateTabWindow()
        {
            InitializeComponent();
            this.DataContext = this;
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

            if (db.TABs.Contains(updatingTab))
            {
                updatingTab.Title = ThisTitle;

                db.TABs.Attach(updatingTab);

                db.TABs.Update(updatingTab);

                db.SaveChanges();
            }
            else
            {
                TAB tAB = new TAB { Title = tabTitletb.Text };

                db.TABs.Add(tAB);

                db.SaveChanges();               

                db.Entry(tAB).Reload();

                TabItem tabItem = new TabItem
                {
                    Header = new CloseableHeader { Title = tabTitletb.Text, closeableHeadTAB = tAB },
                    Content = new Task { TabID = tAB.TabId }
                };

                MainWindow.tabItems.Add(tabItem);

                MainWindow.currentTabIndex = MainWindow.tabItems.IndexOf(tabItem);
            }

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
    }
}
