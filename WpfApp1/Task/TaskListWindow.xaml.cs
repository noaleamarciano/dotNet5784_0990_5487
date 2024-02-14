using PL.Engineer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for TaskListWindow.xaml
    /// </summary>
    public partial class TaskListWindow : Window
    {
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
        public BO.EngineerExperience Experience { get; set; } = BO.EngineerExperience.None;

        public IEnumerable<BO.Task> TaskList
        {
            get { return (IEnumerable<BO.Task>)GetValue(TaskListProperty); }
            set { SetValue(TaskListProperty, value); }
        }

        public static readonly DependencyProperty TaskListProperty =
            DependencyProperty.Register("TaskList", typeof(IEnumerable<BO.Task>), typeof(TaskListWindow), new PropertyMetadata(null));

        private void Window_activity(object sender, EventArgs e)
        {
            TaskList=s_bl?.Task.ReadAll()!;
        }
        public TaskListWindow() //Ctor of the task list window
        {
            InitializeComponent();
            TaskList = s_bl?.Task.ReadAll()!;
        }

        private void ComboBoxFilterTasks_SelectionChanged(object sender, SelectionChangedEventArgs e) //Filter the tasks
        {
            TaskList = (Experience == BO.EngineerExperience.None) ?
            s_bl?.Task.ReadAll()! : s_bl?.Task.ReadAll(item => item.exp == Experience)!;
        }
        private void ButtonAddTask_Click(object sender, RoutedEventArgs e) //Add a new task
        {
            new TaskWindow().ShowDialog(); //Open a task in add mode
        }

        private void openTaskUpdate(object sender, MouseButtonEventArgs e) //Open a task in update mode
        {
            BO.Task? taskInList = (sender as ListView)?.SelectedItem as BO.Task;
            new TaskWindow(taskInList!.taskId).ShowDialog();
        }
    }
}
