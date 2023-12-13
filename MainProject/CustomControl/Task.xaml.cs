using MainProject.Model;
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

namespace MainProject.CustomControl
{
    /// <summary>
    /// Interaction logic for Task.xaml
    /// </summary>
    public partial class Task : UserControl
    {
        public Task()
        {
            InitializeComponent();

            testGrid.ItemsSource = ObserColl;
        }

        public static DependencyProperty ObserCollProperty = DependencyProperty.Register("ObserColl", typeof(ObservableCollection<TASK>),typeof(Task),new PropertyMetadata("Obser Coll"));

        public ObservableCollection<TASK> ObserColl
        {
            get { return (ObservableCollection<TASK>)GetValue(ObserCollProperty); }
            set { SetValue(ObserCollProperty, value);}
        }

    }
}
