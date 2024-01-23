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
        public ObservableCollection<BO.Engineer> Engineer
        {
            get { return (ObservableCollection<BO.Engineer>)GetValue(EngineerProperty); }
            set { SetValue(EngineerProperty, value); }
        }
        public static readonly DependencyProperty EngineerProperty =
        DependencyProperty.Register("Engineer", typeof(ObservableCollection<BO.Engineer>),
        typeof(EngineerWindow), new PropertyMetadata(null));
        public EngineerWindow(int idWindow = 0)
        {
            BO.Engineer? engineer;
            InitializeComponent();
            if (idWindow == 0)
            {
                updateOrAdd = 0;
                engineer = new BO.Engineer();
            }
            else
            {
                updateOrAdd = idWindow;
                engineer = s_bl.Engineer.Read(idWindow);
            }

        }

        private void btnAddUpdateEngineer_Click(object sender, RoutedEventArgs e)
        {
           
            if (updateOrAdd==0)
            {
                try
                {
                    s_bl.Engineer.Create(Engineer[0]);
                    MessageBox.Show("מהנדס נוסף בהצלחה", "הודעה", MessageBoxButton.OK, MessageBoxImage.Information);
                    new EngineerWindow().Close();
                }
                catch(Exception ex) {
                    throw new Exception();
                }
            }
            else
            {
                try
                {
                    s_bl.Engineer.Update(Engineer[0]);
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
