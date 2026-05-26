using ekreta_wpf_.Models;
using ekreta_wpf_.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace ekreta_wpf_.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlfelhasznalok.xaml
    /// </summary>
    public partial class UserControlfelhasznalok : UserControl
    {
        List<Felhasznalo> felhasznalok;
        Felhasznalo kivalasztottfelhasznalo;
        public UserControlfelhasznalok()
        {
            InitializeComponent();
            szerepkkorCombobox.ItemsSource=Enum.GetNames(typeof(Szerepkor));
            AdatbazisLekerdezes();
            felhasznalok = new List<Felhasznalo>();
        }

        private void AdatbazisLekerdezes()
        {
            var felhasznaloRepo = new GenericRepository<Felhasznalo>(App.databasePath);
            var lekerdezes = felhasznaloRepo.GetAll();
            datagridfelhasznalok.ItemsSource=lekerdezes;
            mentesBtn.Visibility= Visibility.Visible;
            modBtn.Visibility= Visibility.Collapsed;
            torlesBtn.Visibility= Visibility.Collapsed;
        }

        private void datagridfelhasznalok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mentesBtn.Visibility =Visibility.Collapsed;
            modBtn.Visibility =Visibility.Visible;
            torlesBtn.Visibility =Visibility.Visible;
            if(datagridfelhasznalok.SelectedItem != null)
            {
                kivalasztottfelhasznalo = (Felhasznalo)datagridfelhasznalok.SelectedItem;
                felhasznalonevTxt.Text = kivalasztottfelhasznalo.FelhasznaloNev;
                teljesnevTxt.Text = kivalasztottfelhasznalo.TeljesNev;
                szerepkkorCombobox.Text = kivalasztottfelhasznalo.SzerepkorNev;

            }

        }

        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {
            string kivalasztottSzerepkorNev = (string)szerepkkorCombobox.SelectedItem;
            Szerepkor kivalasztottszerepkor = (Szerepkor)Enum.Parse(typeof(Szerepkor),kivalasztottSzerepkorNev);
            int kivalasztottSzereokorId = (int)kivalasztottszerepkor;

            Felhasznalo ujfelhasznalo = new Felhasznalo(felhasznalonevTxt.Text,teljesnevTxt.Text,PasswordHelper.HashPassword( jelszoText.Password),kivalasztottSzereokorId);

            var felhasznaloRepo = new GenericRepository<Felhasznalo>(App.databasePath);
            felhasznaloRepo.Insert(ujfelhasznalo);
            AdatbazisLekerdezes();
        }

        private void torlesBtn_Click(object sender, RoutedEventArgs e)
        {

            var felhasznaloRepo = new GenericRepository<Felhasznalo>(App.databasePath);
            felhasznaloRepo.Delete(kivalasztottfelhasznalo);
            AdatbazisLekerdezes();

        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            kivalasztottfelhasznalo.FelhasznaloNev =felhasznalonevTxt.Text;
            kivalasztottfelhasznalo.TeljesNev =teljesnevTxt.Text;
            string kivalasztottSzerepkorNev = (string)szerepkkorCombobox.SelectedItem;
            Szerepkor kivalasztottSzerepkor = (Szerepkor)Enum.Parse(typeof(Szerepkor), kivalasztottSzerepkorNev);
            kivalasztottfelhasznalo.Szerepkor = (int)kivalasztottSzerepkor;

            if(jelszoText.Password != "")
            {
                kivalasztottfelhasznalo.Jelszo = PasswordHelper.HashPassword(jelszoText.Password);
            }
            var felhasznaloRepo = new GenericRepository<Felhasznalo>(App.databasePath);
            felhasznaloRepo.Update(kivalasztottfelhasznalo);
            AdatbazisLekerdezes();



        }
    }
}
