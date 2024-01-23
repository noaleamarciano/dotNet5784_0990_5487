using PL.Engineer;
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
using System.Windows.Shapes;

namespace PL.Task
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
   
    public partial class TaskWindow : Window
    {
        int updateOrAdd;
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

        public ObservableCollection<BO.Task> Task
        {
            get { return (ObservableCollection<BO.Task>)GetValue(TaskProperty); }
            set { SetValue(TaskProperty, value); }
        }
        public static readonly DependencyProperty TaskProperty =
        DependencyProperty.Register("Task", typeof(ObservableCollection<BO.Task>),
        typeof(TaskWindow), new PropertyMetadata(null));
        public TaskWindow(int idWindow=0)
        {
            BO.Task? task;
            InitializeComponent();
            if (idWindow == 0)
            {
                updateOrAdd = 0;
                task = new BO.Task();
            }
            else
            {
                updateOrAdd = idWindow;
                task = s_bl.Task.Read(idWindow);
            }
        }
    }
}
