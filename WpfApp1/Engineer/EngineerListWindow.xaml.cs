using System;
using System.Collections;
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

namespace PL.Engineer
{
    /// <summary>
    /// Interaction logic for EngineerListWindow.xaml
    /// </summary>
    
    public partial class EngineerListWindow : Window
    {
        public BO.EngineerExperience Experience { get; set; } = BO.EngineerExperience.None;

        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
        public EngineerListWindow() //Ctot of the engineer list window
        {
            InitializeComponent();
            EngineerList = s_bl?.Engineer.ReadAll()!;
        }

        private void Window_activity(object sender, EventArgs e)
        {
            EngineerList = s_bl?.Engineer.ReadAll()!;
        }

        public IEnumerable<BO.Engineer> EngineerList
        {
            get { return (IEnumerable<BO.Engineer>)GetValue(EngineerListProperty); }
            set { SetValue(EngineerListProperty, value); }
        }
        public static readonly DependencyProperty EngineerListProperty =
        DependencyProperty.Register("EngineerList", typeof(IEnumerable<BO.Engineer>),
        typeof(EngineerListWindow), new PropertyMetadata(null));

        private void ComboBox_FilterByExperience(object sender, SelectionChangedEventArgs e) //Filter the engineers
        {
            EngineerList = (Experience == BO.EngineerExperience.None) ?
            s_bl?.Engineer.ReadAll()! : s_bl?.Engineer.ReadAll(item => item.exp == Experience)!;
        }

        private void ButtonAddEngineer_Click(object sender, RoutedEventArgs e) //For adding a new engineer
        {
            new EngineerWindow().ShowDialog();
        }

        private void openEngineerUpdate(object sender, MouseButtonEventArgs e) //Open an engineer in update mode
        {
            BO.Engineer? engineerInList = (sender as ListView)?.SelectedItem as BO.Engineer;
            new EngineerWindow(engineerInList!.engineerId).ShowDialog();
        }
    }
}
