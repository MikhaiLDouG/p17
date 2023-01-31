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
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace P16
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow(MSAccessEntities ms)
        {
            InitializeComponent();
            cancelBtn.Click += delegate { DialogResult = false; };

            OkBtn.Click += delegate
            {
                Nullable<int> phone = null;
                if (PhoneText.Text != string.Empty)
                {
                    phone = int.Parse(PhoneText.Text);
                }

                var customer = new Customer()
                {
                    Surname = SurnameText.Text,
                    Name = NameText.Text,
                    Name2 = Name2Text.Text,
                    Phone = phone,
                    Email = EmailText.Text
                };
                ms.Customer.Add(customer);
                ms.SaveChanges();
                DialogResult = true;
                Close();
            };
        }
    }
}
