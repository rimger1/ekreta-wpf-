using ekreta_wpf_.Models;
using ekreta_wpf_.Services;
using SQLite;
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

namespace ekreta_wpf_
{
    /// <summary>
    /// Interaction logic for userlogin.xaml
    /// </summary>
    public partial class userlogin : Window
    {
        public userlogin()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            string felhasznalonevinput = LoginUserTxt.Text;
            string jelszoinput = PasswordHelper.HashPassword(LoginPasswordTxt.Password);
            if(!string.IsNullOrEmpty(LoginUserTxt.Text) || !string.IsNullOrEmpty(LoginPasswordTxt.Password))
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    var user = connection.Table<Felhasznalo>().FirstOrDefault(u => u.FelhasznaloNev == felhasznalonevinput);
                    if(user != null)
                    {
                        if (user.Jelszo == jelszoinput)
                        {
                            MainWindow mainwindow = new MainWindow();
                            mainwindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("belepes megtagadva");

                        }
                    }
                    else
                    {
                        MessageBox.Show("belepes megtagadva");
                    }
                }
            }
            else
            {
                MessageBox.Show("add meg az adataidat");
            }
        }
    }
}
