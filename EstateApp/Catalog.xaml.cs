using EstateApp.ModelBD;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace EstateApp
{
    /// <summary>
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        public Catalog()
        {
            InitializeComponent();
            AvtorizationWindow.bd.States.Load();
            lvTovar.ItemsSource = AvtorizationWindow.bd.States.Local;
            List<string> a = new List<string>() { "Все", "1-комн. квартира", "2-комн. квартира", "3-комн. квартира" };
            cmbCategory.ItemsSource = a;
            cmbCategory.SelectedIndex = 0;

            if (Manager.Admin == true)
            {
                btnBuy.Visibility = Visibility.Hidden;
                btnRed.Visibility = Visibility.Visible;
                btnDel.Visibility = Visibility.Visible;
                btnAdd.Visibility = Visibility.Visible;
            }
            else
            {
                btnBuy.Visibility = Visibility.Visible;
                btnRed.Visibility = Visibility.Hidden;
                btnDel.Visibility = Visibility.Hidden;
                btnAdd.Visibility = Visibility.Hidden;
            }
        }

        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AvtorizationWindow.bd.States.Load();
            if (cmbCategory.SelectedIndex == 0)
            {
                lvTovar.ItemsSource = AvtorizationWindow.bd.States.Local;
            }
            else if (cmbCategory.SelectedIndex == 1)
            {
                lvTovar.ItemsSource = AvtorizationWindow.bd.States.Local.Where(x => x.Category.Contains("1-комн. квартира"));
            }
            else if (cmbCategory.SelectedIndex == 2)
            {
                lvTovar.ItemsSource = AvtorizationWindow.bd.States.Local.Where(x => x.Category.Contains("2-комн. квартира"));
            }
            else if (cmbCategory.SelectedIndex == 3)
            {
                lvTovar.ItemsSource = AvtorizationWindow.bd.States.Local.Where(x => x.Category.Contains("3-комн. квартира"));
            }
        }
        public static State selectEntites = new State();

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            selectEntites = (State)lvTovar.SelectedItem;
            if (selectEntites != null)
            {
                BuyWindow bw = new BuyWindow();
                bw.Show();
            }
            else
            {
                AvtorizationWindow.Exp("Вы ничего не выбрали!");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd a = new WindowAdd();
            a.Show();
        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            selectEntites = (State)lvTovar.SelectedItem;
            if (selectEntites != null)
            {
                WindowRed a = new WindowRed();
                a.Show();
            }
            else
            {
                AvtorizationWindow.Exp("Вы ничего не выбрали!");
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить этот элемент из базы данных?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                selectEntites = (State)lvTovar.SelectedItem;
                try
                {
                    AvtorizationWindow.bd.States.Remove(selectEntites);
                    AvtorizationWindow.bd.SaveChanges();
                    lvTovar.ItemsSource = AvtorizationWindow.bd.States.Local;
                    AvtorizationWindow.Inf("Элемент удален");
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
            
}
    }

