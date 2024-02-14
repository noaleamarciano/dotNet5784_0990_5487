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

namespace PL.Engineer
{
    /// <summary>
    /// Interaction logic for EngineerWindow.xaml
    /// </summary>
    public partial class EngineerWindow : Window
    {
        int updateOrAdd;
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
        public BO.Engineer? CurrentEngineer //The current engineer that we opened
        {
            get { return (BO.Engineer?)GetValue(CurrentEngineerProperty); }
            set { SetValue(CurrentEngineerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentCourse.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentEngineerProperty =
        DependencyProperty.Register("CurrentEngineer", typeof(BO.Engineer), typeof(EngineerWindow), new PropertyMetadata(null));

        public EngineerWindow(int idWindow = 0) //Ctor of the engineer window
        {
            InitializeComponent();
            if (idWindow == 0)
            {
                updateOrAdd = 0;
                CurrentEngineer = new BO.Engineer() { engineerId =0, name = "", email = "", exp = BO.EngineerExperience.None };
                CurrentEngineer.task = new BO.TaskInEngineer();
            }
            else
            {
                updateOrAdd = idWindow;
                CurrentEngineer = s_bl.Engineer.Read(idWindow);
            }

        }

        private void btnAddUpdateEngineer_Click(object sender, RoutedEventArgs e) //Add or update an engineer
        {
            if (updateOrAdd==0) //Add mode
            {
                try
                {
                    s_bl.Engineer.Create(CurrentEngineer!);
                    MessageBox.Show("מהנדס נוסף בהצלחה", "הודעה", MessageBoxButton.OK, MessageBoxImage.Information);
                    new EngineerWindow().Close();
                }
                catch(Exception ex) {
                    throw new Exception();
                }
            }
            else //Update mode
            {
                try
                {
                    s_bl.Engineer.Update(CurrentEngineer!);
                    MessageBox.Show("מהנדס עודכן בהצלחה", "הודעה", MessageBoxButton.OK, MessageBoxImage.Information);
                    new EngineerWindow().Close();
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }

            }
        }

 
    }
}
