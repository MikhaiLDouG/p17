using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.Entity;

namespace P16
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string login;
        private string password;
        DataBaseEntities data;
        public MainWindow()
        {
            InitializeComponent();
            data = new DataBaseEntities();
            data.Verification.Load();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login = LoginText.Text;
            password = PasswordText.Text;
            ErrorText.Content = string.Empty;
            if (Verification())
            {
                Window2 window2 = new Window2();
                window2.Show();
                Close();
            }
            else
            {
                //ErrorText.Content = "Неверный логин или пароль";
            }
        }

        /// <summary>
        /// Проверка логина и пороля из таблицы Verification
        /// </summary>
        /// <returns></returns>
        private bool Verification()
        {
            data.Verification.Where(w => w.Email == password && w.Password == password);
            if (data.Verification.Where(w => w.Email == login && w.Password == password).Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
