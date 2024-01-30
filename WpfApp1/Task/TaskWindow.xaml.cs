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
        public BO.Task? CurrentTask
        {
            get { return (BO.Task?)GetValue(CurrentTaskProperty); }
            set { SetValue(CurrentTaskProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentCourse.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentTaskProperty =
            DependencyProperty.Register("CurrentTask", typeof(BO.Task), typeof(TaskWindow), new PropertyMetadata(null));
        public TaskWindow(int idWindow=0)
        {
           
            InitializeComponent();
            if (idWindow == 0)
            {
                updateOrAdd = 0;
                CurrentTask = new BO.Task() { };
            }
            else
            {
                updateOrAdd = idWindow;
                CurrentTask = s_bl.Task.Read(idWindow);
            }
        }

        private void btnAddUpdateTask_Click(object sender, RoutedEventArgs e)
        {
            if (updateOrAdd == 0)
            {
                try
                {
                    s_bl.Task.Create(CurrentTask!);
                    MessageBox.Show("משימה נוסף בהצלחה", "הודעה", MessageBoxButton.OK, MessageBoxImage.Information);
                    new TaskWindow().Close();
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
            }
            else
            {
                try
                {
                    s_bl.Task.Update(CurrentTask!);
                    MessageBox.Show("משימה עודכן בהצלחה", "הודעה", MessageBoxButton.OK, MessageBoxImage.Information);
                    new TaskWindow().Close();
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
   
}
