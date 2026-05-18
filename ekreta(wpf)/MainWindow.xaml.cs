using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ekreta_wpf_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void diakmenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            feladatpanel.Children.Clear();
            feladatpanel.Children.Add(new UserControls.UserControldiakok());

        }

        private void tanatmenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            feladatpanel.Children.Clear();
            feladatpanel.Children.Add(new UserControls.UserControltanarok());

        }

        private void osztalymenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            feladatpanel.Children.Clear();
            feladatpanel.Children.Add(new UserControls.UserControlosztalyok());

        }

        private void termekmenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            feladatpanel.Children.Clear();
            feladatpanel.Children.Add(new UserControls.UserControltermek());

        }

        private void felhasznalokmenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            feladatpanel.Children.Clear();
            feladatpanel.Children.Add(new UserControls.UserControlfelhasznalok());

        }

        private void kilepesmenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            feladatpanel.Children.Clear();
            feladatpanel.Children.Add(new UserControls.UserControldiakok());

        }
    }
}