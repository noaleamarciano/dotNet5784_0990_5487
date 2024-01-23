using System;
using System.Collections.Generic;
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
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
        public IEnumerable<BO.Engineer> Engineer
        {
            get { return (IEnumerable<BO.Engineer>)GetValue(EngineerProperty); }
            set { SetValue(EngineerProperty, value); }
        }
        public static readonly DependencyProperty EngineerProperty =
        DependencyProperty.Register("Engineer", typeof(IEnumerable<BO.Engineer>),
        typeof(EngineerWindow), new PropertyMetadata(null));
        public EngineerWindow(int idWindow = 0)
        {
            BO.Engineer? engineer;
            InitializeComponent();
            if (idWindow == 0)
            {
                engineer = new BO.Engineer();
            }
            else
            {
                engineer = s_bl.Engineer.Read(idWindow);
            }

        }

        private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
