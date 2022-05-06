using EstateApp.ModelBD;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace EstateApp
{
    /// <summary>
    /// Interaction logic for TableOrder.xaml
    /// </summary>
    public partial class TableOrder : Page
    {
        public TableOrder()
        {
            InitializeComponent();
            AvtorizationWindow.bd.Orders.Load();
            dtgTovarTable.ItemsSource = AvtorizationWindow.bd.Orders.Local.OrderBy(x => x.ID);
        }

        private void sortDate_Checked(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.Orders.Load();
            dtgTovarTable.ItemsSource = AvtorizationWindow.bd.Orders.Local.OrderByDescending(x => x.Date);
        }

        private void sortId_Checked(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.Orders.Load();
            dtgTovarTable.ItemsSource = AvtorizationWindow.bd.Orders.Local.OrderBy(x => x.ID);
        }

        private void sortIdProduct_Checked(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.Orders.Load();
            dtgTovarTable.ItemsSource = AvtorizationWindow.bd.Orders.Local.OrderBy(x => x.StateID);
        }
        Order selectEntites = new Order();

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.Orders.Load();
            selectEntites = (Order)dtgTovarTable.SelectedItem;
            if (selectEntites != null)
            {
                try
                {
                    tbId.Text = selectEntites.ID.ToString();
                    tbDateSale.Text = selectEntites.Date.ToString();
                    tbIdProd.Text = selectEntites.StateID.ToString();
                    spRed.Visibility = Visibility.Visible;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                AvtorizationWindow.Exp("Вы ничего не выбрали!");
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.Orders.Load();
            selectEntites = (Order)dtgTovarTable.SelectedItem;
            if (selectEntites != null)
            {
                try
                {
                    if (MessageBox.Show("Вы действительно хотите удалить этот элемент из базы данных?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        AvtorizationWindow.bd.Orders.Remove(selectEntites);
                        AvtorizationWindow.bd.SaveChanges();
                        dtgTovarTable.ItemsSource = AvtorizationWindow.bd.Orders.Local.OrderBy(x => x.ID);
                        AvtorizationWindow.Inf("Элемент удален");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                AvtorizationWindow.Exp("Вы ничего не выбрали!");
            }
        }

        private void tbId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[0-9]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbDateSale_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[0-9/:/\/]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbIdProd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[0-9]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }
          
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.Orders.Load();
            Order currentProduct = new Order();
            if (tbId.Text != "" && tbDateSale.Text != "" && tbIdProd.Text != "")
            {
                try
                {
                    currentProduct.ID = int.Parse(tbId.Text);
                    currentProduct.Date = DateTime.Parse(tbDateSale.Text);
                    currentProduct.StateID = int.Parse(tbIdProd.Text);
                    AvtorizationWindow.bd.Orders.Remove(selectEntites);
                    AvtorizationWindow.bd.Orders.Add(currentProduct);
                    AvtorizationWindow.bd.SaveChanges();
                    AvtorizationWindow.Inf("Данный сохранены");
                    spRed.Visibility = Visibility.Hidden;
                    dtgTovarTable.ItemsSource = AvtorizationWindow.bd.Orders.Local.OrderBy(x => x.ID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
