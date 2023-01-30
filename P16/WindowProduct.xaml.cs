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

namespace P16
{
    /// <summary>
    /// Логика взаимодействия для WindowProduct.xaml
    /// </summary>
    public partial class WindowProduct : Window
    {
        public WindowProduct(Customer customer)
        {
            InitializeComponent();
            Prepare(customer);
        }

        /// <summary>
        /// Выводит список продуктов выбранного покупателя
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="DBConnection"></param>
        private void Prepare(Customer customer)
        {
            ProductEntities product = new ProductEntities();
            product.Product.Where(w => w.Email == customer.Email).Load();
            grid.DataContext = product.Product.Local.ToBindingList();
        }
    }
}
