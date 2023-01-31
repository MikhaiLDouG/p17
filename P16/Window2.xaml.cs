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

    public partial class Window2 : Window
    {
        MSAccessEntities ms;

        public Window2()
        {
            InitializeComponent();
            PreparingMS();
        }

        private void PreparingMS()
        {
            ms = new MSAccessEntities();
            ms.Customer.Load();
            grid.DataContext = ms.Customer.Local.ToBindingList();
        }

        private void GVCurrentCellChanged(object sender, EventArgs e)
        {
            ms.SaveChanges();
        }
        
        /// <summary>
        /// Добавление покупателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            AddWindow add = new AddWindow(ms);
            add.ShowDialog();
            if (add.DialogResult.Value)
            {
                grid.DataContext = ms.Customer.Local.ToBindingList();
            }
        }


        /// <summary>
        /// Открывает окно покупок выбранного покупателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAllProduct(object sender, RoutedEventArgs e)
        {

            Customer customer = (Customer)grid.SelectedItem;
            WindowProduct w = new WindowProduct(customer);
            w.Show();

        }

        /// <summary>
        /////// Удаляет покупателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            var c = (Customer)grid.SelectedItem;
            ms.Customer.Remove(c);
            ms.SaveChanges();
        }

        private void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
    }
}